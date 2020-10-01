using System;
using System.Collections.Generic;

namespace Heat.Application.Entities
{
    public partial class Reporte
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public int? TipoReporteId { get; set; }
        public int? ComentarioId { get; set; }
        public int? EstatusId { get; set; }
        public string UserModify { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModify { get; set; }

        public virtual Comentario Comentario { get; set; }
        public virtual Estatus Estatus { get; set; }
        public virtual TipoReporte TipoReporte { get; set; }
    }
}
