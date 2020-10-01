using System;
using System.Collections.Generic;

namespace Heat.Application.Entities
{
    public partial class Horario
    {
        public Horario()
        {
            Conductor = new HashSet<Conductor>();
        }

        public int Id { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public bool? Sunday { get; set; }
        public bool? Monday { get; set; }
        public bool? Tuesday { get; set; }
        public bool? Wednesday { get; set; }
        public bool? Thursday { get; set; }
        public bool? Friday { get; set; }
        public bool? Saturday { get; set; }
        public int? EstatusId { get; set; }
        public string UserModify { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModify { get; set; }

        public virtual Estatus Estatus { get; set; }
        public virtual ICollection<Conductor> Conductor { get; set; }
    }
}
