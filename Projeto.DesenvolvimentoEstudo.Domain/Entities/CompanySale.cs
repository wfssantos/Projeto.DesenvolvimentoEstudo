using Projeto.DesenvolvimentoEstudo.Domain.Common;
using Projeto.DesenvolvimentoEstudo.Domain.Enums;

namespace Projeto.DesenvolvimentoEstudo.Domain.Entities;

public class CompanySale : BaseEntity
{
    public CompanySale() { }

    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = new();

    public Guid UserId { get; set; }
    public User User { get; set; } = new();

    public List<CompanySaleItem> CompanySaleItem { get; set; } = new();

    public int SaleNumber { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public SaleStatus Status { get; set; }

    /// <summary>
    /// Gets the total price with all itens and after applied disconts
    /// </summary>
    public decimal TotalAmount => CompanySaleItem.Sum(i => i.TotalItemPrice);
}
