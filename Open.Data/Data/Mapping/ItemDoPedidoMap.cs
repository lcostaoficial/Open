using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Open.Infra.Data.Entities;

namespace Open.Infra.Data.Mapping
{
    public class ItemDoPedidoMap : IEntityTypeConfiguration<ItemDoPedido>
    {
        public void Configure(EntityTypeBuilder<ItemDoPedido> builder)
        {
            builder.ToTable("ItensDoPedido");

            builder.HasKey(ip => ip.Id);

            builder.Property(ip => ip.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(ip => ip.ValorUnitario)
                .HasColumnType("decimal(12,2)")
                .HasPrecision(12, 2)
                .IsRequired();

            builder.Property(ip => ip.Quantidade)
                .IsRequired();

            builder.Property(ip => ip.PedidoId)
                .IsRequired();

            builder.HasOne(ip => ip.Pedido)
                .WithMany(p => p.ItensDoPedido)
                .HasForeignKey(ip => ip.PedidoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}