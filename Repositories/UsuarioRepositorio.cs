using API_LojaVirtual.Data;
using API_LojaVirtual.ViewModels;

namespace API_LojaVirtual.Repositories
{
    public class UsuarioRepositorio
    {
        private readonly LojaDataContext context;

        public UsuarioRepositorio(LojaDataContext context)
        {
            this.context = context;
        }
        //public async Task<List<MostrarPorNomeViewModel>> ListaUsuariosAtivos()
        //{
        //    var usuario = await context.Usuarios.
        //}
    }
}
