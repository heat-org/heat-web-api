using System;
using System.Collections.Generic;

namespace Heat.Application.Entities
{
    public partial class Conductor
    {
        public Conductor()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string Foto { get; set; }
        public string Telefono { get; set; }
        public string CodigoEmpleado { get; set; }
        public int? HorarioId { get; set; }
        public int? EstatusId { get; set; }
        public string UserModify { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModify { get; set; }

        public virtual Estatus Estatus { get; set; }
        public virtual Horario Horario { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
