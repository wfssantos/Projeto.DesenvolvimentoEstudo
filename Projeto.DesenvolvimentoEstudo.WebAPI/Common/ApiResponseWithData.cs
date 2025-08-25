namespace Projeto.DesenvolvimentoEstudo.WebAPI.Common;

public class ApiResponseWithData<T> : ApiResponse
{
    public T? Data { get; set; }
}
