using API_LojaVirtual.Data;
using API_LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_LojaVirtual.Controller
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("/teste")]
        public string Get(
            [FromServices] LojaDataContext context)
        {
            Usuario a = context.Usuarios.FirstOrDefault(x => x.Id == 1);
            if (a == null)
            {
                return "É NULOOO";
            }
            else
            {
                return "Hello World";
            }
            
        }

        [HttpPost("v1/signup")]
        public async Task<IActionResult> Post(
            [FromServices] LojaDataContext context)
        {
            var user = new Usuario
            {
                Nome = "Raphael",
                Login = "Teste",
                Email = "rocharaphael@gmail.com",
                Senha = "123",
                ChaveVerificacao = "Testeee",
                LastToken = "Testando",
                IsVerification = false,
                Ativo = true,
                Excluido = false
            };

            try
            {
                await context.Usuarios.AddAsync(user);
                await context.SaveChangesAsync();

                return Ok("DEU CERTO");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
