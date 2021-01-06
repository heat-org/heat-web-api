using System;
using AutoMapper;
using Heat.Application.Vehicles;
using Heat.Persistance.Entities;

namespace Heat.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BitacoraUbicacion, VehiclesLogVM>();
            CreateMap<VehiclesLogVM, BitacoraUbicacion>();
            CreateMap<Ruta, RutaDTO>().ForMember(dest => dest.Description,
                                                 opt => opt.MapFrom(src => src.Descripcion))
                                      .ForMember(dest => dest.ID,
                                                 opt => opt.MapFrom(src => src.Id))
                                      .ForMember(dest => dest.Codigo,
                                                 opt => opt.MapFrom(src => src.Code));
            CreateMap<SP_Buscar_RutasInfo, RutaDTO>().ForMember(dest => dest.Description,
                                                 opt => opt.MapFrom(src => src.Descripcion))
                                                     .ForMember(dest => dest.Codigo,
                                                 opt => opt.MapFrom(src => src.Code))
                                                    .ForMember(dest => dest.From,
                                                 opt => opt.MapFrom(src => src.Desde))
                                                    .ForMember(dest => dest.To,
                                                 opt => opt.MapFrom(src => src.Hasta));
        }
    }
}
