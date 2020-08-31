using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DinizAPI.Domain.Models.Api
{
    public class RequestAuth
    {
        [Required(ErrorMessage = "EmailUsuario - Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "EmailUsuario - Tamanho maximo de caracteres aceito : 20 ")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "EmailUsuario - Email inválido!")]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "SenhaUsuario - Campo obrigatório!")]
        [MaxLength(15, ErrorMessage = "SenhaUsuario - Tamanho maximo de caracteres aceito : 15 ")]
        public string SenhaUsuario { get; set; }
    }
}
