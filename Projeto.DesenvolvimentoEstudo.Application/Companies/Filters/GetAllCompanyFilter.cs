namespace Projeto.DesenvolvimentoEstudo.Application.Companies.Filters;

public class GetAllCompanyFilter
{
    public string Name { get; set; } = string.Empty;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
