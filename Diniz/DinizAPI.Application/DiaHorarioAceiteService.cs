using DinizAPI.Domain.Interfaces.Repositories;
using DinizAPI.Domain.Interfaces.Services;
using DinizAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Application
{
    public class DiaHorarioAceiteService : IDiaHorarioAceiteService
    {
        private readonly IDiaHorarioAceiteRepository _diaHorarioAceiteRepository;

        public DiaHorarioAceiteService(IDiaHorarioAceiteRepository diaHorarioAceiteRepository)
        {
            _diaHorarioAceiteRepository = diaHorarioAceiteRepository;
        }

        public DiaHorarioAceite CadastroDiaHorarioAceite(DiaHorarioAceite diaHorarioAceite)
        {
            if (diaHorarioAceite.TipoStatusHorarioId == 2)
                diaHorarioAceite.DtAceite = DateTime.Now;
            return _diaHorarioAceiteRepository.CadastroDiaHorarioAceite(diaHorarioAceite);
        }

        public DiaHorarioAceite GetDiaHorarioAceiteByParam(Func<DiaHorarioAceite, bool> lambdaExpression)
        {
            return _diaHorarioAceiteRepository.GetDiaHorarioAceiteByParam(lambdaExpression);
        }

        public List<DiaHorarioAceite> ListarDiaHorarioAceite()
        {
            return _diaHorarioAceiteRepository.ListarDiaHorarioAceite();
        }

        public List<DiaHorarioAceite> ListarDiaHorarioAceiteByParam(Func<DiaHorarioAceite, bool> lambdaExpression)
        {
            return _diaHorarioAceiteRepository.ListarDiaHorarioAceiteByParam(lambdaExpression);
        }
    }
}
