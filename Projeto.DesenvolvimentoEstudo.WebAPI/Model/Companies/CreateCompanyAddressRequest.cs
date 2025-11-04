namespace Projeto.DesenvolvimentoEstudo.WebAPI.Model.Companies;

public class CreateCompanyAddressRequest
{
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}
