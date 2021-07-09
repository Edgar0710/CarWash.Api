using CarWash.Business.Business;
using CarWash.Model;
using CarWash.Model.Helpers;
using CarWash.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IConfiguration _config;
        IUsuarioBusiness usuarioBussines;
      
        public UsuariosController(IUsuarioBusiness _usuarioBussines, IConfiguration config)
        {
            usuarioBussines = _usuarioBussines;
            _config = config;
            
        }

        [HttpGet,Route("Prueba")]
        public Response<object> Prueba()
        {
            return usuarioBussines.prueba();
        }


        [HttpPost]
        [Route("Login")]

        public IActionResult Login(string email, string password)
        {

            Response<UsuarioModel> user = usuarioBussines.Login(email, password);
            IActionResult response = Unauthorized();
            if (user.Code == ResponseEnum.Ok)
            {
                user.Result.us_athorization = GenerateJSONWebToken(user.Result);
                response = Ok(user);
            }
            return response;

        }

        private string GenerateJSONWebToken(UsuarioModel usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] {
                new Claim("usuario",  Utils.Base64_Encode(usuario.us_id.ToString())),
               // new Claim(ClaimTypes.PrimarySid, usuario.us_id.ToString()),
            });

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claimsIdentity.Claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();


            return jwtSecurityTokenHandler.WriteToken(token);
        }
    }
}
