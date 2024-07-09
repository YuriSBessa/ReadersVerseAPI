using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ReadersVerseAPI.Domain.Exceptions;
using ReadersVerseAPI.Domain.Interfaces;
using ReadersVerseAPI.Domain.Models;
using ReadersVerseAPI.Domain.Models.Request;
using ReadersVerseAPI.Domain.Models.Response;
using ReadersVerseAPI.Infra.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ReadersVerseAPI.Application.Servicos
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICarteiraServico _carteiraServico;
        public IdentityService(SignInManager<AppUser> signInManager,
                               UserManager<AppUser> userManager,
                               ICarteiraServico carteiraServico
        )
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._carteiraServico = carteiraServico;
        }
        public async Task<UsuarioCadastroResponse> CadastrarUsuario(UsuarioCadastroRequest usuarioCadastro)
        {
            AppUser user = new()
            {
                Name = usuarioCadastro.Name,
                UserName = usuarioCadastro.Name,
            };

            var result = await _userManager.CreateAsync(user, usuarioCadastro.Password);

            if (result.Succeeded)
            {
                await _userManager.SetLockoutEnabledAsync(user, false);
                await CriarCarteiraAsync(usuarioCadastro.Name);
            }
            
            var usuarioCadastroResponse = new UsuarioCadastroResponse(result.Succeeded);

            if (!result.Succeeded && result.Errors.Count() > 0)
                usuarioCadastroResponse.AdicionarErro(result.Errors.Select(r => r.Description));

            return usuarioCadastroResponse;
        }

        public async Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usuarioLogin)
        {
            var user = await _userManager.FindByNameAsync(usuarioLogin.Name);

            if (user == null)
            {
                throw new BadRequestException("Usuario ou senha estão incorretos");
            }

            var result = await _signInManager.PasswordSignInAsync(user, usuarioLogin.Password, false, true);

            var usuarioLoginResponse = new UsuarioLoginResponse();

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada");
                }
                else if (result.IsNotAllowed)
                {
                    usuarioLoginResponse.AdicionarErro("Essa conta não tem permissão para fazer login");
                }
                else if (result.RequiresTwoFactor)
                {
                    usuarioLoginResponse.AdicionarErro("É necessário confirmar o login no seu segundo fator de autenticação");
                }
                else
                {
                    usuarioLoginResponse.AdicionarErro("Usuario ou senha estão incorretos");
                }
            } else
            {
                string token = GerarToken(user);

                usuarioLoginResponse = new UsuarioLoginResponse(result.Succeeded, token);
            }

            return usuarioLoginResponse;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        private async Task CriarCarteiraAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            _carteiraServico.CriarCarteira(user.Id);
        }

        private string GerarToken(AppUser user)
        {
            var secreteKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("umaChaveSuperSecretaEMuitoSeguraParaAssinarOToken123!@#"));
            var signinCredential = new SigningCredentials(secreteKey, SecurityAlgorithms.HmacSha256);

            var claim = new List<Claim>{
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:7079",
                audience: "https://localhost:7079",
                claims: claim,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredential
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }
    }
}
