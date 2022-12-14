using static System.Net.Mime.MediaTypeNames;

namespace CpmPedidos.Domain
{
    public class Imagem : BaseDomain
    {
        public string Nome { get; set; }
        public string NomeArquivo { get; set; }
        public bool Principal { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
