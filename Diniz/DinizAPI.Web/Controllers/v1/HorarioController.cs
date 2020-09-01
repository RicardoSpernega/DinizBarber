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
    public class HorarioController : ControllerBase
    {

        private readonly IHorarioService _horarioService;
        private readonly IMapper _mapper;

        public HorarioController(IMapper mapper, IHorarioService horarioService)
        {
            _mapper = mapper;
            _horarioService = horarioService;

        }

        [HttpGet("{id}")]
        [SwaggerOperation(
             Summary = "Buscar horario by Id")]
        public ActionResult Get(int idHorario)
        {
            try
            {
                var horario = _horarioService.GetHorario(idHorario);
                return StatusCode(horario == null ? 204 : 200, horario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno. - " + ex.Message);
            }

        }

        // GET: api/Horario/
        [HttpGet]
        [SwaggerOperation(
            Summary = "Lista de horario")]

        public ActionResult Get()
        {
            try
            {
                return StatusCode(200, _horarioService.ListarHorario());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno. - " + ex.Message);
            }

        }

        // POST: api/Login
        [HttpPost]
        [SwaggerOperation(
            Summary = "Execução de Cadastro de Horario.")]
        public ActionResult Post(
            [FromBody][Required][SwaggerParameter("Objeto de requisição")] Horario request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_horarioService.GetHorarioByParam(x => x.HorarioInicio == request.HorarioInicio && x.Dia == request.Dia) != null)
                    {
                        return StatusCode(200, "Dia e horario já cadastrado!");
                    }

                    var ret = _horarioService.CadastroHorario(request);

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
                var horario = _horarioService.GetHorario(id);
                if (horario != null)
                {
                    _horarioService.DeletarHorario(horario);

                    return StatusCode(200, "Horario deletado com sucesso!");
                }
                return StatusCode(204, "Horario não encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
