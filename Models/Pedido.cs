namespace API_LojaVirtual.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataPedido { get; set; }

        public List<Produto> Produtos { get; set; }

    }
}
