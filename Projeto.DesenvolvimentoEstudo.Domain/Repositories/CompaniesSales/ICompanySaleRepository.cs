using Projeto.DesenvolvimentoEstudo.Domain.Common;

namespace Projeto.DesenvolvimentoEstudo.Domain.Repositories.CompaniesSales;

public interface ICompanySaleRepository
{
    Task<PagedResponse<GetAllCompanySaleResponse>> ListAsync(GetAllCompanySaleRequest filter, CancellationToken cancellationToken);
}
