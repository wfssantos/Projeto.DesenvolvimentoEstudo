using Projeto.DesenvolvimentoEstudo.Domain.Common;

namespace Projeto.DesenvolvimentoEstudo.Domain.Entities;

public class CompanyEmail : BaseEntity
{
    public CompanyEmail() { }

    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = new();

    public string Email { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
}
