using CpmPedidos.Domain;
using CpmPedidos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CpmPedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : AppBaseController
    {

        public PedidoController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        { }


        [HttpGet("ticket-maximo")]
        public decimal TickerMaximo()
        {
            var rep = _serviceProvider.GetService<IPedidoRepository>();
            return rep.TicketMaximo();
        }


        [HttpGet("por-cliente")]
        public dynamic PedidosClientes()
        {
            var rep = _serviceProvider.GetService<IPedidoRepository>();
            return rep.PedidosClientes();
        }

        [HttpPost]
        public string SalvarPedido(PedidoDTO pedido)
        {
            var rep = _serviceProvider.GetService<IPedidoRepository>();
            return rep.SalvarPedido(pedido);
        }
    }
}