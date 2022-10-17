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
            var rep = _serviceProvider.GetService<IProdutoRepository>();
            return rep.Get();
        }

        [HttpGet("search/{text}")]
        public IEnumerable<Produto> GetSearch(string text)
        {
            var rep = _serviceProvider.GetService<IProdutoRepository>();
            return rep.GetSearch(text);
        }

        [HttpGet("{id}")]
        public Produto Detail(int? id)
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
    }
}