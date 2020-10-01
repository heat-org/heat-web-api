using System;
using System.Collections.Generic;

namespace Heat.Application.Entities
{
    public partial class VehiculoDetalle
    {
        public int Id { get; set; }
        public int? VehiculoId { get; set; }
        public int? AtributoId { get; set; }
        public int? EstatusId { get; set; }
        public string UserModify { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModify { get; set; }

        public virtual AtributosVehiculo Atributo { get; set; }
        public virtual Estatus Estatus { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
