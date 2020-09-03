using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DinizAPI.Domain.Models.Entities
{
    public class Login
    {
        public int LoginId { get; set; }
        [Required(ErrorMessage = "Admin - Campo obrigatório!")]
        public bool Admin { get; set; }
        [Required(ErrorMessage = "EmailUsuario - Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "EmailUsuario - Tamanho maximo de caracteres aceito : 20 ")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "EmailUsuario - Email inválido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "SenhaUsuario - Campo obrigatório!")]
        [MaxLength(15, ErrorMessage = "SenhaUsuario - Tamanho maximo de caracteres aceito : 15 ")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Cpf - Campo obrigatório!")]
        [MaxLength(11, ErrorMessage = "Cpf - Cpf inválido ")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "DataNascimento - Campo obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "DataInclusao - Campo obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime DataInclusao { get; set; }

        [Required(ErrorMessage = "NomeUsuario - Campo obrigatório!")]
        [MaxLength(30, ErrorMessage = "NomeUsuario - Tamanho maximo de caracteres aceito : 30 ")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }
        public List<DiaHorarioAceite> DiaHorarioAceites { get; set; }

    }
}
