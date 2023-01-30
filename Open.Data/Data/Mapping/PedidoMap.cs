using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Open.Infra.Data.Entities;

namespace Open.Infra.Data.Mapping
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.NumeroDoPedido)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.DataDeCriacao)
                .IsRequired();

            builder.Property(p => p.ClienteId)
                .IsRequired();

            builder.HasOne(p => p.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}