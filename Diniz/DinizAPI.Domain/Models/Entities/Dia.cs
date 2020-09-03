using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Domain.Models.Entities
{
    public class Dia
    {
        public int DiaId { get; set; }
        public DateTime DtDia { get; set; }

        public List<DiaHorarioAceite> DiaHorarioAceites { get; set; }

        public Dia()
        {
            this.DiaHorarioAceites = new List<DiaHorarioAceite>();
        }
    }
}
