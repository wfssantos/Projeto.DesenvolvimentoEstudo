using Microsoft.EntityFrameworkCore;
using Projeto.DesenvolvimentoEstudo.Domain.Common;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.CompaniesProducts;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.CompaniesSales;

namespace Projeto.DesenvolvimentoEstudo.ORM.Repositories;

public class CompanySaleRepository : ICompanySaleRepository
{
    private readonly DefaultContext _context;

    public CompanySaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<PagedResponse<GetAllCompanySaleResponse>> ListAsync(GetAllCompanySaleRequest filter, CancellationToken cancellationToken = default)
    {
        var query = _context.CompaniesSales.AsNoTracking();

        var totalItems = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalItems / (double)filter.PageSize);

        var items = await query
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(c => new GetAllCompanySaleResponse
            {
                Id = c.Id,
                SaleNumber = c.SaleNumber,
                Status = c.Status,
                CreatedAt= c.CreatedAt,
                UserId = c.UserId,
                User = c.User,
                CompanyId = c.CompanyId,
                Company = c.Company,
                CompanySaleItem = c.CompanySaleItem.Select(i => new CompanySaleItem {
                    Id = i.Id,
                    CompanyProductId = i.CompanyProductId,
                    CompanyProduct = i.CompanyProduct,
                    Quantity = i.Quantity,
                    Discount = i.Discount,
                }).ToList(),
            })
            .ToListAsync(cancellationToken);

        return new PagedResponse<GetAllCompanySaleResponse>
        {
            TotalRecords = totalItems,
            TotalPages = totalPages,
            CurrentPage = filter.PageNumber,
            PageSize = filter.PageSize,
            Items = items
        };
    }
}
