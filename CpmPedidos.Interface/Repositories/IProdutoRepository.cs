using CpmPedidos.Domain;

namespace CpmPedidos.Interface
{
    public interface IProdutoRepository
    {
        dynamic Get(string ordem);
        dynamic GetSearch(string text, int pagina, string ordem);
        dynamic Detail(int id);
        dynamic Imagens(int id);
    }
}