using DinizAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Domain.Interfaces.Repositories
{
    public interface ILoginRepository
    {
        Login CadastroLogin(Login login);
        Login GetLoginByParam(Func<Login, bool> lambdaExpression);
        List<Login> ListarLoginByParam(Func<Login, bool> lambdaExpression);
        List<Login> ListarLogin();
        void DeletarLogin(Login login);
    }
}
