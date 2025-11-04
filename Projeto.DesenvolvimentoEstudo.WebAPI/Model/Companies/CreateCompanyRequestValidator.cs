using FluentValidation;
using Projeto.DesenvolvimentoEstudo.Domain.Validation;

namespace Projeto.DesenvolvimentoEstudo.WebAPI.Model.Companies;

/// <summary>
///     Validator for CreateUserRequest that defines validation rules for user creation.
/// </summary>
public class CreateCompanyRequestValidator : AbstractValidator<CreateCompanyRequest>
{
    /// <summary>
    ///     Initializes a new instance of the CreateUserRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    ///     Validation rules include:
    ///     - Name: Required, length between 1 and 100 characters

    /// </remarks>
    public CreateCompanyRequestValidator()
    {
        RuleFor(user => user.Name).NotEmpty().Length(1, 100);

        RuleForEach(c => c.Phones).ChildRules(phone =>
        {
            phone.RuleFor(p => p.Phone)
                .NotEmpty().WithMessage("Phone number is required.");

            phone.RuleFor(p => p.Type)
                .MaximumLength(100);

            phone.RuleFor(p => p.Contact)
                .MaximumLength(100);
        });

        RuleForEach(c => c.Addresses).ChildRules(address =>
        {
            address.RuleFor(a => a.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(255);

            address.RuleFor(a => a.City)
                .MaximumLength(100);

            address.RuleFor(a => a.Country)
                .MaximumLength(100);

            address.RuleFor(a => a.Code)
                .MaximumLength(100);
        });

        RuleForEach(c => c.Emails).ChildRules(email =>
        {
            email.RuleFor(e => e.Email)
                .SetValidator(new EmailValidator());

            email.RuleFor(e => e.Contact)
                .MaximumLength(100);
        });
    }
}
