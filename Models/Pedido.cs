namespace API_LojaVirtual.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public Usuario UsuarioId { get; set; }
        public DateTime DataPedido { get; set; }
        public IList<Produto> Produtos { get; set; }

    }
}
