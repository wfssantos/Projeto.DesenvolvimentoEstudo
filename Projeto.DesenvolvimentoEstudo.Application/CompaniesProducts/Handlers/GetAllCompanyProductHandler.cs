using AutoMapper;
using MediatR;
using Projeto.DesenvolvimentoEstudo.Application.CompaniesProducts.Commands;
using Projeto.DesenvolvimentoEstudo.Domain.Common;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.CompaniesProducts;

namespace Projeto.DesenvolvimentoEstudo.Application.CompaniesProducts.Handlers;

public class GetAllCompanyProductHandler : IRequestHandler<GetAllCompanyProductCommand, PagedResponse<GetAllCompanyProductResponse>>
{
    private readonly ICompanyProductRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCompanyProductHandler(ICompanyProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<GetAllCompanyProductResponse>> Handle(GetAllCompanyProductCommand request, CancellationToken cancellationToken)
    {
        var filtro = _mapper.Map<GetAllCompanyProductRequest>(request.Filter);
        var list = await _repository.ListAsync(filtro, cancellationToken);
        return list;
    }
}
