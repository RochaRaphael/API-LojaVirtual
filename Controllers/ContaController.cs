using API_LojaVirtual.Data;
using API_LojaVirtual.Extensions;
using API_LojaVirtual.Models;
using API_LojaVirtual.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_LojaVirtual.Controllers
{
    [ApiController]
    public class ContaController : ControllerBase
    {
        [HttpPost("v1/conta")]
        public async Task<IActionResult> Post(
            [FromBody] NovoUsuarioViewModel model,
            [FromServices] LojaDataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultadoViewModel<string>(ModelState.GetErrors()));

            var login = await context
                .Usuarios
                .FirstOrDefaultAsync(x => x.Login == model.Login);

            if (login == null)
            {
                var novoUsuario = new Usuario
                {
                    Nome = model.Nome,
                    Login = model.Login,
                    Email = model.Email,
                    Senha = model.Senha,
                    Ativo = true,
                    Excluido = false
                };

                try
                {
                    await context.Usuarios.AddAsync(novoUsuario);
                    await context.SaveChangesAsync();

                    return Ok(new ResultadoViewModel<dynamic>(new
                    {
                        novoUsuario.Email,
                        novoUsuario.Login
                    }));
                }
                catch (DbUpdateException)
                {
                    return StatusCode(400, new ResultadoViewModel<string>("02X14 - Esse email já existe"));
                }
                catch
                {
                    return StatusCode(500, new ResultadoViewModel<string>("92X04 - Erro interno no servidor"));
                }
            }
            else
            {
                return StatusCode(200, new ResultadoViewModel<string>("02X14 - Esse usuario já existe!"));
            }

            
        }
    }
    
}
