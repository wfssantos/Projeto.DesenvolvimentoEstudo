using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace Projeto_DesenvolvimentoEstudo_AuthAzureFunctions.Functions
{
    public static class LoginApi
    {
        [FunctionName("LoginApi")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req)
        {
            string username = req.Query["username"];
            string password = req.Query["password"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            LoginRequest data = JsonConvert.DeserializeObject<LoginRequest>(requestBody);

            username ??= data?.Username;
            password ??= data?.Password;

            if (username == "admin" && password == "password")
            {
                return new OkObjectResult("Login successful");
            }
            else
            {
                return new UnauthorizedObjectResult("Invalid credentials");
            }
        }

        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
