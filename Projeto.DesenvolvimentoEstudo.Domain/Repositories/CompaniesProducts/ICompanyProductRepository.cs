using Projeto.DesenvolvimentoEstudo.Domain.Common;

namespace Projeto.DesenvolvimentoEstudo.Domain.Repositories.CompaniesProducts;

public interface ICompanyProductRepository
{
    Task<PagedResponse<GetAllCompanyProductResponse>> ListAsync(GetAllCompanyProductRequest filter, CancellationToken cancellationToken);
}
