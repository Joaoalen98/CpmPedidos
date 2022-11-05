using CpmPedidos.Domain;
using CpmPedidos.Interface;
using Microsoft.EntityFrameworkCore;

namespace CpmPedidos.Repository.Repositories
{
    public class PedidoReposiroty : BaseRepository, IPedidoRepository
    {
        public PedidoReposiroty(ApplicationDbContext dbContext) : base(dbContext)
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
    }
}