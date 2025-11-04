using Projeto.DesenvolvimentoEstudo.Domain.Common;
using Projeto.DesenvolvimentoEstudo.Domain.Enums;

namespace Projeto.DesenvolvimentoEstudo.Domain.Entities;

public class CompanyProduct : BaseEntity
{
    public CompanyProduct() { }

    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = new();

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public int StockQuantity { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = null;
    public ProductStatus Status { get; set; }
}
