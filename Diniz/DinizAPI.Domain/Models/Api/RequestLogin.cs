using DinizAPI.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DinizAPI.Domain.Models.Api
{
    public class RequestLogin
    {

        [Required(ErrorMessage = "NomeUsuario - Campo obrigatório!")]
        [MaxLength(30, ErrorMessage = "NomeUsuario - Tamanho maximo de caracteres aceito : 30 ")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "Cpf - Campo obrigatório!")]
        [MaxLength(11, ErrorMessage = "Cpf - Cpf inválido ")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "SenhaUsuario - Campo obrigatório!")]
        [MaxLength(15, ErrorMessage = "SenhaUsuario - Tamanho maximo de caracteres aceito : 15 ")]
        public string SenhaUsuario { get; set; }

        [Required(ErrorMessage = "EmailUsuario - Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "EmailUsuario - Tamanho maximo de caracteres aceito : 20 ")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "EmailUsuario - Email inválido!")]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "DataNascimento - Campo obrigatório!")]
        [DataType(DataType.Date)]
        //[RegularExpression(@"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$", ErrorMessage = "DataNascimento - Aceito apenas o formato yyyy-mm-dd")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Admin - Campo obrigatório!")]
        public bool Admin { get; set; }

        [Required(ErrorMessage = "Ativo - Campo obrigatório!")]
        public bool Ativo { get; set; }
    }
}
