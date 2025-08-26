using Projeto.DesenvolvimentoEstudo.Domain.Common;

namespace Projeto.DesenvolvimentoEstudo.Domain.Entities;

public class CompanyAddress : BaseEntity
{
    public CompanyAddress() { }

    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = new();

    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}
