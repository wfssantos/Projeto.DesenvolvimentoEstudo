using Microsoft.AspNetCore.Builder;

namespace Projeto.DesenvolvimentoEstudo.IoC;

public interface IModuleInitializer
{
    void Initialize(WebApplicationBuilder builder);
}
