using System;
using System.Collections.Generic;

namespace Heat.Application.Entities
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            BitacoraUbicacion = new HashSet<BitacoraUbicacion>();
            VehiculoDetalle = new HashSet<VehiculoDetalle>();
        }

        public int Id { get; set; }
        public string Placa { get; set; }
        public int? TipoVehiculoId { get; set; }
        public int? ConductorActualId { get; set; }
        public string Estatus { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public int? RutaId { get; set; }
        public int? EstatusId { get; set; }
        public string UserModify { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModify { get; set; }

        public virtual Conductor ConductorActual { get; set; }
        public virtual Estatus EstatusNavigation { get; set; }
        public virtual Ruta Ruta { get; set; }
        public virtual TipoVehiculo TipoVehiculo { get; set; }
        public virtual ICollection<BitacoraUbicacion> BitacoraUbicacion { get; set; }
        public virtual ICollection<VehiculoDetalle> VehiculoDetalle { get; set; }
    }
}
