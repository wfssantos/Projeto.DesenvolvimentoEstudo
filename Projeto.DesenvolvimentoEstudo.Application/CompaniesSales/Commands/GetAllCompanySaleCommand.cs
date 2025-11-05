using MediatR;
using Projeto.DesenvolvimentoEstudo.Application.CompaniesSales.Filters;
using Projeto.DesenvolvimentoEstudo.Domain.Common;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.CompaniesSales;

namespace Projeto.DesenvolvimentoEstudo.Application.CompaniesSales.Commands;

public class GetAllCompanySaleCommand : IRequest<PagedResponse<GetAllCompanySaleResponse>>
{
    public GetAllCompanySaleFilter Filter { get; set; } = new();
}
