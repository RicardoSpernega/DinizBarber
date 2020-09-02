using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DinizAPI.Domain.Interfaces.Services;
using DinizAPI.Domain.Models.Api;
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
    public class DiaHorarioAceiteController : ControllerBase
    {
        private readonly IDiaHorarioAceiteService _diaHorarioAceiteService;
        private readonly IMapper _mapper;

        public DiaHorarioAceiteController(IMapper mapper, IDiaHorarioAceiteService diaHorarioAceiteService)
        {
            _mapper = mapper;
            _diaHorarioAceiteService = diaHorarioAceiteService;

        }

        // GET: api/Login/
        [HttpGet]
        [SwaggerOperation(
            Summary = "Lista de Dia Horarios")]

        public ActionResult Get([Required] int idTipoStatusHorario)
        {
            try
            {
                return StatusCode(200, _diaHorarioAceiteService.ListarDiaHorarioAceiteByParam(x => x.TipoStatusHorarioId == idTipoStatusHorario));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno. - " + ex.Message);
            }

        }
        // POST: api/DiaHorarioAceite
        [HttpPost]
        public ActionResult Post([FromBody][Required] RequestDiaHorarioAceite request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var diaHorario = _diaHorarioAceiteService.CadastroDiaHorarioAceite(_mapper.Map<DiaHorarioAceite>(request));
                    return StatusCode(200, "Incluido com sucesso!");
                }

                var erros = ModelState.Values.SelectMany(m => m.Errors);
                return StatusCode(200, erros);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno. - " + ex.Message);
            }

        }

        // POST: api/DiaHorarioAceite
        [HttpPost(nameof(AlterarDiaHorarioAceite))]
        public ActionResult AlterarDiaHorarioAceite([Required]int idDiaHorario, [Required] int idLogin, [Required]int tipoStatusHorario)
        {
            try
            {
                var diaHorarioAceite = _diaHorarioAceiteService.GetDiaHorarioAceiteByParam(x => x.DiaHorarioAceiteId == idDiaHorario);
                diaHorarioAceite.LoginId = idLogin; 
                diaHorarioAceite.TipoStatusHorarioId = tipoStatusHorario;

                var diaHorario = _diaHorarioAceiteService.CadastroDiaHorarioAceite(diaHorarioAceite);
                return StatusCode(200, "Alterado com sucesso! ");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno. - " + ex.Message);
            }

        }

    }
}
