using CpmPedidos.Domain;
using CpmPedidos.Interface;
using Microsoft.EntityFrameworkCore;

namespace CpmPedidos.Repository
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        private void OrdernarPorNome(IQueryable<Produto> query, string ordem)
        {
            if (string.IsNullOrEmpty(ordem) || ordem.ToUpper() == "ASC")
            {
                query = query.OrderBy(x => x.Nome);
            }
            else
            {
                query = query.OrderByDescending(x => x.Nome);
            }
        }
        public ProdutoRepository(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public dynamic Get(string ordem)
        {
            var queryProduto = _dbContext.Produtos
                .Include(x => x.Categoria)
                .Where(x => x.Ativo);
                
            OrdernarPorNome(queryProduto, ordem);

            var queryRetorno = queryProduto.Select(x => new
            {
                x.Nome,
                x.Preco,
                Categoria = x.Categoria.Nome,
                Imagens = x.Imagens.Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.NomeArquivo,
                })
            });

            return queryRetorno.ToList();
        }

        public dynamic GetSearch(string text, int pagina, string ordem)
        {
            var queryProduto = _dbContext.Produtos
                .Include(x => x.Categoria)
                .Where(x => x.Ativo && x.Nome.ToUpper().Contains(text.ToUpper())
                || x.Descricao.ToUpper().Contains(text.ToUpper()));

            OrdernarPorNome(queryProduto, ordem);

            var queryRetorno = queryProduto.Skip(TamanhoPagina * (pagina - 1))
                .Take(TamanhoPagina)
                .Select(x => new
                {
                    x.Nome,
                    x.Preco,
                    Categoria = x.Categoria.Nome,
                    Imagens = x.Imagens.Select(x => new
                    {
                        x.Id,
                        x.Nome,
                        x.NomeArquivo,
                    })
                });

            var produtos = queryRetorno.ToList();


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

        public dynamic Detail(int id)
        {
            return _dbContext.Produtos
                .Include(x => x.Imagens)
                .Include(x => x.Categoria)
                .Where(x => x.Ativo && x.Id == id)
                .Select(x => new
                {
                    x.Id,
                    x.Nome,
                    x.Codigo,
                    x.Descricao,
                    x.Preco,
                    Categoria = new
                    {
                        x.Categoria.Id,
                        x.Categoria.Nome,
                    },
                    Imagens = x.Imagens.Select(x => new
                    {
                        x.Id,
                        x.Nome,
                        x.NomeArquivo,
                    })
                })
                .FirstOrDefault();
        }

        public dynamic Imagens(int id)
        {
            return _dbContext.Produtos
                .Include(x => x.Imagens)
                .Where(x => x.Ativo && x.Id == id)
                .SelectMany(x => x.Imagens, (produto, imagem) => new
                {
                    IdProduto = produto.Id,
                    imagem.Id,
                    imagem.Nome,
                    imagem.NomeArquivo,
                })
                .FirstOrDefault();
        }
    }
}