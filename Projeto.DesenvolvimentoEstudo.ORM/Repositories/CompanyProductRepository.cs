using Microsoft.EntityFrameworkCore;
using Projeto.DesenvolvimentoEstudo.Domain.Common;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.CompaniesProducts;

namespace Projeto.DesenvolvimentoEstudo.ORM.Repositories;

public class CompanyProductRepository : ICompanyProductRepository
{
    private readonly DefaultContext _context;

    public CompanyProductRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<PagedResponse<GetAllCompanyProductResponse>> ListAsync(GetAllCompanyProductRequest filter, CancellationToken cancellationToken = default)
    {
        var query = _context.CompaniesProducts.AsNoTracking();

        var totalItems = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalItems / (double)filter.PageSize);

        var items = await query
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(c => new GetAllCompanyProductResponse
            {                
                Id = c.Id,
                CompanyId = c.CompanyId,
                Company = c.Company,
                Name = c.Name,
                Description = c.Description,
                Price = c.Price,
                StockQuantity = c.StockQuantity,
                CreatedAt = c.CreatedAt,
                UpdatedAt =c.UpdatedAt,
                Status = c.Status
            })
            .ToListAsync(cancellationToken);

        return new PagedResponse<GetAllCompanyProductResponse>
        {
            TotalRecords = totalItems,
            TotalPages = totalPages,
            CurrentPage = filter.PageNumber,
            PageSize = filter.PageSize,
            Items = items
        };
    }
}
