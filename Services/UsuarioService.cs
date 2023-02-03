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
                    Senha = GeraHash(usuario.Senha),
                    Ativo = true,
                    Excluido = false,
                    ChaveVerificacao = Guid.NewGuid().ToString()

            };
                await usuarioRepositorio.CadastrarUsuarioAsync(novoUsuario);
                return new RespostaViewModel { Sucesso = true, Mensagem = "Usuario criado com sucesso!" };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> LogarUsuarioAsync(LoginUsuarioViewModel model)
        { 
            try
            {
                model.Senha = GeraHash(model.Senha);
                return await usuarioRepositorio.LogarUsuarioAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RespostaViewModel> VerificarUsuarioAsync(VerificaUsuarioViewModel usuario)
        {
            try
            {
                if(await usuarioRepositorio.VerificarUsuarioAsync(usuario))
                    return new RespostaViewModel { Sucesso = true, Mensagem = "Usuario verificado!" };

                return new RespostaViewModel { Sucesso = false, Mensagem = "Usuario não verificado!" };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

            public static string GeraHash(string senha)
        {
            var md5 = MD5.Create();
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(senha);
            byte[] hash = md5.ComputeHash(bytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
