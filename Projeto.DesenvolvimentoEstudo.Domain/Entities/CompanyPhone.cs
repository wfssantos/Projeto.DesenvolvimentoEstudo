using Projeto.DesenvolvimentoEstudo.Domain.Common;

namespace Projeto.DesenvolvimentoEstudo.Domain.Entities;

public class CompanyPhone : BaseEntity
{
    public CompanyPhone() { }

    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = new();

    public Int64 Phone { get; set; } = 0;
    public string Type { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
}
