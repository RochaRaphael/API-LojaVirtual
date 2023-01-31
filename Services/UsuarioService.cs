using API_LojaVirtual.Repositories;
using API_LojaVirtual.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace API_LojaVirtual.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepositories usuarioRepositorio;

        public UsuarioService(UsuarioRepositories usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<bool> CadastrarUsuario(NovoUsuarioViewModel model)
        {
            try
            { 
                return await usuarioRepositorio.CadastrarUsuario(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> LogarUsuario(NovoUsuarioViewModel model)
        {
            try
            {
                return await usuarioRepositorio.LogarUsuario(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
