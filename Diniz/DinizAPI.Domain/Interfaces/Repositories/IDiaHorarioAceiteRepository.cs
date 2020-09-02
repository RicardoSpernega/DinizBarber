using DinizAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Domain.Interfaces.Repositories
{
    public interface IDiaHorarioAceiteRepository
    {
        DiaHorarioAceite CadastroDiaHorarioAceite(DiaHorarioAceite diaHorarioAceite);
        List<DiaHorarioAceite> ListarDiaHorarioAceite();
        List<DiaHorarioAceite> ListarDiaHorarioAceiteByParam(Func<DiaHorarioAceite, bool> lambdaExpression);
        DiaHorarioAceite GetDiaHorarioAceiteByParam(Func<DiaHorarioAceite, bool> lambdaExpression);

    }
}
