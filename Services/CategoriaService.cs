using API_LojaVirtual.Models;
using API_LojaVirtual.Repositories;
using API_LojaVirtual.ViewModels;

namespace API_LojaVirtual.Services
{
    public class CategoriaService
    {
        private readonly CategoriaRepositorio categoriaRepositorio;

        public CategoriaService(CategoriaRepositorio categoriaRepositorio)
        {
            this.categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<List<MostrarCategoriaViewModel>> ListaCategoriasTemProdutos()
        {
            try
            {
                return await categoriaRepositorio.ListaCategoriasTemProdutos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProdutoPorCategoriaViewModel>> PesquisaProdutosUrlCategorias(string url)
        {
            try
            {
                return await categoriaRepositorio.PesquisaProdutosUrlCategorias(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
