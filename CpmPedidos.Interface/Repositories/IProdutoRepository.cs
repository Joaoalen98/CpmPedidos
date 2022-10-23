using CpmPedidos.Domain;

namespace CpmPedidos.Interface.Repositories
{
    public interface IProdutoRepository
    {
        List<Produto> Get();
        dynamic GetSearch(string text, int pagina);
        Produto Detail(int id);
    }
}