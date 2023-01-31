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
        public async Task<IActionResult> GetByUrlAsync(
            [FromRoute] string url)
        {
            try
            {
                var produto = await produtoService.PesquisaProdutoUrl(url);

                if (produto != null)
                    return Ok(new ResultadoViewModel<dynamic>(produto));

                return StatusCode(204, new ResultadoViewModel<string>("54Y23 - Produto invativo ou url não encontrada"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultadoViewModel<string>("34X44 - Falha interna no servidor"));
            }
        }

        //[HttpPost("v1/signup")]
        //public async Task<IActionResult> Post(
        //    [FromServices] LojaDataContext context)
        //{
        //    var user = new Usuario
        //    {
        //        Nome = "Raphael",
        //        Login = "Teste",
        //        Email = "rocharaphael@gmail.com",
        //        Senha = "123",
        //        ChaveVerificacao = "Testeee",
        //        LastToken = "Testando",
        //        IsVerification = false,
        //        Ativo = true,
        //        Excluido = false
        //    };

        //    try
        //    {
        //        await context.Usuarios.AddAsync(user);
        //        await context.SaveChangesAsync();

        //        return Ok("DEU CERTO");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

    }
}
