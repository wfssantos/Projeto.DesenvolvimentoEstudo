namespace Projeto.DesenvolvimentoEstudo.WebAPI.Model.Companies;

public class CreateCompanyPhoneRequest
{
    public Int64 Phone { get; set; } = 0;
    public string Type { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
}
