using MediatR;
using Projeto.DesenvolvimentoEstudo.Application.Companies.Response;

namespace Projeto.DesenvolvimentoEstudo.Application.Companies.Commands;

public class CreateCompanyCommand : IRequest<CreateCompanyCommandResponse>
{
    public string Name { get; set; } = string.Empty;

    public ICollection<CreateCompanyPhoneCommand> Phones { get; set; } = new List<CreateCompanyPhoneCommand>();
    public ICollection<CreateCompanyAddressCommand> Addresses { get; set; } = new List<CreateCompanyAddressCommand>();
    public ICollection<CreateCompanyEmailCommand> Emails { get; set; } = new List<CreateCompanyEmailCommand>();
}
