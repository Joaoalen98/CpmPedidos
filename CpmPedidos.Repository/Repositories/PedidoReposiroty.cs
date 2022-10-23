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
    }
}