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
            CreateMap<TipoReporte, TypeReportDTO>().ForMember(dest => dest.Description,
                                                        opt => opt.MapFrom(src => src.Descripcion))
                                                   .ForMember(dest => dest.ID,
                                                        opt => opt.MapFrom(src => src.Id));
            CreateMap<Vehiculo, VehicleDTO>().ForMember(dest => dest.Description,
                                                        opt => opt.MapFrom(src => src.Descripcion))
                                             .ForMember(dest => dest.Location,
                                                        opt => opt.MapFrom(src => src.Ubicacion))
                                             .ForMember(dest => dest.RouteID,
                                                        opt => opt.MapFrom(src => src.RutaId));
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
            CreateMap<Parada, StopDTO>().ForMember(dest => dest.Description,
                                                   opt => opt.MapFrom(src => src.Descripcion))
                                        .ForMember(dest => dest.Order,
                                                   opt => opt.MapFrom(src => src.Orden.GetValueOrDefault(0)))
                                        .ForMember(dest => dest.StatusID,
                                                   opt => opt.MapFrom(src => src.EstatusId.GetValueOrDefault(0)))
                                        .ForMember(dest => dest.Street,
                                                   opt => opt.MapFrom(src => src.Tramo))
                                        .ForMember(dest => dest.Location,
                                                   opt => opt.MapFrom(src => src.Ubicacion))
                                        .ForMember(dest => dest.Code,
                                                   opt => opt.MapFrom(src => src.Codigo))
                                        .ForMember(dest => dest.RouteID,
                                                   opt => opt.MapFrom(src => src.RutaId))
                                        .ForMember(dest => dest.Route,
                                                   opt => opt.MapFrom(src => src.Ruta.Descripcion))
                                        .ForMember(dest => dest.RouteCode,
                                                   opt => opt.MapFrom(src => src.Ruta.Code));
            CreateMap<Vehiculo, VehicleInfoDTO>().ForMember(dest => dest.Description,
                                                            opt => opt.MapFrom(src => src.Descripcion))
                                                 .ForMember(dest => dest.Plate,
                                                            opt => opt.MapFrom(src => src.Placa))
                                                 .ForMember(dest => dest.ID,
                                                            opt => opt.MapFrom(src => src.Id))
                                                 .ForMember(dest => dest.TypeID,
                                                            opt => opt.MapFrom(src => src.TipoVehiculoId.GetValueOrDefault(0)))
                                                 .ForMember(dest => dest.Type,
                                                            opt => opt.MapFrom(src => src.TipoVehiculo.Descripcion))
                                                 .ForMember(dest => dest.RouteID,
                                                            opt => opt.MapFrom(src => src.RutaId))
                                                 .ForMember(dest => dest.Route,
                                                            opt => opt.MapFrom(src => src.Ruta.Descripcion))
                                                 .ForMember(dest => dest.Location,
                                                            opt => opt.MapFrom(src => src.Ubicacion))
                                                 .ForMember(dest => dest.ConductorID,
                                                            opt => opt.MapFrom(src => src.ConductorActualId))
                                                 .ForMember(dest => dest.Conductor,
                                                            opt => opt.MapFrom(src => src.ConductorActual.Nombre))
                                                 .ForMember(dest => dest.Rating,
                                                            opt => opt.MapFrom(src => src.ConductorActual.Rating))
                                                 .ForMember(dest => dest.DateEntryConductor,
                                                            opt => opt.MapFrom(src => src.ConductorActual.FechaIngreso.GetValueOrDefault().ToString("MMM yyyy")))
                                                 .ForMember(dest => dest.PhotoConductor,
                                                            opt => opt.MapFrom(src => src.ConductorActual.Foto));
            CreateMap<Comentario, ReviewDTO>().ForMember(dest => dest.ID,
                                                         opt => opt.MapFrom(src => src.Id))
                                              .ForMember(dest => dest.Text,
                                                         opt => opt.MapFrom(src => src.Texto))
                                              .ForMember(dest => dest.Date,
                                                         opt => opt.MapFrom(src => src.DateCreated.GetValueOrDefault().ToString("dd/MM/yyyy hh:mm tt")));
            CreateMap<VehiculoDetalle, VehicleInfoDetailDTO>().ForMember(dest => dest.VehicleID,
                                                                         opt => opt.MapFrom(src => src.VehiculoId))
                                                              .ForMember(dest => dest.AtributteID,
                                                                         opt => opt.MapFrom(src => src.AtributoId))
                                                              .ForMember(dest => dest.Description,
                                                                         opt => opt.MapFrom(src => src.Atributo.Descripcion));
        }
    }
}