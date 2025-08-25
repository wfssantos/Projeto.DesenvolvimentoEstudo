using MediatR;
using Projeto.DesenvolvimentoEstudo.Application.Users.Results;
using Projeto.DesenvolvimentoEstudo.Model.Enums;

namespace Projeto.DesenvolvimentoEstudo.Application.Users.Commands;

/// <summary>
///     Command for creating a new user.
/// </summary>
/// <remarks>
///     This command is used to capture the required data for creating a user,
///     including username, password, email, status.
///     It implements <see cref="IRequest{TResponse}" /> to initiate the request
///     that returns a <see cref="CreateUserResult" />.
/// </remarks>
public class CreateUserCommand : IRequest<CreateUserResult>
{
    /// <summary>
    ///     Gets or sets the username of the user to be created.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the password for the user.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the email address for the user.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the status of the user.
    /// </summary>
    public UserStatus Status { get; set; } = UserStatus.Unknown;
}
