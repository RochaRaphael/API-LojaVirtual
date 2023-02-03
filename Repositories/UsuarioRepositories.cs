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
            await context.Usuarios.AddAsync(novoUsuario);
            await context.SaveChangesAsync();
        }
        public async Task<bool> UsuarioExisteAsync(string login)
        {
            return await Task.FromResult(context.Usuarios.Any(x => x.Login == login));
        }


        public async Task<bool> LogarUsuarioAsync(LoginUsuarioViewModel model)
        {
            var login = await context
                 .Usuarios
                 .FirstOrDefaultAsync(x => x.Login == model.Login && x.Senha == model.Senha);

            if (login != null)
            {
                login.LastToken = tokenService.GenerateToken(login).ToString();
                context.Usuarios.Update(login);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> VerificarUsuarioAsync(VerificaUsuarioViewModel usuario)
        {
            var verificado = await context
                 .Usuarios
                 .FirstOrDefaultAsync(x => x.Email == usuario.Email && x.ChaveVerificacao == usuario.ChaveVerificacao);


            if (verificado != null)
            {
                verificado.IsVerification = true;
                context.Usuarios.Update(verificado);
                await context.SaveChangesAsync();

                return true;
            }

            else
                return false;
        }

    }
}
