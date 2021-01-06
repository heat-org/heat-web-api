using System;
using System.Collections.Generic;

namespace Heat.Persistance.Entities
{
    public partial class Ruta
    {
        public Ruta()
        {
            EstacionRuta = new HashSet<EstacionRuta>();
            Parada = new HashSet<Parada>();
            Vehiculo = new HashSet<Vehiculo>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? EstatusId { get; set; }
        public string UserModify { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModify { get; set; }
        public string Color { get; set; }
        public string Code { get; set; }

        public virtual Estatus Estatus { get; set; }
        public virtual ICollection<EstacionRuta> EstacionRuta { get; set; }
        public virtual ICollection<Parada> Parada { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
