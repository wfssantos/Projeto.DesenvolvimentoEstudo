using MediatR;
using Projeto.DesenvolvimentoEstudo.Application.Users.Commands;
using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Users;

namespace Projeto.DesenvolvimentoEstudo.Application.Users.Queries;

public class ListUserQuery : IRequest<IEnumerable<GetAllResponse>>
{
    public GetAllCommand _filter { get; set; }

    public ListUserQuery(GetAllCommand filter)
    {
        _filter = filter;
    }
}
