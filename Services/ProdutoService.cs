using API_LojaVirtual.Repositories;
using API_LojaVirtual.ViewModels;

namespace API_LojaVirtual.Services
{
    public class ProdutoService
    {
        private readonly ProdutoRepositorio produtoRepositorio;

        public ProdutoService(ProdutoRepositorio produtoRepositorio)
        {
            this.produtoRepositorio = produtoRepositorio;
        }

        public async Task<ProdutoViewModel> PesquisaProdutoUrl(string url)
        {
            var produto = await produtoRepositorio.PesquisaProdutoUrl(url);

            if (produto.Ativo == false)
                return null;

            return await produtoRepositorio.PesquisaProdutoUrl(url); ;
        }
    }
}
