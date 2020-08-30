using DinizAPI.Domain.Interfaces.Repositories;
using DinizAPI.Domain.Interfaces.Services;
using DinizAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Application
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public Login CadastroLogin(Login login)
        {
            return _loginRepository.CadastroLogin(login);
        }

        public void DeletarLogin(Login login)
        {
            _loginRepository.DeletarLogin(login);
        }

        public Login GetLogin(int idLogin)
        {
            return _loginRepository.GetLoginByParam(x => x.LoginId == idLogin);
        }

        public List<Login> ListarLogin()
        {
            return _loginRepository.ListarLogin();
        }
    }
}
