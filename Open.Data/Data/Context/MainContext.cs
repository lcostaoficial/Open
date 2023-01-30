using Microsoft.EntityFrameworkCore;
using Open.Infra.Data.Entities;
using Open.Infra.Data.Mapping;

namespace Open.Infra.Data.Context
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ItemDoPedido> ItensDosPedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ItemDoPedidoMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
        }
    }
}