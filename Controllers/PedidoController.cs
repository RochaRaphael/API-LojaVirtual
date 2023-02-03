using API_LojaVirtual.Services;
using API_LojaVirtual.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_LojaVirtual.Controllers
{
    [ApiController]
    [Route("api")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            this.pedidoService = pedidoService;
        }

        [Authorize]
        [HttpGet("/v1/pedido")]
        public async Task<IActionResult> PostAdicionarPedidoAsync(
            [FromBody] PedidoViewModel pedido
            )
        {
            return Ok("rota ta certa");
            var novoPedido = await pedidoService.AdicionarPedido(pedido);
            if(novoPedido.Sucesso)
                return Ok(novoPedido.Mensagem);

            return StatusCode(401, novoPedido.Mensagem);
        }
    }
}
