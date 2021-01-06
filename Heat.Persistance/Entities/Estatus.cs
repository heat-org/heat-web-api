using System;
using System.Collections.Generic;

namespace Heat.Persistance.Entities
{
    public partial class Estatus
    {
        public Estatus()
        {
            AtributosVehiculo = new HashSet<AtributosVehiculo>();
            Comentario = new HashSet<Comentario>();
            Conductor = new HashSet<Conductor>();
            Estacion = new HashSet<Estacion>();
            EstacionRuta = new HashSet<EstacionRuta>();
            Horario = new HashSet<Horario>();
            Parada = new HashSet<Parada>();
            Reporte = new HashSet<Reporte>();
            Ruta = new HashSet<Ruta>();
            TipoReporte = new HashSet<TipoReporte>();
            TipoVehiculo = new HashSet<TipoVehiculo>();
            Usuario = new HashSet<Usuario>();
            Vehiculo = new HashSet<Vehiculo>();
            VehiculoDetalle = new HashSet<VehiculoDetalle>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Entidad { get; set; }
        public bool? IsDeleted { get; set; }
        public string UserModify { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModify { get; set; }

        public virtual ICollection<AtributosVehiculo> AtributosVehiculo { get; set; }
        public virtual ICollection<Comentario> Comentario { get; set; }
        public virtual ICollection<Conductor> Conductor { get; set; }
        public virtual ICollection<Estacion> Estacion { get; set; }
        public virtual ICollection<EstacionRuta> EstacionRuta { get; set; }
        public virtual ICollection<Horario> Horario { get; set; }
        public virtual ICollection<Parada> Parada { get; set; }
        public virtual ICollection<Reporte> Reporte { get; set; }
        public virtual ICollection<Ruta> Ruta { get; set; }
        public virtual ICollection<TipoReporte> TipoReporte { get; set; }
        public virtual ICollection<TipoVehiculo> TipoVehiculo { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
        public virtual ICollection<VehiculoDetalle> VehiculoDetalle { get; set; }
    }
}
