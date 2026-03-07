using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OtpNet;
using Projeto.DesenvolvimentoEstudo.APIAuthAzureFunctions.Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_DesenvolvimentoEstudo_AuthAzureFunctions.Functions
{
    public static class AuthToken
    {
        // DEMO ONLY: normalmente viria do KeyVault / banco
        private static readonly string JwtIssuer =
            Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "Projeto.DesenvolvimentoEstudo";

        private static readonly string JwtAudience =
            Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "Projeto.DesenvolvimentoEstudo.Client";

        private static readonly string JwtSigningKey =
            Environment.GetEnvironmentVariable("JWT_SIGNING_KEY") ?? "DEV_ONLY_CHANGE_ME_32_CHARS_MINIMUM____";

        private static readonly int AccessTokenMinutes =
            int.TryParse(Environment.GetEnvironmentVariable("JWT_ACCESS_MINUTES"), out var m) ? m : 30;

        // Secret TOTP do usuário admin (DEMO)
        private static readonly string AdminTotpSecretBase32 =
            Environment.GetEnvironmentVariable("ADMIN_TOTP_SECRET_BASE32") ?? "JBSWY3DPEHPK3PXP";


        [FunctionName("AuthToken")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "auth/token")] HttpRequest req)
        {
            // Ler body
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<LoginRequest>(body);

            if (data is null || string.IsNullOrWhiteSpace(data.Username) || string.IsNullOrWhiteSpace(data.Password))
                return new BadRequestObjectResult(new { error = "invalid_request" });

            // DEMO ONLY: valida usuário fixo
            if (!(data.Username == "admin" && data.Password == "password"))
                return new UnauthorizedObjectResult(new { error = "invalid_credentials" });

            // Gera token temporário para MFA
            var mfaToken = CreateJwt(
                subject: data.Username,
                additionalClaims: new[] { new Claim("purpose", "mfa") },
                expiresUtc: DateTime.UtcNow.AddMinutes(5)
            );

            // Gerar TOTP atual (DEBUG)
            var secretBytes = Base32Encoding.ToBytes(AdminTotpSecretBase32);
            var totp = new Totp(secretBytes);
            var currentCode = totp.ComputeTotp();

            return new OkObjectResult(new
            {
                mfa_required = true,
                mfa_token = mfaToken,
                debug_totp = currentCode,
                message = "MFA required. Provide TOTP code to verify."
            });
        }


        private static string CreateJwt(string subject, Claim[] additionalClaims, DateTime expiresUtc)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSigningKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.Iss, JwtIssuer),
                new Claim("role", "Admin")
            };

            var allClaims = new Claim[claims.Length + additionalClaims.Length];

            Array.Copy(claims, allClaims, claims.Length);
            Array.Copy(additionalClaims, 0, allClaims, claims.Length, additionalClaims.Length);

            var token = new JwtSecurityToken(
                issuer: JwtIssuer,
                audience: JwtAudience,
                claims: allClaims,
                notBefore: DateTime.UtcNow,
                expires: expiresUtc,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}