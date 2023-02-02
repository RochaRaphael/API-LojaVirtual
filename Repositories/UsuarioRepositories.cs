using API_LojaVirtual.Data;
using API_LojaVirtual.Models;
using API_LojaVirtual.Services;
using API_LojaVirtual.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API_LojaVirtual.Repositories
{
    public class UsuarioRepositories
    {
        private readonly LojaDataContext context;
        private readonly TokenService tokenService;

        public UsuarioRepositories(LojaDataContext context, TokenService tokenService)
        {
            this.context = context;
            this.tokenService = tokenService;
        }

        public async Task CadastrarUsuarioAsync(Usuario novoUsuario)
        {
            var jaCadastrado = await context
                .Usuarios
                .FirstOrDefaultAsync(x => x.Login == novoUsuario.Login);
            if (jaCadastrado == null)
            {
                await context.Usuarios.AddAsync(novoUsuario);
                await context.SaveChangesAsync();
            }
        }
        public async Task<bool> UsuarioExisteAsync(string login)
        {
            return await Task.FromResult(context.Usuarios.Any(x => x.Login == login));
        }


        public async Task<bool> LogarUsuario(NovoUsuarioViewModel model)
        {
            var login = await context
                 .Usuarios
                 .FirstOrDefaultAsync(x => x.Login == model.Login);

            var usuarioLogin = new NovoUsuarioViewModel
            {
                Email = model.Email,
                Senha = GeraHash(model.Senha)
            };

            if (usuarioLogin != null && usuarioLogin.Senha == login.Senha)
            {
                login.LastToken = tokenService.GenerateToken(login);
                return true;
            }
            else
            {
                return false;
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
