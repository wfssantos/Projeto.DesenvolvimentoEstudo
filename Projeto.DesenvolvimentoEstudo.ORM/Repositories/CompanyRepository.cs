using Microsoft.EntityFrameworkCore;
using Projeto.DesenvolvimentoEstudo.Domain.Common;
using Projeto.DesenvolvimentoEstudo.Domain.Entities;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Companies;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Users;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Linq;

namespace Projeto.DesenvolvimentoEstudo.ORM.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly DefaultContext _context;

    public CompanyRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<PagedResponse<GetAllCompanyResponse>> ListAsync(GetAllCompanyRequest filter)
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
            .ToListAsync(); //cancellationToken

        return new PagedResponse<GetAllCompanyResponse>
        {
            TotalRecords = totalItems,
            TotalPages = totalPages,
            CurrentPage = filter.PageNumber,
            PageSize = filter.PageSize,
            Items = items
        };
    }
}
