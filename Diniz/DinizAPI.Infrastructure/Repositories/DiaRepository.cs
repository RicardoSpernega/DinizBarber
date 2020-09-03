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
    public class DiaRepository : BaseRepository, IDisposable, IDiaRepository
    {
        public DiaRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public void Dispose()
        {
        }

        public Dia GetDiaByParam(Func<Dia, bool> lambdaExpression)
        {
            return _context.Dia
                            .AsNoTracking()
                           .Include(x => x.DiaHorarioAceites)
                                   .ThenInclude(x => x.Login)
                            .AsNoTracking()
                           .Where(lambdaExpression).FirstOrDefault();
        }

        public List<Dia> ListarDias()
        {
            return _context.Dia
                            .AsNoTracking()
                            .Include(d => d.DiaHorarioAceites)
                                .ThenInclude(l => l.Login)
                            .AsNoTracking()
                            .ToList();
        }
    }
}
