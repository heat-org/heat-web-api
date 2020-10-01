using System;
using System.Collections.Generic;

namespace Heat.Application.Entities
{
    public partial class Comentario
    {
        public Comentario()
        {
            Reporte = new HashSet<Reporte>();
        }

        public int Id { get; set; }
        public string Texto { get; set; }
        public int? UsuarioId { get; set; }
        public int? IndReportado { get; set; }
        public int? EstatusId { get; set; }
        public string UserModify { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModify { get; set; }

        public virtual Estatus Estatus { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Reporte> Reporte { get; set; }
    }
}
