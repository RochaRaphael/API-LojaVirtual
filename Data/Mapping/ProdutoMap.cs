using API_LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_LojaVirtual.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(256);

            builder.Property(x => x.Url)
                .IsRequired()
                .HasColumnName("Url")
                .HasColumnType("VARCHAR")
                .HasMaxLength(256);

            builder.Property(x => x.Quantidade)
                .IsRequired()
                .HasColumnName("Quantidade")
                .HasColumnType("INT");

            builder.Property(x => x.Ativo)
                .IsRequired()
                .HasColumnName("Ativo")
                .HasColumnType("BIT");

            builder.Property(x => x.Excluido)
                .IsRequired()
                .HasColumnName("Excluido")
                .HasColumnType("BIT");

            builder
                .HasOne(x => x.Categoria)
                .WithMany(x => x.Produtos)
                .HasConstraintName("FK_Produto_Categoria");

        }
    }
}
