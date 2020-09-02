using DinizAPI.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DinizAPI.Domain.Models.Api
{
    public class RequestDiaHorarioAceite
    {
        public Nullable<int> DiaHorarioAceiteId { get; set; }
        public Nullable<int> LoginId { get; set; }

        [Required(ErrorMessage = "DiaId - Campo obrigatório!")]
        public int DiaId { get; set; }
        [Required(ErrorMessage = "HorarioInicio - Campo obrigatório!")]
        public string HorarioInicio { get; set; }
        [Required(ErrorMessage = "HorarioFim - Campo obrigatório!")]
        public string HorarioFim { get; set; }

        [Required(ErrorMessage = "TipoStatusHorarioId - Campo obrigatório!")]
        public int TipoStatusHorarioId { get; set; }
    }
}
