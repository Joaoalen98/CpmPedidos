using CpmPedidos.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CpmPedidos.Repository
{
    public class CidadeMap : BaseDomainMap<Cidade>
    {
        CidadeMap() :base("tb_cidade") { }

        public override void Configure(EntityTypeBuilder<Cidade> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Uf).HasColumnName("uf").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Ativo).HasColumnName("ativo").HasMaxLength(100).IsRequired();
        }
    }
}
