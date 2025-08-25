using AutoMapper;
using MediatR;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Users;

namespace Projeto.DesenvolvimentoEstudo.Application.Users.Queries;

public class ListUserQueryHandler : IRequestHandler<ListUserQuery, IEnumerable<GetAllResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
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
