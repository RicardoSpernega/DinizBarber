using DinizAPI.Domain.Interfaces.Repositories;
using DinizAPI.Domain.Models.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinizAPI.Infrastructure.Repositories
{
    public class LoginRepository : BaseRepository, IDisposable, ILoginRepository
    {
        public LoginRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public void Dispose()
        {
        }
        public Login CadastroLogin(Login login)
        {
            if(login.LoginId != 0)
            {
                _context.Login.Update(login);
            }
            else
            {
                login.DataInclusao = DateTime.Now;
                _context.Login.Add(login);
            }
            _context.SaveChanges();
            return login;
        }

        public Login GetLoginByParam(Func<Login, bool> lambdaExpression)
        {
            return _context.Login
                    .Where(lambdaExpression).FirstOrDefault();
        }

        public List<Login> ListarLoginByParam(Func<Login, bool> lambdaExpression)
        {
            return _context.Login
                    .Where(lambdaExpression).ToList();
        }

        public List<Login> ListarLogin()
        {
            return _context.Login.ToList();
        }

        public void DeletarLogin(Login login)
        {
            _context.Login.Remove(login);
            _context.SaveChanges();
        }
    }
}
