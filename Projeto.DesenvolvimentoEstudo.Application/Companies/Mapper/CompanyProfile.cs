using AutoMapper;
using Projeto.DesenvolvimentoEstudo.Application.Companies.Commands;
using Projeto.DesenvolvimentoEstudo.Application.Companies.Filters;
using Projeto.DesenvolvimentoEstudo.Application.Companies.Response;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Companies;

namespace Projeto.DesenvolvimentoEstudo.Application.Companies.Mapper;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<GetAllCompanyRequest, GetAllCompanyFilter>().ReverseMap();

        CreateMap<Company, CreateCompanyCommand>().ReverseMap();
        CreateMap<CompanyPhone, CreateCompanyPhoneCommand>().ReverseMap();
        CreateMap<CompanyAddress, CreateCompanyAddressCommand>().ReverseMap();
        CreateMap<CompanyEmail, CreateCompanyEmailCommand>().ReverseMap();

        CreateMap<Company, CreateCompanyCommandResponse>().ReverseMap();
    }
}
