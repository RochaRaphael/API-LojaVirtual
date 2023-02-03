﻿// <auto-generated />
using System;
using API_LojaVirtual.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APILojaVirtual.Migrations
{
    [DbContext(typeof(LojaDataContext))]
    partial class LojaDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_LojaVirtual.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("BIT")
                        .HasColumnName("Ativo");

                    b.Property<bool>("Excluido")
                        .HasColumnType("BIT")
                        .HasColumnName("Excluido");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Nome");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Url");

                    b.HasKey("Id");

                    b.ToTable("Categoria", (string)null);
                });

            modelBuilder.Entity("API_LojaVirtual.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATE")
                        .HasDefaultValue(new DateTime(2023, 2, 3, 19, 13, 2, 240, DateTimeKind.Utc).AddTicks(9173))
                        .HasColumnName("DataPedido");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pedido", (string)null);
                });

            modelBuilder.Entity("API_LojaVirtual.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("BIT")
                        .HasColumnName("Ativo");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<bool>("Excluido")
                        .HasColumnType("BIT")
                        .HasColumnName("Excluido");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Nome");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INT")
                        .HasColumnName("Quantidade");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Url");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("API_LojaVirtual.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("BIT")
                        .HasColumnName("Ativo");

                    b.Property<string>("ChaveVerificacao")
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("ChaveVerificacao");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Email");

                    b.Property<bool>("Excluido")
                        .HasColumnType("BIT")
                        .HasColumnName("Excluido");

                    b.Property<bool?>("IsVerification")
                        .HasColumnType("BIT")
                        .HasColumnName("IsVerification");

                    b.Property<string>("LastToken")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR(MAX)")
                        .HasColumnName("LastToken");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Login");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Senha");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("PedidoItem", b =>
                {
                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("PedidoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("PedidoItem");
                });

            modelBuilder.Entity("API_LojaVirtual.Models.Pedido", b =>
                {
                    b.HasOne("API_LojaVirtual.Models.Usuario", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Pedido_Usuario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("API_LojaVirtual.Models.Produto", b =>
                {
                    b.HasOne("API_LojaVirtual.Models.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Produto_Categoria");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("PedidoItem", b =>
                {
                    b.HasOne("API_LojaVirtual.Models.Produto", null)
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Pedido_ProdutoId");

                    b.HasOne("API_LojaVirtual.Models.Pedido", null)
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Produtoo_PedidoId");
                });

            modelBuilder.Entity("API_LojaVirtual.Models.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("API_LojaVirtual.Models.Usuario", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
