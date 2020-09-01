using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Domain.Models.Entities
{
    public class LoginHorario
    {

        public int LoginHorarioId { get; set; }
        public int LoginId { get; set; }
        public int HorarioId { get; set; }
        public Login Login { get; set; }
        public Horario Horario { get; set; }
    }
}
