using eAgenda.Dominio.ModuloAutenticacao;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace eAgenda.Aplicacao.ModuloAutenticacao
{
    public class ServicoAutenticacao : ServicoBase<Usuario, ValidadorUsuario>
    {
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;

        public ServicoAutenticacao(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<Result<Usuario>> RegistrarUsuario(Usuario usuario, string senha)
        {
            Log.Logger.Debug("Tentando registrar usuário... {@u}", usuario);

            var resultado = Validar(usuario);
            if (resultado.IsFailed)
                return Result.Fail(resultado.Errors);

            try
            {
                IdentityResult usuarioResult = await userManager.CreateAsync(usuario, senha);

                if (usuarioResult.Succeeded == false)
                {
                    var erros = usuarioResult.Errors
                        .Select(identityError => new Error(identityError.Description));

                    return Result.Fail(erros);
                }

                Log.Logger.Information("Usuario {UsuarioId} registrado com sucesso", usuario.Id);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar registrar o usuário";

                Log.Logger.Error(ex, msgErro + " {UsuarioId}", usuario.Id);

                return Result.Fail(msgErro);
            }

            return Result.Ok(usuario);
        }

        public async Task<Result<Usuario>> AutenticarUsuario(string email, string senha)
        {
            Log.Logger.Debug("Tentando autenticar usuário... {@u}", email);

            SignInResult loginResult = await signInManager.PasswordSignInAsync(email, senha, false, true);

            if (loginResult.Succeeded == false && loginResult.IsLockedOut)
            {
                string msgErro = "Usuário Bloqueado";
                Log.Logger.Warning(msgErro + " {UsuarioEmail}", email);
                return Result.Fail(msgErro);
            }

            if (loginResult.Succeeded == false)
            {
                string msgErro = "Usuário ou senha incorretos";
                Log.Logger.Warning(msgErro + " {UsuarioEmail}", email);
                return Result.Fail(msgErro);
            }

            Usuario usuario = await userManager.FindByEmailAsync(email);

            return Result.Ok(usuario);
        }

        public async Task<Result<Usuario>> Sair(string email)
        {
            await signInManager.SignOutAsync();

            Log.Logger.Debug("Sessão do usuário {@email} removida...", email);

            return Result.Ok();
        }
    }
}
