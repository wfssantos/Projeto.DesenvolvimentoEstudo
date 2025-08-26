using AutoMapper;
using Projeto.DesenvolvimentoEstudo.Application.Companies.Filters;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Companies;

namespace Projeto.DesenvolvimentoEstudo.Application.Companies.Mapper;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<GetAllCompanyRequest, GetAllCompanyFilter>().ReverseMap();
    }
}
