using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DinizAPI.Domain.Interfaces.Services;
using DinizAPI.Domain.Models.Api;
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
        private readonly IMapper _mapper;

        public AuthController(IConfiguration config, ILoginService loginService, IMapper mapper)
        {
            _config = config;
            _loginService = loginService;
            _mapper = mapper;
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody][Required][SwaggerParameter("Objeto requerido")] RequestAuth request)
                                                
        {
            try
            {
                IActionResult response = Unauthorized();
                var user = AuthenticateUser(request.EmailUsuario, request.SenhaUsuario);
                if (user != null)
                {
                    var tokenString = TokenService.TokenService.GenerateToken(user);
                    user.Senha = "";
                    return StatusCode(200,new { Token = tokenString, Message = "Success" , User = user});
                }
                return StatusCode(200,"Login não encontrado!");
            }
            catch (Exception ex)
            {
                return StatusCode(401, ex.Message);
            }

        }

        [HttpPost(nameof(CadastrarLogin))]
        [SwaggerOperation(
            Summary = "Execução de Cadastro de Login.")]
        public async Task<IActionResult> CadastrarLogin([FromBody][Required][SwaggerParameter("Objeto requerido")] RequestLogin request)

        {
            try
            {
                IActionResult response = Unauthorized();
                if (ModelState.IsValid)
                {
                    if(_loginService.GetLoginByParam(x => x.Email == request.Email) != null)
                    {
                        return StatusCode(200, "Email já cadastrado!");
                    }
                    if (_loginService.GetLoginByParam(x => x.Cpf == request.Cpf) != null)
                    {
                        return StatusCode(200, "Cpf já cadastrado!");
                    }
                    var user = _loginService.CadastroLogin(_mapper.Map<Login>(request));
                   
                    response = Ok(new { User = user, Message = "Success" });
                    
                    return response;
                }
                var erros = ModelState.Values.SelectMany(m => m.Errors);
                return StatusCode(401, erros);
            }
            catch (Exception ex)
            {
                return StatusCode(401, ex.Message);
            }

        }


        private Login AuthenticateUser(string email, string senha)
        {
            var user = _loginService.GetLoginByParam(x => x.Email == email && x.Senha == senha);
            return user;
        }

    }
}