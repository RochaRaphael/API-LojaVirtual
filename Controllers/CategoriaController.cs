using API_LojaVirtual.Data;
using API_LojaVirtual.Models;
using API_LojaVirtual.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_LojaVirtual.Controllers
{
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        [HttpGet("v1/categorias")]
        public async Task<IActionResult> GetByIdAsync(
            [FromServices] LojaDataContext context)
        {

            try
            {
                var produto = await context
                    .Produtos
                    .AsNoTracking()
                    .Include(x => x.Categoria)
                    .Where(x => x.Quantidade > 0 && x.Ativo == true)
                    .Select(x => new CategoriasValidasViewModel
                    {
                        Nome = x.Categoria.Nome,
                    })
                    .Distinct()
                    .ToListAsync();
                return Ok(new ResultadoViewModel<List<CategoriasValidasViewModel>>(produto));
            }
            catch
            {
                return StatusCode(500, new ResultadoViewModel<List<Categoria>>("05X04 - Falha interna no servidor"));
            }
        }
    }
}
