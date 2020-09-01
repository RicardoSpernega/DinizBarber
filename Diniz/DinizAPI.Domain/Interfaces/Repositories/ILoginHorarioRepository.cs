using DinizAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Domain.Interfaces.Repositories
{
    public interface ILoginHorarioRepository
    {
        LoginHorario CadastroLoginHorario(LoginHorario loginHorario);
        LoginHorario GetLoginHorarioByParam(Func<LoginHorario, bool> lambdaExpression);
        List<LoginHorario> ListarLoginHorarioByParam(Func<LoginHorario, bool> lambdaExpression);
        List<LoginHorario> ListarLoginHorario();
        void DeletarLoginHorario(LoginHorario loginHorario);
    }
}
