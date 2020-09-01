using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Domain.Models.Entities
{
    public class Horario
    {
        public int HorarioId { get; set; }
        public DateTime Dia { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioFim { get; set; }
    }
}
