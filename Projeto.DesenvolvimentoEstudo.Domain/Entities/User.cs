using Projeto.DesenvolvimentoEstudo.Domain.Common;
using Projeto.DesenvolvimentoEstudo.Model.Enums;

namespace Projeto.DesenvolvimentoEstudo.Domain.Entities;

/// <summary>
/// Represents a user in the system with authentication and profile information.
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the User class.
    /// </summary>
    public User()
    {
    }

    /// <summary>
    /// Gets the user's full name.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets the user's email address.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets the hashed password for authentication.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets the user's current status.
    /// </summary>
    public UserStatus Status { get; set; }

    /// <summary>
    /// Gets the date and time when the user was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the user's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Activates the user account when create.
    /// </summary>
    public void Create()
    {
        Status = UserStatus.Active;
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Activates the user account.
    /// </summary>
    public void Activate()
    {
        Status = UserStatus.Active;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Deactivates the user account.
    /// </summary>
    public void Deactivate()
    {
        Status = UserStatus.Inactive;
        UpdatedAt = DateTime.UtcNow;
    }

    // TODO: implement validation
    //public ValidationResultDetail Validate()
    //{
    //    var validator = new UserValidator();
    //    var result = validator.Validate(this);
    //    return new ValidationResultDetail
    //    {
    //        IsValid = result.IsValid,
    //        Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
    //    };
    //}
}
