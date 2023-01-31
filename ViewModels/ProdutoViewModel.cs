namespace API_LojaVirtual.ViewModels
{
    public class ProdutoViewModel
    {
        public string Nome { get; set; }
        public string Url { get; set; }
        public int Quantidade { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }
        public string? Mensagem { get; set; }
    }
}
