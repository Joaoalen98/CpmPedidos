using static System.Net.Mime.MediaTypeNames;

namespace CpmPedidos.Domain
{
    public abstract class Imagem : BaseDomain
    {
        public string Nome { get; set; }
        public string NomeArquivo { get; set; }
        public bool Principal { get; set; }
    }
}
