using Projeto.DesenvolvimentoEstudo.WebBlazor.Enums;

namespace Projeto.DesenvolvimentoEstudo.WebBlazor.Models;

public class CompanyProduct
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public int StockQuantity { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = null;
    public ProductStatus Status { get; set; }
}
