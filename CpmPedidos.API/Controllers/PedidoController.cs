using Microsoft.AspNetCore.Mvc;

namespace CpmPedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : AppBaseController
    {
        private readonly IServiceProvider _serviceProvider;

        public PedidoController(IServiceProvider serviceProvider)
            :base(serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}