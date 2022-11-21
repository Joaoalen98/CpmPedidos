using CpmPedidos.Domain;
using CpmPedidos.Interface;
using Microsoft.EntityFrameworkCore;

namespace CpmPedidos.Repository
{
    public class PedidoRepository : BaseRepository, IPedidoRepository
    {

        private string GetProximoNumero()
        {
            var ret = 1.ToString("0000");
            var ultimoNumero = _dbContext.Pedidos.Max(x => x.Numero);

            if (!string.IsNullOrEmpty(ultimoNumero))
            {
                ret = (Convert.ToInt32(ultimoNumero) + 1).ToString("00000");
            }

            return ret;
        }

        public PedidoRepository(ApplicationDbContext dbContext) : base(dbContext)
        { }



        public decimal TicketMaximo()
        {
            var hoje = DateTime.Today;

            return _dbContext.Pedidos
                .Where(x => x.CriadoEm.Date == hoje)
                .Max(x => (decimal?)x.ValorTotal) ?? 0;
        }

        public dynamic PedidosClientes()
        {
            var hoje = DateTime.Today;
            var inicioMes = new DateTime(hoje.Year, hoje.Month, 1);
            var finalMes = new DateTime(hoje.Year, hoje.Month, DateTime.DaysInMonth(hoje.Year, hoje.Month));

            return _dbContext.Pedidos
                .Where(x => x.CriadoEm.Date >= inicioMes && x.CriadoEm <= finalMes)
                .GroupBy(pedidos => new { pedidos.IdCliente, pedidos.Cliente.Nome },
                (chave, pedidos) => new
                {
                    Cliente = chave.Nome,
                    Pedidos = pedidos.Count(),
                    Total = pedidos.Sum(p => p.ValorTotal),
                })
                .ToList();
        }

        public string SalvarPedido(PedidoDTO pedido)
        {
            var ret = "";

            try
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var entity = new Pedido
                        {
                            Numero = GetProximoNumero(),
                            IdCliente = pedido.IdCliente,
                            CriadoEm = DateTime.Now,
                            Produtos = new List<ProdutoPedido>(),
                        };

                        var valorTotal = 0m;

                        foreach (var prodPed in pedido.Produtos)
                        {
                            var precoProduto = _dbContext.Produtos
                                .Where(x => x.Id == prodPed.IdProduto)
                                .Select(x => x.Preco)
                                .FirstOrDefault();

                            if (precoProduto > 0)
                            {
                                valorTotal += prodPed.Quantidade * precoProduto;
                                entity.Produtos.Add(new ProdutoPedido
                                {
                                    IdProduto = prodPed.IdProduto,
                                    Quantidade = prodPed.Quantidade,
                                    Preco = precoProduto,
                                });
                            }
                        }

                        entity.ValorTotal = valorTotal;

                        _dbContext.Pedidos.Add(entity);
                        _dbContext.SaveChanges();
                        transaction.Commit();

                        ret = entity.Numero;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return ret;
        }
    }
}