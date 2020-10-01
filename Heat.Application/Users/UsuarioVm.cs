using System;
namespace Heat.Application.Users
{
    public class UsuarioVm
    {
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sexo { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }

        public UsuarioVm()
        {
        }
    }
}
