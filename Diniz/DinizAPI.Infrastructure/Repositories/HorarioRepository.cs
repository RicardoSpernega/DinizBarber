using DinizAPI.Domain.Interfaces.Repositories;
using DinizAPI.Domain.Models.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DinizAPI.Infrastructure.Repositories
{
    public class HorarioRepository : BaseRepository, IDisposable, IHorarioRepository
    {
        public HorarioRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public void Dispose()
        {
        }
        public Horario CadastroHorario(Horario horario)
        {
            if (horario.HorarioId != 0)
            {
                _context.Horario.Update(horario);
            }
            else
            {
                _context.Horario.Add(horario);
            }
            _context.SaveChanges();
            return horario;
        }

        public Horario GetHorarioByParam(Func<Horario, bool> lambdaExpression)
        {
            return _context.Horario
                    .Where(lambdaExpression).FirstOrDefault();
        }

        public List<Horario> ListarHorarioByParam(Func<Horario, bool> lambdaExpression)
        {
            return _context.Horario
                    .Where(lambdaExpression).ToList();
        }

        public List<Horario> ListarHorario()
        {
            return _context.Horario.ToList();
        }

        public void DeletarHorario(Horario horario)
        {
            _context.Horario.Remove(horario);
            _context.SaveChanges();
        }
    }
}
