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

        [HttpPost("v1/conta")]
        public async Task<IActionResult> PostCadastrarUsuario(
            [FromBody] NovoUsuarioViewModel model,
            [FromServices] LojaDataContext context)
        {
            
            if (await usuarioService.CadastrarUsuario(model))
                return Ok(new ResultadoViewModel<string>("Usuario cadastrado com sucesso!"));

            return Ok(new ResultadoViewModel<string>("Usurio já cadastrado"));
        }
    }
    
}
