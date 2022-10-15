namespace CpmPedidos.Domain
{
    public class ImagemProduto
    {
        public int IdImagem { get; set; }
        public Imagem Imagem { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
    }
}