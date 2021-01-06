using System;
using System.Collections.Generic;

namespace Heat.Persistance.Entities
{
    public partial class EstacionRuta
    {
        public int Id { get; set; }
        public int? EstacionId { get; set; }
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
