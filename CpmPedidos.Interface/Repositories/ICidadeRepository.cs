using CpmPedidos.Domain;

namespace CpmPedidos.Interface
{
    public interface ICidadeRepository
    {
        dynamic Get();
        int Criar(CidadeDTO model);
    }
}
