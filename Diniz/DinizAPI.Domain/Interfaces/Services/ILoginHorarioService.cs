using DinizAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Domain.Interfaces.Services
{
    public interface ILoginHorarioService
    {
        LoginHorario CadastroLoginHorario(LoginHorario loginHorario);
        LoginHorario GetLoginHorario(int idLoginHorario);
        LoginHorario GetLoginHorarioByParam(Func<LoginHorario, bool> lambdaExpression);
        List<LoginHorario> ListarLoginHorario();
        void DeletarLoginHorario(LoginHorario loginHorario);
    }
}
