using CpmPedidos.Domain;
using CpmPedidos.Interface.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CpmPedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : AppBaseController
    {
        public ProdutoController(IServiceProvider serviceProvider) : base(serviceProvider)
        { }


        [HttpGet]
        public List<Produto> Get()
        {
            var rep = (IProdutoRepository)_serviceProvider.GetService(typeof(IProdutoRepository));
            return rep.Get();
        }
    }
}