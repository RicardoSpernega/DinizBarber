using DinizAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Domain.Interfaces.Services
{
    public interface ILoginService
    {
        Login CadastroLogin(Login login);

        Login GetLogin(int idLogin);

        Login GetLoginByParam(Func<Login, bool> lambdaExpression);

        List<Login> ListarLogin();

        void DeletarLogin(Login login);
    }
}
