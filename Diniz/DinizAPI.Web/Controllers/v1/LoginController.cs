using AutoMapper;
using DinizAPI.Domain.Enuns;
using DinizAPI.Domain.Interfaces.Services;
using DinizAPI.Domain.Models.Api;
using DinizAPI.Domain.Models.Entities;
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

        // GET: api/Login
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        [SwaggerOperation(
            Summary = "Execução de Cadastro de Login.")]
        [ProducesResponseType(statusCode: 200, Type = typeof(ResponseLogin))]
        [ProducesResponseType(statusCode: 500, Type = typeof(ResponseLogin))]
        [ProducesResponseType(statusCode: 400, Type = typeof(ResponseLogin))]
        [ProducesResponseType(statusCode: 404, Type = typeof(ResponseLogin))]
        public async Task<ActionResult<string>> Post(
            [FromBody][Required][SwaggerParameter("Objeto de requisição")] RequestLogin request)
        {
            var statusApi = TipoStatusAPIEnum.Sucesso;
            try
            {
                if (ModelState.IsValid)
                {
                    // BT ATIVO  - LOgin
                    //TODO = mapeamento login - requestLogin -- validar email ja cadastrado, implementação de envio de email! 
                    //NEXT STEeP Horarios - mapeamento da tabela Horarios

                    var ret = _loginService.CadastroLogin(_mapper.Map<Login>(request));

                    return TratarTipoRetorno(ResponseLogin.FromModelState(statusApi, request.NomeUsuario + " - Adicionado com sucesso !"));
                }
                var erros = ModelState.Values.SelectMany(m => m.Errors);
                return TratarTipoRetorno(ResponseLogin.FromModelState(statusApi, erros.Select(x => x.ErrorMessage).ToArray()), request);
            }
            catch(Exception ex)
            {
                statusApi = TipoStatusAPIEnum.ErroInterno;
                return TratarTipoRetorno(ResponseLogin.FromModelState(statusApi), request);
            }
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        private ActionResult<string> TratarTipoRetorno(ResponseLogin response, RequestLogin request = null)
        {
            switch (response.IdStatus)
            {
                case TipoStatusAPIEnum.Sucesso:
                    return Ok(response);

                case TipoStatusAPIEnum.ErroInterno:
                    return StatusCode(500, response);

                default:
                    return StatusCode(500, response);
            }
        }
    }
}
