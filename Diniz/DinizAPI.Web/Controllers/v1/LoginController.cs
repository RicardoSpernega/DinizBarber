using AutoMapper;
using DinizAPI.Domain.Enuns;
using DinizAPI.Domain.Interfaces.Services;
using DinizAPI.Domain.Models.Api;
using DinizAPI.Domain.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DinizAPI.Web.Controllers.v1
{
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;

        public LoginController(IMapper mapper, ILoginService loginService)
        {
            _mapper = mapper;
            _loginService = loginService;

        }

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        [SwaggerOperation(
            Summary = "Buscar Login by Id")]
        public ActionResult Get(int idLogin)
        {
            try
            {
                var login = _loginService.GetLogin(idLogin);
                return StatusCode(login == null ? 204 : 200, login);
            }
            catch(Exception ex)
            {
                return StatusCode(500,"Erro interno. - " + ex.Message);
            }

        }

        // GET: api/Login/
        [HttpGet]
        [SwaggerOperation(
            Summary = "Lista de login")]
        
        public ActionResult Get()
        {
            try
            {
                return StatusCode(200, _loginService.ListarLogin());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno. - " + ex.Message);
            }

        }

        // POST: api/Login
        [HttpPost]
        [SwaggerOperation(
            Summary = "Execução de Cadastro de Login.")]
        public ActionResult Post(
            [FromBody][Required][SwaggerParameter("Objeto de requisição")] Login request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_loginService.GetLoginByParam(x => x.Email == request.Email) != null)
                    {
                        return StatusCode(200, "Email já cadastrado!");
                    }
                    if (_loginService.GetLoginByParam(x => x.Cpf == request.Cpf) != null)
                    {
                        return StatusCode(200, "Cpf já cadastrado!");
                    }

                    var ret = _loginService.CadastroLogin(request);

                    return StatusCode(200, ret);
                }
                var erros = ModelState.Values.SelectMany(m => m.Errors);
                return StatusCode(200, erros);
            }
            catch(Exception ex)
            {
                return StatusCode(401, ex.Message);
            }
        }

        // PUT: api/Login/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var login = _loginService.GetLogin(id);
                if (login != null)
                {
                    _loginService.DeletarLogin(login);

                    return StatusCode(200, "Login deletado com sucesso!");
                }
                return StatusCode(204, "Login não encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
