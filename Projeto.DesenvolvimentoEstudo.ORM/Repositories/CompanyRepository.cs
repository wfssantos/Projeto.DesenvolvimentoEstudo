using Microsoft.EntityFrameworkCore;
using Projeto.DesenvolvimentoEstudo.Domain.Common;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Companies;

namespace Projeto.DesenvolvimentoEstudo.ORM.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly DefaultContext _context;

    public CompanyRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<PagedResponse<GetAllCompanyResponse>> ListAsync(GetAllCompanyRequest filter, CancellationToken cancellationToken = default)
    {
        var query = _context.Companies.AsNoTracking();

        if (!string.IsNullOrEmpty(filter.Name))
        {
            query = query.Where(u => u.Name.Contains(filter.Name));
        }

        var totalItems = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalItems / (double)filter.PageSize);

        var items = await query
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(c => new GetAllCompanyResponse {
                Id = c.Id,
                Name = c.Name,
            })
            .ToListAsync(cancellationToken);

        return new PagedResponse<GetAllCompanyResponse>
        {
            TotalRecords = totalItems,
            TotalPages = totalPages,
            CurrentPage = filter.PageNumber,
            PageSize = filter.PageSize,
            Items = items
        };
    }

    public async Task<Company> CreateAsync(Company company, CancellationToken cancellationToken = default)
    {
        await _context.Companies.AddAsync(company, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return company;
    }
}
