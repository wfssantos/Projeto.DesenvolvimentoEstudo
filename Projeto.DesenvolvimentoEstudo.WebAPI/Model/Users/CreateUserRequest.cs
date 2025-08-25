using System.ComponentModel.DataAnnotations;

namespace Projeto.DesenvolvimentoEstudo.WebAPI.Model.Users;

/// <summary>
///     Represents a request to create a new user in the system.
/// </summary>
public class CreateUserRequest
{
    /// <summary>
    ///     Gets or sets the username. Must be unique and contain only valid characters.
    /// </summary>
    [Required]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the password. Must meet security requirements.
    /// </summary>
    [Required]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    ///     Gets or sets the email address. Must be a valid email format.
    /// </summary>
    [Required]
    public string Email { get; set; } = string.Empty;
}
