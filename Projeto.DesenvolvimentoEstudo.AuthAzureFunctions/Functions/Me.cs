using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Projeto_DesenvolvimentoEstudo_AuthAzureFunctions.Functions
{
    public static class Me
    {
        private static readonly string JwtIssuer =
            Environment.GetEnvironmentVariable("JWT_ISSUER") ?? "Projeto.DesenvolvimentoEstudo";

        private static readonly string JwtAudience =
            Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? "Projeto.DesenvolvimentoEstudo.Client";

        private static readonly string JwtSigningKey =
            Environment.GetEnvironmentVariable("JWT_SIGNING_KEY") ?? "DEV_ONLY_CHANGE_ME_32_CHARS_MINIMUM____";

        [FunctionName("Me")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "auth/me")] HttpRequest req)
        {
            var auth = req.Headers["Authorization"].FirstOrDefault();

            if (string.IsNullOrWhiteSpace(auth) || !auth.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                return new UnauthorizedResult();

            var token = auth.Substring("Bearer ".Length).Trim();
            var principal = ValidateJwt(token);

            if (principal is null)
                return new UnauthorizedResult();

            var purpose = principal.Claims.FirstOrDefault(c => c.Type == "purpose")?.Value;
            if (string.Equals(purpose, "mfa", StringComparison.OrdinalIgnoreCase))
            {
                return new UnauthorizedObjectResult(new
                {
                    error = "mfa_token_not_allowed"
                });
            }

            var amr = principal.Claims.FirstOrDefault(c => c.Type == "amr")?.Value;
            if (!string.Equals(amr, "pwd+mfa", StringComparison.OrdinalIgnoreCase))
            {
                return new UnauthorizedObjectResult(new
                {
                    error = "insufficient_authentication"
                });
            }

            var username =
                principal.Claims.FirstOrDefault(c => c.Type == "sub")?.Value ??
                principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ??
                principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (string.IsNullOrWhiteSpace(username))
                return new UnauthorizedObjectResult(new { error = "username_claim_missing" });

            return new OkObjectResult(new
            {
                username,
                amr
            });
        }

        private static ClaimsPrincipal? ValidateJwt(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler
            {
                MapInboundClaims = false
            };

            var key = Encoding.UTF8.GetBytes(JwtSigningKey);

            try
            {
                return tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = JwtIssuer,
                    ValidateAudience = true,
                    ValidAudience = JwtAudience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromSeconds(30)
                }, out _);
            }
            catch
            {
                return null;
            }
        }
    }
}