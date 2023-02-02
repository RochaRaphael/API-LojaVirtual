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

        public async Task<RespostaViewModel> CadastrarUsuario(NovoUsuarioViewModel usuario)
        {
            try
            {
                if (await usuarioRepositorio.UsuarioExisteAsync(usuario.Login))
                    return new RespostaViewModel { Sucesso = false, Mensagem = "Usuario ´já existe!" };


                var novoUsuario = new Usuario
                {
                    Nome = usuario.Nome,
                    Login = usuario.Login,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    Ativo = true,
                    Excluido = false

                };
                await usuarioRepositorio.CadastrarUsuarioAsync(novoUsuario);
                return new RespostaViewModel { Sucesso = true, Mensagem = "Usuario criado com sucesso!" };
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
