using Microsoft.EntityFrameworkCore;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Users;

namespace Projeto.DesenvolvimentoEstudo.ORM.Repositories;

/// <summary>
/// Implementation of IUserRepository using Entity Framework Core
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of UserRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public UserRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     List all users asynchronously
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<GetAllResponse>> ListAsync(IGetAllRequest filter)
    {
        return await _context.Users.AsNoTracking().Select(user => new GetAllResponse
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email,
            Status = user.Status,
            CreatedAt = user.CreatedAt
        }).ToListAsync();
    }

    /// <summary>
    ///     Creates a new user in the database
    /// </summary>
    /// <param name="user">The user to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user</returns>
    public async Task<User> CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        await _context.Users.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }
}
