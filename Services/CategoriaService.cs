using API_LojaVirtual.Models;
using API_LojaVirtual.Repositories;
using API_LojaVirtual.ViewModels;

namespace API_LojaVirtual.Services
{
    public class CategoriaService
    {
        private readonly CategoriaRepositories categoriaRepositorio;

        public CategoriaService(CategoriaRepositories categoriaRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<List<MostrarPorNomeViewModel>> ListaCategoriasTemProdutosAsync()
        {
            try
            {
                return await categoriaRepositorio.ListaCategoriasTemProdutosAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProdutoViewModel>> PesquisaProdutosUrlCategoriasAsync(string url)
        {
            try
            {
                return await categoriaRepositorio.PesquisaProdutosUrlCategoriasAsync(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
