using System;
using System.Collections.Generic;

namespace Heat.Application.Entities
{
    public partial class AtributosVehiculo
    {
        public AtributosVehiculo()
        {
            VehiculoDetalle = new HashSet<VehiculoDetalle>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? EstatusId { get; set; }
        public string UserModify { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModify { get; set; }

        public virtual Estatus Estatus { get; set; }
        public virtual ICollection<VehiculoDetalle> VehiculoDetalle { get; set; }
    }
}
