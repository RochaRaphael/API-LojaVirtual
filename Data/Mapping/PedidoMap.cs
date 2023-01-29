using API_LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_LojaVirtual.Data.Mapping
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
            
            builder.Property(x => x.DataPedido)
                .IsRequired()
                .HasColumnName("DataPedido")
                .HasColumnType("DATE")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

            builder
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Pedidos)
                .HasConstraintName("FK_Pedido_Usuario");

            builder
               .HasMany(x => x.Produtos)
               .WithMany(x => x.Pedidos)
               .UsingEntity<Dictionary<string, object>>(
                   "PedidoItem",
                   pedido => pedido
                       .HasOne<Produto>()
                       .WithMany()
                       .HasForeignKey("PedidoId")
                       .HasConstraintName("FK_Pedido_ProdutoId"),
                    produto => produto
                       .HasOne<Pedido>()
                       .WithMany()
                       .HasForeignKey("ProdutoId")
                       .HasConstraintName("FK_Produtoo_PedidoId"));
                    


        }
    }
}
