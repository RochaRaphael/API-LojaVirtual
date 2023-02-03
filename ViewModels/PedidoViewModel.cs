using API_LojaVirtual.Models;

namespace API_LojaVirtual.ViewModels
{
    public class PedidoViewModel
    {
        public int UsuarioId { get; set; }
        public List<PedidoProdutoViewModel> Produtos { get; set; }
    }

    public class PedidoProdutoViewModel
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
    }
}
