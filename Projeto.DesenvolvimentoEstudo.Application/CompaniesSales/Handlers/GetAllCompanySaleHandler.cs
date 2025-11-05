using AutoMapper;
using MediatR;
using Projeto.DesenvolvimentoEstudo.Application.CompaniesProducts.Commands;
using Projeto.DesenvolvimentoEstudo.Application.CompaniesSales.Commands;
using Projeto.DesenvolvimentoEstudo.Domain.Common;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.CompaniesProducts;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.CompaniesSales;

namespace Projeto.DesenvolvimentoEstudo.Application.CompaniesSales.Handlers;

public class GetAllCompanySaleHandler : IRequestHandler<GetAllCompanySaleCommand, PagedResponse<GetAllCompanySaleResponse>>
{
    private readonly ICompanySaleRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCompanySaleHandler(ICompanySaleRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<GetAllCompanySaleResponse>> Handle(GetAllCompanySaleCommand request, CancellationToken cancellationToken)
    {
        var filtro = _mapper.Map<GetAllCompanySaleRequest>(request.Filter);
        var list = await _repository.ListAsync(filtro, cancellationToken);
        return list;
    }
}
