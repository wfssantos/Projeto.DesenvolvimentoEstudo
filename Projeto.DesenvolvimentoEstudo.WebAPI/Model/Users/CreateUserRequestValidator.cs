using FluentValidation;
using Projeto.DesenvolvimentoEstudo.Domain.Validation;

namespace Projeto.DesenvolvimentoEstudo.WebAPI.Model.Users;

/// <summary>
///     Validator for CreateUserRequest that defines validation rules for user creation.
/// </summary>
public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    /// <summary>
    ///     Initializes a new instance of the CreateUserRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    ///     Validation rules include:
    ///     - Email: Must be valid format (using EmailValidator)
    ///     - Username: Required, length between 3 and 50 characters
    ///     - Password: Must meet security requirements (using PasswordValidator)
    ///     - Phone: Must match international format (+X XXXXXXXXXX)
    ///     - Status: Cannot be Unknown
    ///     - Role: Cannot be None
    /// </remarks>
    public CreateUserRequestValidator()
    {
        RuleFor(user => user.Email).SetValidator(new EmailValidator());
        RuleFor(user => user.Username).NotEmpty().Length(3, 50);
        RuleFor(user => user.Password).SetValidator(new PasswordValidator());
    }
}
