using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DinizAPI.Domain.Interfaces.Services;
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
    public class DiaController : ControllerBase
    {
        private readonly IDiaService _diaService;
        public DiaController(IDiaService diaService)
        {
            _diaService = diaService;

        }

        // GET: api/Dia/5
        [HttpGet]
        public ActionResult Get([Required]int id)
        {
            try
            {
                return StatusCode(200, _diaService.GetDiaByParam(x => x.DiaId == id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno. - " + ex.Message);
            }
        }

        // GET: api/ListarDias
        [HttpGet(nameof(ListarDias))]
        [SwaggerOperation(
            Summary = "Lista de Dias")]
        public ActionResult ListarDias()
        {
            try
            {
                return StatusCode(200, _diaService.ListarDias());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno. - " + ex.Message);
            }
        }

    }
}
