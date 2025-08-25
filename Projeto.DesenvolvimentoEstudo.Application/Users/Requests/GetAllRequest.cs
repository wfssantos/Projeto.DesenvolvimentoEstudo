using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Users;

namespace Projeto.DesenvolvimentoEstudo.Application.Users.Requests;

public class GetAllRequest : IGetAllRequest
{
    public string Email { get; set; } = string.Empty;
}
