using System;
using System.Collections.Generic;

namespace Heat.Application.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Comentario = new HashSet<Comentario>();
            DateCreated = DateTime.Now;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public int? EstatusId { get; set; }
        public string UserModify { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserCreated { get; set; }
        public DateTime? DateModify { get; set; }

        public virtual Estatus Estatus { get; set; }
        public virtual ICollection<Comentario> Comentario { get; set; }
    }
}
