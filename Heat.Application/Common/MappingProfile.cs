using System;
using AutoMapper;
using Heat.Application.Entities;
using Heat.Application.Vehicles;

namespace Heat.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BitacoraUbicacion,VehiclesLogVM>();
            CreateMap<VehiclesLogVM, BitacoraUbicacion>();
        }
    }
}
