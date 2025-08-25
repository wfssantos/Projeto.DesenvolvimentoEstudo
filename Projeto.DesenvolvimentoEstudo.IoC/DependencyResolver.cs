using Microsoft.AspNetCore.Builder;
using Projeto.DesenvolvimentoEstudo.IoC.ModuleInitializers;

namespace Projeto.DesenvolvimentoEstudo.IoC;

public static class DependencyResolver
{
    public static void RegisterDependencies(this WebApplicationBuilder builder)
    {
        //new ApplicationModuleInitializer().Initialize(builder);
        new InfrastructureModuleInitializer().Initialize(builder);
        new WebApiModuleInitializer().Initialize(builder);
    }
}
