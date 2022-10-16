using CpmPedidos.Domain;
using CpmPedidos.Interface.Repositories;

namespace CpmPedidos.Repository.Repositories
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProdutoRepository(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public List<Produto> Get()
        {
            return _dbContext.Produtos.ToList();
        }
    }
}