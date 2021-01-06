using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Heat.Persistance.Entities
{
    public interface IHeatContext
    {
        DbSet<AtributosVehiculo> AtributosVehiculo { get; set; }
        DbSet<BitacoraUbicacion> BitacoraUbicacion { get; set; }
        DbSet<Comentario> Comentario { get; set; }
        DbSet<Conductor> Conductor { get; set; }
        DbSet<Estacion> Estacion { get; set; }
        DbSet<EstacionRuta> EstacionRuta { get; set; }
        DbSet<Estatus> Estatus { get; set; }
        DbSet<Horario> Horario { get; set; }
        DbSet<Parada> Parada { get; set; }
        DbSet<Reporte> Reporte { get; set; }
        DbSet<Ruta> Ruta { get; set; }
        DbSet<TipoReporte> TipoReporte { get; set; }
        DbSet<TipoVehiculo> TipoVehiculo { get; set; }
        DbSet<Usuario> Usuario { get; set; }
        DbSet<Vehiculo> Vehiculo { get; set; }
        DbSet<VehiculoDetalle> VehiculoDetalle { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
