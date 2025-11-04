using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Companies;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Users;
using Projeto.DesenvolvimentoEstudo.ORM;
using Projeto.DesenvolvimentoEstudo.ORM.Repositories;

namespace Projeto.DesenvolvimentoEstudo.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
    }
}
