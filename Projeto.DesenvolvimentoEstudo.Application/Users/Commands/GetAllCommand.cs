using Projeto.DesenvolvimentoEstudo.Domain.Repositories.Users;

namespace Projeto.DesenvolvimentoEstudo.Application.Users.Commands;

public class GetAllCommand : IGetAllRequest
{
    public string Email { get; set; } = string.Empty;
}
