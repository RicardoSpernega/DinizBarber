
using DinizAPI.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Domain.Models.Api
{
    public class ResponseLogin
    {
        public long LoginId { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string TokenLogin { get; set; } 
        public string[] Detalhes { get; set; }
        public TipoStatusAPIEnum IdStatus { get; set; }
        public static ResponseLogin FromModelState(TipoStatusAPIEnum status, string nomeUsuario = "", string email = "", string Token = "", long loginId = 0)
        {

            return new ResponseLogin
            {
                IdStatus = status,
                LoginId = loginId,
                NomeUsuario = nomeUsuario, 
                TokenLogin = Token,
                Email = email
            };
        }
        public static ResponseLogin FromModelState(TipoStatusAPIEnum status,string[] detalhes)
        {
            return new ResponseLogin
            {
                IdStatus = status,
                Detalhes = detalhes
            };
        }
    }


}
