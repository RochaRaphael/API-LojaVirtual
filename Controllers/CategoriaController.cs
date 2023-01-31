using API_LojaVirtual.Models;
using API_LojaVirtual.Services;
using API_LojaVirtual.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API_LojaVirtual.Controllers
{
    [ApiController]
    [Route("api")]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService categoriaService;
        public CategoriaController(CategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }

        [HttpGet("v1/categorias")]
        public async Task<IActionResult> GetValidosAsync()
        {
            try
            {
                return Ok(new ResultadoViewModel<List<MostrarPorNomeViewModel>>(
                    await categoriaService
                    .ListaCategoriasTemProdutos()));
            }
            catch
            {
                return StatusCode(500, new ResultadoViewModel<List<Produto>>("05X04 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/categorias/{url}")]
        public async Task<IActionResult> GetByUrlAsync(
            [FromRoute] string url)
        {
            try
            {
                var resultado = await categoriaService.PesquisaProdutosUrlCategorias(url);
                if (resultado == null)
                    return StatusCode(204, new ResultadoViewModel<List<Categoria>>("A categoria não está disponível"));

                return Ok(new ResultadoViewModel<List<ProdutoViewModel>>(resultado));
            }
            catch
            {
                return StatusCode(500, new ResultadoViewModel<List<Produto>>("08X12 - Falha interna no servidor"));
            }
        }
    }
}
