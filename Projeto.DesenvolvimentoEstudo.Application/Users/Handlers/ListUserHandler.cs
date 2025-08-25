using AutoMapper;
using MediatR;
using Projeto.DesenvolvimentoEstudo.Application.Users.Queries;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Users;

namespace Projeto.DesenvolvimentoEstudo.Application.Users.Handlers;

public class ListUserHandler : IRequestHandler<ListUserQuery, IEnumerable<GetAllResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ListUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllResponse>> Handle(ListUserQuery request, CancellationToken cancellationToken)
    {
        var listUsers = await _userRepository.ListAsync(request._filter);
        return _mapper.Map<IEnumerable<GetAllResponse>>(listUsers);
    }
}
