using AutoMapper;
using DinizAPI.Domain.Models.Api;
using DinizAPI.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Application.AutoMapper.Profiles
{
    class DiaHorarioAceiteMappingProfile : Profile
    {
        public DiaHorarioAceiteMappingProfile()
        {
            CreateMap<DiaHorarioAceite, RequestDiaHorarioAceite>()
                .ForMember(dest => dest.LoginId, a => a.MapFrom(src => src.LoginId))
                .ForMember(dest => dest.DiaId, a => a.MapFrom(src => src.DiaId))
                .ForMember(dest => dest.HorarioFim, a => a.MapFrom(src => src.HorarioFim))
                .ForMember(dest => dest.TipoStatusHorarioId, a => a.MapFrom(src => src.TipoStatusHorarioId))
                .ForMember(dest => dest.DiaHorarioAceiteId, a => a.MapFrom(src => src.DiaHorarioAceiteId))
                .ForMember(dest => dest.HorarioInicio, a => a.MapFrom(src => src.HorarioInicio));



            CreateMap<RequestDiaHorarioAceite, DiaHorarioAceite>()
                .ForMember(dest => dest.LoginId, a => a.MapFrom(src => src.LoginId))
                .ForMember(dest => dest.DiaId, a => a.MapFrom(src => src.DiaId))
                .ForMember(dest => dest.HorarioFim, a => a.MapFrom(src => src.HorarioFim))
                .ForMember(dest => dest.DiaHorarioAceiteId, a => a.MapFrom(src => src.DiaHorarioAceiteId))
                .ForMember(dest => dest.TipoStatusHorarioId, a => a.MapFrom(src => src.TipoStatusHorarioId))
                .ForMember(dest => dest.HorarioInicio, a => a.MapFrom(src => src.HorarioInicio));
        }




    }
}

