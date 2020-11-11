namespace CuboMagico.Domain.ValueObjects
{
    public class Retorno 
    {
        public int StatusCode { get; set; }
        public string Mensagem { get; set; }
        public object Dados { get; set; }
    }
}