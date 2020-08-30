using System;

namespace Heat.Application
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public int StatusId { get; set; }

        // TODO: validar si existe un casos de uso para estos campos
        public string UserCreated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
