using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Domain.Models.Entities
{
    public class DiaHorarioAceite
    {
        public int DiaHorarioAceiteId { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioFim { get; set; }
        public int TipoStatusHorarioId { get; set; }
        public DateTime DtInclusao { get; set; }
        public DateTime? DtAceite { get; set; }
        public Nullable<int> LoginId { get; set; }
        public int DiaId { get; set; }
        public virtual Login Login { get; set; }
        public virtual Dia Dia { get; set; }
    }
}
