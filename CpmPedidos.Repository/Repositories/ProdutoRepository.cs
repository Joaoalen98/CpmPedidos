using CpmPedidos.Domain;
using CpmPedidos.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CpmPedidos.Repository.Repositories
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public List<Produto> Get()
        {
            return _dbContext.Produtos
                .Include(x => x.Categoria)
                .Where(x => x.Ativo)
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public dynamic GetSearch(string text, int pagina)
        {
            var produtos =  _dbContext.Produtos
                .Include(x => x.Categoria)
                .Where(x => x.Ativo && x.Nome.ToUpper().Contains(text.ToUpper())
                || x.Descricao.ToUpper().Contains(text.ToUpper()))
                .Skip(TamanhoPagina * (pagina - 1))
                .Take(TamanhoPagina)
                .ToList();

            var quantidadeProdutos = _dbContext.Produtos.Where(x => x.Ativo && x.Nome.ToUpper().Contains(text.ToUpper())
                || x.Descricao.ToUpper().Contains(text.ToUpper()))
                .Count();

            var quantidadePaginas = quantidadeProdutos / TamanhoPagina;

            if (quantidadePaginas < 1)
            {
                quantidadePaginas = 1;
            }

            return new { produtos, quantidadePaginas };
        }

        public Produto Detail(int id)
        {
            return _dbContext.Produtos
                .Include(x => x.Imagens)
                .Include(x => x.Categoria)
                .Where(x => x.Ativo && x.Id == id)
                .FirstOrDefault();
        }
    }
}