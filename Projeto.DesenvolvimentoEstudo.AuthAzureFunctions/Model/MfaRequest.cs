namespace Projeto.DesenvolvimentoEstudo.APIAuthAzureFunctions.Model
{
    public class MfaRequest
    {
        public string MfaToken { get; set; } = "";
        public string Code { get; set; } = "";
    }
}
