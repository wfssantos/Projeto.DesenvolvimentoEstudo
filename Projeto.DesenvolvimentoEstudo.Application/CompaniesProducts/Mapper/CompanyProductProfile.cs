using AutoMapper;
using Projeto.DesenvolvimentoEstudo.Application.CompaniesProducts.Filters;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.CompaniesProducts;

namespace Projeto.DesenvolvimentoEstudo.Application.Companies.Mapper;

public class CompanyProductProfile : Profile
{
    public CompanyProductProfile()
    {
        CreateMap<GetAllCompanyProductRequest, GetAllCompanyProductFilter>().ReverseMap();
    }
}
