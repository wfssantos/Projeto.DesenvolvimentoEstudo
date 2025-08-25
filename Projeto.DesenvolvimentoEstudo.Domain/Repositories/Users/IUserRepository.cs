namespace Projeto.DesenvolvimentoEstudo.Domain.Repositories.Users;

public interface IUserRepository
{
    Task<IEnumerable<GetAllResponse>> ListAsync(IGetAllRequest filter);
}
