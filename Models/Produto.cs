namespace API_LojaVirtual.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public Categoria Categoria { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public int Quantidade { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }

        public List<Pedido> Pedidos { get; set; }

    }
}
