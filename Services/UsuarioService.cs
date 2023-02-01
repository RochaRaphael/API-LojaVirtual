using API_LojaVirtual.Models;
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

        public async Task CadastrarUsuario(Usuario novoUsuario)
        {
            try
            { 
                await usuarioRepositorio.CadastrarUsuario(novoUsuario);
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
