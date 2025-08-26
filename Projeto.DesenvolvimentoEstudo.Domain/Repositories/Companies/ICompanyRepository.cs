using Projeto.DesenvolvimentoEstudo.Domain.Common;

namespace Projeto.DesenvolvimentoEstudo.Domain.Repositories.Companies;

public interface ICompanyRepository
{
    Task<PagedResponse<GetAllCompanyResponse>> ListAsync(GetAllCompanyRequest filter);
}
