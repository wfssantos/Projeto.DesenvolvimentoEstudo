using MediatR;
using Projeto.DesenvolvimentoEstudo.Application.Companies.Filters;
using Projeto.DesenvolvimentoEstudo.Domain.Common;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Companies;

namespace Projeto.DesenvolvimentoEstudo.Application.Companies.Commands;

public class GetAllCompanyCommand : IRequest<PagedResponse<GetAllCompanyResponse>>
{
    public GetAllCompanyFilter Filter { get; set; } = new();
}
