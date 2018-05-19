namespace CatalogoProdutos.Domain.Core.Comandos
{
    public class RespostaComando
    {
        public static RespostaComando Ok = new RespostaComando { Sucesso = true };
        public static RespostaComando Falhar = new RespostaComando { Sucesso = false };

        public RespostaComando(bool sucesso = false)
        {
            Sucesso = sucesso;
        }
        
        public bool Sucesso { get; private set; }
    }
}
