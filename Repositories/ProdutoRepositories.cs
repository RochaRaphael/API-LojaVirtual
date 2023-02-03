using API_LojaVirtual.Data;
using API_LojaVirtual.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace API_LojaVirtual.Repositories
{
    public class ProdutoRepositories
    {
        private readonly LojaDataContext context;
        public ProdutoRepositories(LojaDataContext context)
        {
            this.context = context;
        }

        public async Task<ProdutoViewModel> PesquisaProdutoUrlAsync(string url)
        {
            var x = await context
               .Produtos
               .AsNoTracking()
               .FirstOrDefaultAsync(p => p.Url == url);

            var produto = new ProdutoViewModel
            {
                Nome = x.Nome,
                Url = x.Url,
                Quantidade = x.Quantidade,
                Ativo = x.Ativo,
                Excluido = x.Excluido
            };

            return produto;
        }
    }
}
