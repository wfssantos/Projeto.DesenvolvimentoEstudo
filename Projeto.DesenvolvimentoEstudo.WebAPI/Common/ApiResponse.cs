namespace Projeto.DesenvolvimentoEstudo.WebAPI.Common;

public class ApiResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;

    //TODO: Implement errors details
    //public IEnumerable<ValidationErrorDetail> Errors { get; set; } = [];
}
