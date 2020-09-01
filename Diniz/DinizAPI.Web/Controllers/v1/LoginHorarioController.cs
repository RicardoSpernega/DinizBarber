using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DinizAPI.Domain.Interfaces.Services;
using DinizAPI.Domain.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DinizAPI.Web.Controllers.v1
{
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    [ApiController]
    public class LoginHorarioController : ControllerBase
    {
        private readonly ILoginHorarioService _loginHorarioService;
        private readonly IMapper _mapper;

        public LoginHorarioController(IMapper mapper, ILoginHorarioService loginHorarioService)
        {
            _mapper = mapper;
            _loginHorarioService = loginHorarioService;

        }

        [HttpGet("{id}")]
        [SwaggerOperation(
             Summary = "Buscar Login Horarios by Id")]
        public ActionResult Get(int idLoginHorario)
        {
            try
            {
                var loginHorario = _loginHorarioService.GetLoginHorario(idLoginHorario);
                return StatusCode(loginHorario == null ? 204 : 200, loginHorario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno. - " + ex.Message);
            }

        }

        // GET: api/Horario/
        [HttpGet]
        [SwaggerOperation(
            Summary = "Lista de Login Horarios")]

        public ActionResult Get()
        {
            try
            {
                return StatusCode(200, _loginHorarioService.ListarLoginHorario());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno. - " + ex.Message);
            }

        }

        // POST: api/Login
        [HttpPost]
        [SwaggerOperation(
            Summary = "Execução de Cadastro de Login Horario.")]
        public ActionResult Post(
            [FromBody][Required][SwaggerParameter("Objeto de requisição")] LoginHorario request)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var ret = _loginHorarioService.CadastroLoginHorario(request);

                    return StatusCode(200, ret);
                }
                var erros = ModelState.Values.SelectMany(m => m.Errors);
                return StatusCode(200, erros);
            }
            catch (Exception ex)
            {
                return StatusCode(401, ex.Message);
            }
        }


        // DELETE: api/Horario/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var horario = _loginHorarioService.GetLoginHorario(id);
                if (horario != null)
                {
                    _loginHorarioService.DeletarLoginHorario(horario);

                    return StatusCode(200, "Login Horario deletado com sucesso!");
                }
                return StatusCode(204, "Login Horario não encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
