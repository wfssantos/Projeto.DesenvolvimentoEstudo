using MediatR;
using Projeto.DesenvolvimentoEstudo.Application.Users.Requests;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Users;

namespace Projeto.DesenvolvimentoEstudo.Application.Users.Queries;

public class ListUserQuery : IRequest<IEnumerable<GetAllResponse>>
{
    public GetAllRequest _filter { get; set; }

    public ListUserQuery(GetAllRequest filter)
    {
        _filter = filter;
    }
}
