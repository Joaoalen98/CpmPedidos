using CpmPedidos.Domain;

namespace CpmPedidos.Interface
{
    public interface IProdutoRepository
    {
        List<Produto> Get();
        dynamic GetSearch(string text, int pagina);
        Produto Detail(int id);
    }
}