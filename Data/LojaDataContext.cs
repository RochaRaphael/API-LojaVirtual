using Microsoft.EntityFrameworkCore;
using API_LojaVirtual.Models;
using API_LojaVirtual.Data.Mapping;

namespace API_LojaVirtual.Data
{
    public class LojaDataContext : DbContext
    {
        public LojaDataContext(DbContextOptions<LojaDataContext> options)
            : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
        }


    }
}
