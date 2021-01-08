using System;
namespace Heat.Application.Vehicles
{
    public class VehiclesVM
    {
        public string Placa { get; set; }
        public int? TipoVehiculoId { get; set; }
        public int? ConductorActualId { get; set; }
        public string Estatus { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public int? RutaId { get; set; }

        public VehiclesVM()
        {
        }
    }

    public class VehiclesLogVM
    {
        public int VehiculoId { get; set; }
        public string Ubicacion { get; set; }
        public DateTime? FechaHora { get; set; } = DateTime.Now;

     
    }
}
