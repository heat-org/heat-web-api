using System;
using System.Collections.Generic;

namespace Heat.Persistance.Entities
{
    public partial class BitacoraUbicacion
    {
        public int Id { get; set; }
        public int? VehiculoId { get; set; }
        public string Ubicacion { get; set; }
        public DateTime? FechaHora { get; set; }

        public virtual Vehiculo Vehiculo { get; set; }
    }
}
