using DinizAPI.Domain.Interfaces.Repositories;
using DinizAPI.Domain.Interfaces.Services;
using DinizAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Application
{
    public class LoginHorarioService : ILoginHorarioService
    {
        private readonly ILoginHorarioRepository _loginHorarioRepository;

        public LoginHorarioService(ILoginHorarioRepository loginHorarioRepository)
        {
            _loginHorarioRepository = loginHorarioRepository;
        }

        public LoginHorario CadastroLoginHorario(LoginHorario loginHarario)
        {
            return _loginHorarioRepository.CadastroLoginHorario(loginHarario);
        }

        public void DeletarLoginHorario(LoginHorario loginHarario)
        {
            _loginHorarioRepository.DeletarLoginHorario(loginHarario);
        }

        public LoginHorario GetLoginHorario(int idLoginHorario)
        {
            return _loginHorarioRepository.GetLoginHorarioByParam(x => x.LoginHorarioId == idLoginHorario);
        }

        public List<LoginHorario> ListarLoginHorario()
        {
            return _loginHorarioRepository.ListarLoginHorario();
        }
        public LoginHorario GetLoginHorarioByParam(Func<LoginHorario, bool> lambdaExpression)
        {
            return _loginHorarioRepository.GetLoginHorarioByParam(lambdaExpression);
        }

    }
}
