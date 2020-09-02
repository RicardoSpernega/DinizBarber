using AutoMapper;
using DinizAPI.Application.AutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace DinizAPI.Application.AutoMapper
{
    class AutoMapperConfig
    {
        private MapperConfiguration _config;

        public AutoMapperConfig()
        {
            Configure();
        }
        private void Configure()
        {
            _config = new MapperConfiguration(ctg =>
                    {
                        ctg.AddProfile<LoginMappingProfile>();
                        ctg.AddProfile<DiaHorarioAceiteMappingProfile>();
                    });
        }
    }
}
