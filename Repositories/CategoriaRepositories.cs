﻿using API_LojaVirtual.Data;
using API_LojaVirtual.Models;
using API_LojaVirtual.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_LojaVirtual.Repositories
{
    public class CategoriaRepositories
    {
        private readonly LojaDataContext context;

        public CategoriaRepositories(LojaDataContext context)
        {
            this.context = context;
        }

        public async Task<List<MostrarPorNomeViewModel>> ListaCategoriasTemProdutosAsync()
        {
            var produto = await context
              .Produtos
              .AsNoTracking()
              .Include(x => x.Categoria)
              .Where(x => x.Quantidade > 0 && x.Ativo == true)
              .Select(x => new MostrarPorNomeViewModel
              {
                  Nome = x.Categoria.Nome,
              })
              .Distinct()
              .ToListAsync();

            return produto;
        }

        public async Task<List<ProdutoViewModel>> PesquisaProdutosUrlCategoriasAsync(string url)
        {
            var categoria = await context
                .Categorias
                .AsNoTracking()
                .Include(x => x.Produtos)
                .FirstOrDefaultAsync(x => x.Url == url);
            
            if (categoria == null || categoria.Ativo == false)
                return null;

            var produtosDessaCategoia = await context
                .Produtos
                .AsNoTracking()
                .Include(x => x.Categoria)
                .Where(x => x.Categoria.Url == url)
                .Select(x => new ProdutoViewModel
                {
                    Nome = x.Nome,
                    Url = x.Url,
                    Quantidade = x.Quantidade,
                    Ativo = x.Ativo,
                    Excluido = x.Excluido
                }
                )
                .ToListAsync();
            
            return produtosDessaCategoia;

        }
        
    }
}
