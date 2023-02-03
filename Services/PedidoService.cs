using API_LojaVirtual.Models;
using API_LojaVirtual.Repositories;
using API_LojaVirtual.ViewModels;

namespace API_LojaVirtual.Services
{
    public class PedidoService
    {
        private readonly PedidoRepositories pedidoRepositorio;

        public PedidoService(PedidoRepositories pedidoRepositorio)
        {
            this.pedidoRepositorio = pedidoRepositorio;
        }

        public async Task<RespostaViewModel>AdicionarPedido(PedidoViewModel pedido)
        {
            try
            {
                if (await pedidoRepositorio.ProcuraUsurioIdAsync(pedido.UsuarioId))
                    return new RespostaViewModel { Sucesso = false, Mensagem = "Usuario não encontrado!" };

                if (await pedidoRepositorio.ProcuraProdutoAsync(pedido.Produtos))
                    return new RespostaViewModel { Sucesso = false, Mensagem = "Produto(s) não encontrado!" };


                await pedidoRepositorio.InserirPedidoAsync(pedido);
                return new RespostaViewModel { Sucesso = true, Mensagem = "Pedido cadastrado com sucesso!" };
            }
            catch (Exception)
            {

                throw;
            } 
        }
    }
}
