using API_LojaVirtual.Models;

namespace API_LojaVirtual.ViewModels
{
    public class MostrarCategoriaViewModel
    {
        public string Nome { get; set; }
        public List<Produto> Produto { get; set; }
    }
}
