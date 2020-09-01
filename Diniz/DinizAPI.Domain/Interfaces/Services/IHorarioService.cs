using DinizAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Domain.Interfaces.Services
{
    public interface IHorarioService
    {
        Horario CadastroHorario(Horario horario);

        Horario GetHorario(int idHorario);

        Horario GetHorarioByParam(Func<Horario, bool> lambdaExpression);

        List<Horario> ListarHorario();

        void DeletarHorario(Horario horario);
    }
}
