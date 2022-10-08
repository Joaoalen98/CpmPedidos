using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CpmPedidos.Repository
{
    public class ClienteMap : BaseDomainMap<Cliente>
    {
        ClienteMap() :base("tb_cliente") { }

        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);
        }
    }
}
