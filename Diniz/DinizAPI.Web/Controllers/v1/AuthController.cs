using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DinizAPI.Domain.Interfaces.Services;
using DinizAPI.Domain.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace DinizAPI.Web.Controllers.v1
{
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config, ILoginService loginService)
        {
            _config = config;
            _loginService = loginService;
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([Required][SwaggerParameter("Email")] string email,
                                                [Required][SwaggerParameter("Senha")] string senha)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(email, senha);
            if (user != null)
            {
                var tokenString = TokenService.TokenService.GenerateToken(user);
                response = Ok(new { Token = tokenString, Message = "Success" });
            }
            return response;
        }

        private Login AuthenticateUser(string email, string senha)
        {
            var user = _loginService.GetLoginByParam(x => x.Email == email && x.Senha == senha);
            return user;
        }

    }
}