using DinizAPI.Domain.Interfaces.Repositories;
using DinizAPI.Domain.Interfaces.Services;
using DinizAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Application
{
    public class HorarioService : IHorarioService
    {
        private readonly IHorarioRepository _horarioRepository;

        public HorarioService(IHorarioRepository horarioRepository)
        {
            _horarioRepository = horarioRepository;
        }

        public Horario CadastroHorario(Horario horario)
        {
            return _horarioRepository.CadastroHorario(horario);
        }

        public void DeletarHorario(Horario horario)
        {
            _horarioRepository.DeletarHorario(horario);
        }

        public Horario GetHorario(int idHorario)
        {
            return _horarioRepository.GetHorarioByParam(x => x.HorarioId == idHorario);
        }

        public List<Horario> ListarHorario()
        {
            return _horarioRepository.ListarHorario();
        }
        public Horario GetHorarioByParam(Func<Horario, bool> lambdaExpression)
        {
            return _horarioRepository.GetHorarioByParam(lambdaExpression);
        }

    }
}
