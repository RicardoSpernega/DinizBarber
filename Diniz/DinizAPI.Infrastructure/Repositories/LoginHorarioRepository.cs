using DinizAPI.Domain.Interfaces.Repositories;
using DinizAPI.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinizAPI.Infrastructure.Repositories
{
    public class LoginHorarioRepository : BaseRepository, IDisposable, ILoginHorarioRepository
    {
        public LoginHorarioRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public void Dispose()
        {
        }
        public LoginHorario CadastroLoginHorario(LoginHorario loginHorario)
        {
            if (loginHorario.LoginHorarioId != 0)
            {
                _context.LoginHorario.Update(loginHorario);
            }
            else
            {
                _context.LoginHorario.Add(loginHorario);
            }
            _context.SaveChanges();
            return loginHorario;
        }

        public LoginHorario GetLoginHorarioByParam(Func<LoginHorario, bool> lambdaExpression)
        {
            return _context.LoginHorario
                    .AsNoTracking()
                    .Include(l => l.Login)
                    .Include(h => h.Horario)
                    .AsNoTracking()
                    .Where(lambdaExpression).FirstOrDefault();
        }

        public List<LoginHorario> ListarLoginHorarioByParam(Func<LoginHorario, bool> lambdaExpression)
        {
            return _context.LoginHorario
                    .AsNoTracking()
                    .Include(l => l.Login)
                    .Include(h => h.Horario)
                    .AsNoTracking()
                    .Where(lambdaExpression).ToList();
        }

        public List<LoginHorario> ListarLoginHorario()
        {
            return _context.LoginHorario
                    .AsNoTracking()
                    .Include(l => l.Login)
                    .Include(h => h.Horario)
                    .AsNoTracking()
                    .ToList();
        }

        public void DeletarLoginHorario(LoginHorario loginHorario)
        {
            _context.LoginHorario.Remove(loginHorario);
            _context.SaveChanges();
        }
    }
}
