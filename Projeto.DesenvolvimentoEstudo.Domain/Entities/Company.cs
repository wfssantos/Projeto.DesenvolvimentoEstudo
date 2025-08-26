using Projeto.DesenvolvimentoEstudo.Domain.Common;

namespace Projeto.DesenvolvimentoEstudo.Domain.Entities;

public class Company : BaseEntity
{
    /// <summary>
    /// Initializes a new instance of the Company class.
    /// </summary>
    public Company() { }

    public string Name { get; set; } = string.Empty;

    public ICollection<CompanyPhone> Phones { get; set; } = new List<CompanyPhone>();

    public ICollection<CompanyAddress> Addresses { get; set; } = new List<CompanyAddress>();

    public ICollection<CompanyEmail> Emails { get; set; } = new List<CompanyEmail>();
}
