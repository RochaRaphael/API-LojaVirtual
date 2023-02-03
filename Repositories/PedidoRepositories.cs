using API_LojaVirtual.Data;
using API_LojaVirtual.Models;
using API_LojaVirtual.ViewModels;

namespace API_LojaVirtual.Repositories
{
    public class PedidoRepositories
    {
        private readonly LojaDataContext context;

        public PedidoRepositories(LojaDataContext context)
        {
            this.context = context;
        }

        public async Task<bool> ProcuraUsurioIdAsync(int usuarioId)
        {
            var usuario = context.Usuarios.FirstOrDefault(x => x.Id == usuarioId);
            if (usuario == null)
                return false;

            return true;
        }
        

        public async Task<bool> ProcuraProdutoAsync(List<PedidoProdutoViewModel> produtos)
        {
            foreach (var item in produtos)
            {
                var produto = context.Produtos.FirstOrDefault(x => x.Nome == item.Nome);
                if (produto == null)
                {
                    return false;
                }
            }
            return true;

        }

        public async Task<bool> InserirPedidoAsync(PedidoViewModel pedido)
        {
            var usuario = context
                .Usuarios
                .FirstOrDefault(x => x.Id == pedido.UsuarioId);

            List<Produto> produtos = new List<Produto>();
            foreach (var item in pedido.Produtos)
            {
                produtos.Add(context.Produtos.FirstOrDefault(x => x.Nome == item.Nome));
            }

            var novoPedido = new Pedido
            {
                Usuario = usuario,
                Produtos = produtos
            };


            context.Pedidos.Add(novoPedido);
            context.SaveChanges();

            return true;
        }

    }
}

