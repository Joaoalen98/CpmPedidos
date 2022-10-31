using CpmPedidos.Domain;
using CpmPedidos.Interface;
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
        public dynamic Get()
        {
            var rep = _serviceProvider.GetService<IProdutoRepository>();
            return rep.Get();
        }

        [HttpGet("search/{text}/{pagina}")]
        public dynamic GetSearch(string text, int pagina = 1)
        {
            var rep = _serviceProvider.GetService<IProdutoRepository>();
            return rep.GetSearch(text, pagina);
        }

        [HttpGet("{id}")]
        public dynamic Detail(int? id)
        {
            if ((id ?? 0) > 0)
            {
                var rep = _serviceProvider.GetService<IProdutoRepository>();
                return rep.Detail(id.Value);
            }
            else
            {
                return null;
            }
        }


        [HttpGet("{id}/imagens")]
        public dynamic Imagens(int? id)
        {
            if ((id ?? 0) > 0)
            {
                var rep = _serviceProvider.GetService<IProdutoRepository>();
                return rep.Imagens(id.Value);
            }
            else
            {
                return null;
            }
        }
    }
}