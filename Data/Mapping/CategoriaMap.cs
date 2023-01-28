using API_LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_LojaVirtual.Data.Mapping
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Url)
                .IsRequired()
                .HasColumnName("Url")
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Ativo)
                .IsRequired()
                .HasColumnName("Ativo")
                .HasColumnType("BIT");

            builder.Property(x => x.Excluido)
                .IsRequired()
                .HasColumnName("Excluido")
                .HasColumnType("BIT");
        }
    }
}
