using DinizAPI.Domain.Interfaces.Repositories;
using DinizAPI.Domain.Interfaces.Services;
using DinizAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Application
{
    public class DiaService : IDiaService
    {
        private readonly IDiaRepository _diaRepository;

        public DiaService(IDiaRepository diaRepository)
        {
            _diaRepository = diaRepository;
        }
        public Dia GetDiaByParam(Func<Dia, bool> lambdaExpression)
        {
            return _diaRepository.GetDiaByParam(lambdaExpression);
        }
        public List<Dia> ListarDias()
        {
            return _diaRepository.ListarDias();
        }
    }
}
