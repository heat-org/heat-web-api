using System;

namespace Heat.Application.Entities
{
    public partial class Parada
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int? Orden { get; set; }
        public string Tramo { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public int? RutaId { get; set; }
        public int? EstatusId { get; set; }
        public string UserModify { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModify { get; set; }

        public virtual Estatus Estatus { get; set; }
        public virtual Ruta Ruta { get; set; }
    }
}
