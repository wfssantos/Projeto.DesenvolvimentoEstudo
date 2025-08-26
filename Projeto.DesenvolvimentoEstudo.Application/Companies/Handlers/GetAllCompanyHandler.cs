using AutoMapper;
using MediatR;
using Projeto.DesenvolvimentoEstudo.Application.Companies.Commands;
using Projeto.DesenvolvimentoEstudo.Domain.Common;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Companies;

namespace Projeto.DesenvolvimentoEstudo.Application.Companies.Handlers;

public class GetAllCompanyHandler : IRequestHandler<GetAllCompanyCommand, PagedResponse<GetAllCompanyResponse>>
{
    private readonly ICompanyRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCompanyHandler(ICompanyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<GetAllCompanyResponse>> Handle(GetAllCompanyCommand request, CancellationToken cancellationToken)
    {
        var filtro = _mapper.Map<GetAllCompanyRequest>(request.Filter);
        var list = await _repository.ListAsync(filtro);
        return list;
    }
}
