using API_LojaVirtual.Extensions;
using API_LojaVirtual.Services;
using API_LojaVirtual.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API_LojaVirtual.Controllers
{
    [ApiController]
    [Route("api")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService produtoService;
        public ProdutoController(ProdutoService produtoService)
        {
            this.produtoService = produtoService;
        }

        [HttpGet("v1/produto/{url}")]
        public async Task<IActionResult> GetFiltrarPorUrlAsync(
            [FromRoute] string url)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultadoViewModel<string>(ModelState.GetErrors()));
            try
            {
                var produto = await produtoService.PesquisaProdutoUrlAsync(url);

                if (produto != null)
                    return Ok(new ResultadoViewModel<dynamic>(produto));

                return StatusCode(204, new ResultadoViewModel<string>("54Y23 - Produto invativo ou url não encontrada"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultadoViewModel<string>("34X44 - Falha interna no servidor"));
            }
        }
    }
}
