using MediatR;
using Projeto.DesenvolvimentoEstudo.Application.CompaniesProducts.Filters;
using Projeto.DesenvolvimentoEstudo.Domain.Common;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.CompaniesProducts;

namespace Projeto.DesenvolvimentoEstudo.Application.CompaniesProducts.Commands;

public class GetAllCompanyProductCommand : IRequest<PagedResponse<GetAllCompanyProductResponse>>
{
    public GetAllCompanyProductFilter Filter { get; set; } = new();
}
