using CpmPedidos.Domain;
using CpmPedidos.Interface.Repositories;

namespace CpmPedidos.Repository.Repositories
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public List<Produto> Get()
        {
            return _dbContext.Produtos
                .Where(x => x.Ativo)
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public List<Produto> GetSearch(string text)
        {
            return _dbContext.Produtos
                .Where(x => x.Ativo && x.Nome.ToUpper().Contains(text.ToUpper())
                || x.Descricao.ToUpper().Contains(text.ToUpper())).ToList();
        }
    }
}