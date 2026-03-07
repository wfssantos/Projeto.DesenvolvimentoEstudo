using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OtpNet;
using Projeto.DesenvolvimentoEstudo.APIAuthAzureFunctions.Model;
using System;
using System.IO;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_DesenvolvimentoEstudo_AuthAzureFunctions.Functions
{
    public static class VerifyMfa
    {
        private static readonly string JwtIssuer =
            Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "Projeto.DesenvolvimentoEstudo";

        private static readonly string JwtAudience =
            Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "Projeto.DesenvolvimentoEstudo.Client";

        private static readonly string JwtSigningKey =
            Environment.GetEnvironmentVariable("JWT_SIGNING_KEY") ?? "DEV_ONLY_CHANGE_ME_32_CHARS_MINIMUM____";

        private static readonly int AccessTokenMinutes =
            int.TryParse(Environment.GetEnvironmentVariable("JWT_ACCESS_MINUTES"), out var m) ? m : 30;

        private static readonly string AdminTotpSecretBase32 =
            Environment.GetEnvironmentVariable("ADMIN_TOTP_SECRET_BASE32") ?? "JBSWY3DPEHPK3PXP";

        [FunctionName("VerifyMfa")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "auth/verify-mfa")] HttpRequest req)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();

            if (string.IsNullOrWhiteSpace(body))
                return new BadRequestObjectResult(new { error = "empty_body" });

            var data = JsonConvert.DeserializeObject<MfaRequest>(body);

            if (data is null)
                return new BadRequestObjectResult(new { error = "invalid_json", rawBody = body });

            if (string.IsNullOrWhiteSpace(data.MfaToken))
                return new BadRequestObjectResult(new { error = "mfa_token_missing" });

            if (string.IsNullOrWhiteSpace(data.Code))
                return new BadRequestObjectResult(new { error = "code_missing" });

            var principal = ValidateJwt(data.MfaToken, validateLifetime: true);
            if (principal is null)
                return new UnauthorizedObjectResult(new { error = "invalid_token" });

            var purpose = principal.Claims.FirstOrDefault(c => c.Type == "purpose")?.Value;
            if (!string.Equals(purpose, "mfa", StringComparison.OrdinalIgnoreCase))
            {
                return new UnauthorizedObjectResult(new
                {
                    error = "invalid_token_purpose",
                    purpose
                });
            }

            var username =
                principal.Claims.FirstOrDefault(c => c.Type == "sub")?.Value ??
                principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(username))
            {
                return new UnauthorizedObjectResult(new
                {
                    error = "username_claim_missing",
                    claims = principal.Claims.Select(c => new { c.Type, c.Value })
                });
            }

            var secretBytes = Base32Encoding.ToBytes(AdminTotpSecretBase32);
            var totp = new Totp(secretBytes);

            var isValidCode = totp.VerifyTotp(
                data.Code,
                out long matchedStep,
                new VerificationWindow(previous: 1, future: 1));

            if (!isValidCode)
            {
                return new UnauthorizedObjectResult(new
                {
                    error = "invalid_mfa_code",
                    debug_current_totp = totp.ComputeTotp()
                });
            }

            var accessToken = CreateAccessJwt(username, DateTime.UtcNow.AddMinutes(AccessTokenMinutes));

            return new OkObjectResult(new
            {
                token_type = "Bearer",
                access_token = accessToken,
                expires_in = AccessTokenMinutes * 60,
                username,
                matched_step = matchedStep
            });
        }

        private static ClaimsPrincipal? ValidateJwt(string token, bool validateLifetime)
        {
            var tokenHandler = new JwtSecurityTokenHandler
            {
                MapInboundClaims = false
            };

            var key = Encoding.UTF8.GetBytes(JwtSigningKey);

            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = JwtIssuer,
                    ValidateAudience = true,
                    ValidAudience = JwtAudience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = validateLifetime,
                    ClockSkew = TimeSpan.FromSeconds(30)
                }, out _);

                return principal;
            }
            catch
            {
                return null;
            }
        }

        private static string CreateAccessJwt(string subject, DateTime expiresUtc)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSigningKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("sub", subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim("role", "Admin"),
                new Claim("amr", "pwd+mfa")
            };

            var token = new JwtSecurityToken(
                issuer: JwtIssuer,
                audience: JwtAudience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiresUtc,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}