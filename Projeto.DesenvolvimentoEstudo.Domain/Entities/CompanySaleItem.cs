using Projeto.DesenvolvimentoEstudo.Domain.Common;

namespace Projeto.DesenvolvimentoEstudo.Domain.Entities;

public class CompanySaleItem : BaseEntity
{
    public CompanySaleItem() { }

    public Guid CompanySaleId { get; set; }
    public CompanySale? CompanySale { get; set; } 

    public Guid CompanyProductId { get; set; }
    public CompanyProduct? CompanyProduct { get; set; }

    public int Quantity { get; set; }
    public decimal? Discount { get; set; }

    /// <summary>
    /// Gets the total price for this item after applying the discount.
    /// </summary>
    public decimal TotalItemPrice => CompanyProduct.Price * Quantity - (Discount ?? 0m);
}
