using CpmPedidos.Domain;

namespace CpmPedidos.Interface.Repositories
{
    public interface IProdutoRepository
    {
        List<Produto> Get();
        List<Produto> GetSearch(string text, int pagina);
        Produto Detail(int id);
    }
}