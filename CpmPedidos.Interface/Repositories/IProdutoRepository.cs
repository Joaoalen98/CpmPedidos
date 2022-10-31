using CpmPedidos.Domain;

namespace CpmPedidos.Interface
{
    public interface IProdutoRepository
    {
        dynamic Get();
        dynamic GetSearch(string text, int pagina);
        dynamic Detail(int id);
        dynamic Imagens(int id);
    }
}