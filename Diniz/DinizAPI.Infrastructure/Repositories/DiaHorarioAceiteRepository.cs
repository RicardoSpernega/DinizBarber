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
    public class DiaHorarioAceiteRepository : BaseRepository, IDisposable, IDiaHorarioAceiteRepository
    {
        public DiaHorarioAceiteRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public void Dispose()
        {
        }
        public DiaHorarioAceite CadastroDiaHorarioAceite(DiaHorarioAceite diaHorarioAceite)
        {
            if(diaHorarioAceite.DiaHorarioAceiteId != 0)
            {
                diaHorarioAceite.DtInclusao = DateTime.Now;
                _context.DiaHorarioAceite.Update(diaHorarioAceite);
            }            
            else
            {
                diaHorarioAceite.DtInclusao = DateTime.Now;
                _context.DiaHorarioAceite.Add(diaHorarioAceite);
            }

            _context.SaveChanges();
            return diaHorarioAceite;
        }
        public List<DiaHorarioAceite> ListarLoginByParam(Func<DiaHorarioAceite, bool> lambdaExpression)
        {
            return _context.DiaHorarioAceite
                    .Where(lambdaExpression).ToList();
        }

        public DiaHorarioAceite GetDiaHorarioAceiteByParam(Func<DiaHorarioAceite, bool> lambdaExpression)
        {
            return _context.DiaHorarioAceite
                    .Where(lambdaExpression).FirstOrDefault();
        }


        public List<DiaHorarioAceite> ListarDiaHorarioAceite()
        {
            return _context.DiaHorarioAceite
                            .Include(login => login.Login)
                            .Include(dia => dia.Dia)
                            .ToList();
        }

        public List<DiaHorarioAceite> ListarDiaHorarioAceiteByParam(Func<DiaHorarioAceite, bool> lambdaExpression)
        {
            return _context.DiaHorarioAceite
                            .Include(login => login.Login)
                            .Include(dia => dia.Dia)
                            .Where(lambdaExpression).ToList();
        }
    }
}
