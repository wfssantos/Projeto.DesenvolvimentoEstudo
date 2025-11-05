using AutoMapper;
using Projeto.DesenvolvimentoEstudo.Application.CompaniesSales.Filters;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.CompaniesSales;

namespace Projeto.DesenvolvimentoEstudo.Application.CompaniesSales.Mapper;

internal class CompanySaleProfile : Profile
{
    public CompanySaleProfile()
    {
        CreateMap<GetAllCompanySaleRequest, GetAllCompanySaleFilter>().ReverseMap();
    }
}
