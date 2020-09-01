using DinizAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Domain.Interfaces.Repositories
{
    public interface IHorarioRepository
    {
        Horario CadastroHorario(Horario horario);
        Horario GetHorarioByParam(Func<Horario, bool> lambdaExpression);
        List<Horario> ListarHorarioByParam(Func<Horario, bool> lambdaExpression);
        List<Horario> ListarHorario();
        void DeletarHorario(Horario horario);
    }
}
