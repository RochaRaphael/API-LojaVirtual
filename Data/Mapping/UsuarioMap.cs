using API_LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_LojaVirtual.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x =>x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("VARCHAR")
                .HasMaxLength(256);

            builder.Property(x => x.Login)
                .IsRequired()
                .HasColumnName("Login")
                .HasColumnType("VARCHAR")
                .HasMaxLength(256);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(256);

            builder.Property(x => x.Senha)
                .IsRequired()
                .HasColumnName("Senha")
                .HasColumnType("VARCHAR")
                .HasMaxLength(256);

            builder.Property(x => x.ChaveVerificacao)
                .HasColumnName("ChaveVerificacao")
                .HasColumnType("VARCHAR")
                .HasMaxLength(256);

            builder.Property(x => x.LastToken)
                .HasColumnName("LastToken")
                .HasColumnType("NVARCHAR(MAX)")
                .HasMaxLength(256);

            builder.Property(x => x.IsVerification)
                .HasColumnName("IsVerification")
                .HasColumnType("BIT");

            builder.Property(x => x.Ativo)
                .HasColumnName("Ativo")
                .HasColumnType("BIT");

            builder.Property(x => x.Excluido)
                .HasColumnName("Excluido")
                .HasColumnType("BIT");
        }
    }
}
