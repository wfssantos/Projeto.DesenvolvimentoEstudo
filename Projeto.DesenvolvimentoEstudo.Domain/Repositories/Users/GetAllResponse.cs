using Projeto.DesenvolvimentoEstudo.Model.Enums;

namespace Projeto.DesenvolvimentoEstudo.Domain.Repositories.Users;

public class GetAllResponse 
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
