namespace Projeto.DesenvolvimentoEstudo.Application.Companies.Commands;

public class CreateCompanyPhoneCommand
{
    public long Phone { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
}
