using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DinizAPI.Domain.Models.Api;
using DinizAPI.Domain.Models.Entities;

namespace DinizAPI.Application.AutoMapper.Profiles
{
    public class LoginMappingProfile : Profile
    {
        public LoginMappingProfile()
        {
            CreateMap<Login, ResponseLogin>()
                .ForMember(dest => dest.LoginId, a => a.MapFrom(src => src.LoginId))
                .ForMember(dest => dest.NomeUsuario, a => a.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Email, a => a.MapFrom(src => src.Email));



            CreateMap<RequestLogin, Login>()
                .ForMember(dest => dest.Email, a => a.MapFrom(src => src.Email))
                .ForMember(dest => dest.Senha, a => a.MapFrom(src => src.Senha))
                .ForMember(dest => dest.DataNascimento, a => a.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.Admin, a => a.MapFrom(src => src.Admin))
                .ForMember(dest => dest.Ativo, a => a.MapFrom(src => src.Ativo))
                .ForMember(dest => dest.Nome, a => a.MapFrom(src => src.Nome));
        }




    }
}
