using Projeto.DesenvolvimentoEstudo.Domain.Entities;

namespace Projeto.DesenvolvimentoEstudo.WebAPI.Model.Companies;

public class CreateCompanyRequest
{
    public string Name { get; set; } = string.Empty;

    public ICollection<CreateCompanyPhoneRequest> Phones { get; set; } = new List<CreateCompanyPhoneRequest>();
    public ICollection<CreateCompanyAddressRequest> Addresses { get; set; } = new List<CreateCompanyAddressRequest>();
    public ICollection<CreateCompanyEmailRequest> Emails { get; set; } = new List<CreateCompanyEmailRequest>();
}
