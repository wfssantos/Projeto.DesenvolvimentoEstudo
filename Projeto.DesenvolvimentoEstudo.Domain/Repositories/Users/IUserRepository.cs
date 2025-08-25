using Projeto.DesenvolvimentoEstudo.Domain.Entities;

namespace Projeto.DesenvolvimentoEstudo.Domain.Repositories.Users;

public interface IUserRepository
{
    Task<IEnumerable<GetAllResponse>> ListAsync(IGetAllRequest filter);

    /// <summary>
    ///     Creates a new user in the repository
    /// </summary>
    /// <param name="user">The user to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user</returns>
    Task<User> CreateAsync(User user, CancellationToken cancellationToken = default);
}
