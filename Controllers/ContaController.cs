using API_LojaVirtual.Data;
using API_LojaVirtual.Extensions;
using API_LojaVirtual.Models;
using API_LojaVirtual.Services;
using API_LojaVirtual.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_LojaVirtual.Controllers
{
    [ApiController]
    [Route("api")]
    public class ContaController : ControllerBase
    {
        private readonly UsuarioService usuarioService;

        public ContaController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        } 

        [HttpPost("v1/Cadastro")]
        public async Task<IActionResult> PostCadastrarUsuario(
            [FromBody] NovoUsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultadoViewModel<string>(ModelState.GetErrors()));

           var novoUsuario = await usuarioService.CadastrarUsuario(model);
            if(novoUsuario.Sucesso)
                return Ok(new ResultadoViewModel<Usuario>(novoUsuario.Mensagem));

            return StatusCode(401, new ResultadoViewModel<string>(novoUsuario.Mensagem));
        }

        [HttpPost("v1/Login")]
        public async Task<IActionResult> PostLogin(
            [FromBody] NovoUsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultadoViewModel<string>(ModelState.GetErrors()));

            try
            {
                var logado = await usuarioService.LogarUsuario(model);
            if (logado)
                return Ok(new ResultadoViewModel<bool>(logado));
            else
                return StatusCode(401, new ResultadoViewModel<string>("Usuário ou senha inválidos"));

            
            }
            catch
            {
                return StatusCode(500, new ResultadoViewModel<string>("05X04 - Falha interna no servidor"));
            }
        }
    }
    
}
