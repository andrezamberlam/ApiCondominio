using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using ApiCondominio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ApiCondominio.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        readonly string SUPERSECRETA = "OPA";
        private dbcondominiosContext _context;

        public UsuarioController(dbcondominiosContext context)
        {
            _context = context;
        }

        [Authorize("Bearer")]
        public IActionResult Index()
        {
            return Ok(_context.Usuario.ToArray());
        }

        [Route("cadastrar"), HttpPost, AllowAnonymous]
        public IActionResult cadastrar([FromForm]Usuario Usuario)
        {
            if (string.IsNullOrWhiteSpace(Usuario.Email) || string.IsNullOrWhiteSpace(Usuario.Senha))
            {
                return Ok(new
                {
                    error = true,
                    message = "Email ou senha em branco."
                });
            }
            var usuarioBanco = _context.Usuario.SingleOrDefault(x => x.Email == Usuario.Email);
            if (usuarioBanco != null)
            {
                return Ok(new
                {
                    error = true,
                    message = "Usuario ja cadastrado."
                });
            }

            Usuario.Senha = GetMd5Hash(MD5.Create(), Usuario.Senha + SUPERSECRETA);

            _context.Usuario.Add(Usuario);
            _context.SaveChanges();
            return Ok(new { Usuario, error = false, message = "" });
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult login(
            [FromForm]Usuario usuario,
            //[FromServices]UsersDAO usersDAO,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            bool credenciaisValidas = false;
            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.Email))
            {
                var usuarioBase = _context.Usuario.SingleOrDefault(x => x.Email == usuario.Email);
                credenciaisValidas = (usuarioBase != null &&
                    usuario.Email == usuarioBase.Email &&
                    VerifyMd5Hash(MD5.Create(), usuario.Senha + SUPERSECRETA, usuarioBase.Senha));
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.Email, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Email)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return Ok(new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                });
            }
            else
            {
                return Ok(new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                });
            }

        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}