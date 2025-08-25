using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Projeto.DesenvolvimentoEstudo.Common.Security;

namespace Projeto.DesenvolvimentoEstudo.IoC.ModuleInitializers;

public class ApplicationModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();
    }    
}
