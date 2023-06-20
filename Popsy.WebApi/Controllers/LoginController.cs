using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using Popsy.Attributes;
using Popsy.Settings;

namespace Popsy.Controllers
{
    /// <summary>
    /// Controlador para hacer pruebas de login.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [DisableSwagger]
    [DisableAPI]
    public class LoginController : ControllerBase
    {
        private readonly TokenSettings _settings;
        private readonly Byte[] _jwt;

        public LoginController(TokenSettings settings, byte[] jwt)
        {
            _settings = settings;
            _jwt = jwt;
        }
        /// <summary>
        /// Genera un token de prueba.
        /// </summary>
        /// <returns>Token de prueba.</returns>
        [HttpPost("GenerarToken")]
        public ActionResult<String> GenerarToken()
        {
            List<Claim> userInformation = new List<Claim>
            {
                new Claim("id", "143C02A3-F2F1-ED11-892D-34735A9C3F28"),
                new Claim("nombres", "admin"),
                new Claim("apellidos", "usuario"),
                new Claim("correo", "admin@usuario.com"),
                new Claim("estado", "1"),
            };

            List<string> roles = new List<string> { "ADMINISTRADOR SUPLENTE" };

            foreach (string rol in roles)
            {
                userInformation.Add(new Claim("roles", rol));
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(_jwt);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expiration = DateTime.UtcNow.AddMinutes(int.Parse(_settings.TiempoVidaExtra));
            DateTime issuedAt = DateTime.UtcNow;

            JwtSecurityToken securityToken = new JwtSecurityToken(
                claims: userInformation,
                issuer: null,
                audience: null,
                notBefore: issuedAt,
                expires: expiration,
                signingCredentials: credentials
            );

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
        /// <summary>
        /// Genera un token de prueba.
        /// </summary>
        /// <returns>Token de prueba.</returns>
        [HttpPost("GenerarToken/{rol}")]
        public ActionResult<String> GenerarToken(String rol)
        {
            List<Claim> userInformation = new List<Claim>
            {
                new Claim("id", "143C02A3-F2F1-ED11-892D-34735A9C3F28"),
                new Claim("nombres", "admin"),
                new Claim("apellidos", "usuario"),
                new Claim("correo", "admin@usuario.com"),
                new Claim("estado", "1"),
            };

            List<string> roles = new List<string> { rol, "2" };

            foreach (string rolAdd in roles)
            {
                userInformation.Add(new Claim("roles", rolAdd));
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(_jwt);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expiration = DateTime.UtcNow.AddMinutes(int.Parse(_settings.TiempoVidaExtra));
            DateTime issuedAt = DateTime.UtcNow;

            JwtSecurityToken securityToken = new JwtSecurityToken(
                claims: userInformation,
                issuer: null,
                audience: null,
                notBefore: issuedAt,
                expires: expiration,
                signingCredentials: credentials
            );

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

        /// <summary>
        /// Genera un token invalido de prueba.
        /// </summary>
        /// <returns>Token de prueba.</returns>
        [HttpPost("GenerarTokenInvalido")]
        public ActionResult<String> GenerarTokenInvalido()
        {
            List<Claim> userInformation = new List<Claim>
            {
                new Claim("id", "143C02A3-F2F1-ED11-892D-34735A9C3F28"),
                new Claim("nombres", "admin"),
                new Claim("apellidos", "usuario"),
                new Claim("correo", "admin@usuario.com"),
                new Claim("estado", "0"),
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(_jwt);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expiration = DateTime.UtcNow.AddMinutes(int.Parse(_settings.TiempoVidaExtra));
            DateTime issuedAt = DateTime.UtcNow;

            JwtSecurityToken securityToken = new JwtSecurityToken(
                claims: userInformation,
                issuer: null,
                audience: null,
                notBefore: issuedAt,
                expires: expiration,
                signingCredentials: credentials
            );

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}