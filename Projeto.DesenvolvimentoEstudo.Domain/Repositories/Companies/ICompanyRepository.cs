using Projeto.DesenvolvimentoEstudo.Domain.Common;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;

namespace Projeto.DesenvolvimentoEstudo.Domain.Repositories.Companies;

public interface ICompanyRepository
{
    Task<PagedResponse<GetAllCompanyResponse>> ListAsync(GetAllCompanyRequest filter, CancellationToken cancellationToken);

    Task<Company> CreateAsync(Company company, CancellationToken cancellationToken);
}
