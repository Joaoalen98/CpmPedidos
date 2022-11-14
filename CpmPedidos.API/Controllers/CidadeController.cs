using CpmPedidos.Domain;
using CpmPedidos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CpmPedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : AppBaseController
    {

        public CidadeController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        { }


        [HttpGet]
        public dynamic Get()
        {
            var rep = _serviceProvider.GetService<ICidadeRepository>();
            return rep.Get();
        }


        [HttpPost]
        public int Criar(CidadeDTO model)
        {
            var rep = _serviceProvider.GetService<ICidadeRepository>();
            return rep.Criar(model);
        }
    }
}