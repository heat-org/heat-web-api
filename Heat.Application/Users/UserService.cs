using System;
using System.Linq;
using System.Threading.Tasks;
using Heat.Application.Common;
using Heat.Application.Entities;

namespace Heat.Application.Users
{
    public class UserService : IUserService
    {
        private IHeatContext context;

        public UserService(IHeatContext context)
        {
            this.context = context;
        }

        public UsuarioVm Login(UsuarioVm viewModel)
        {
            var user = context.Usuario.SingleOrDefault(x => x.Password == SHA2Hasher.ComputeHash(viewModel.Password) && x.Username == viewModel.Username);
            viewModel.Nombre = user.Nombre;
            viewModel.CorreoElectronico = user.CorreoElectronico;
            viewModel.Sexo = user.Sexo;

            return viewModel;
        }

        public async Task<UsuarioVm> RegisterAsync(UsuarioVm viewModel)
        {
            var usuario = new Usuario();
            usuario.Nombre = viewModel.Nombre;
            usuario.Password = SHA2Hasher.ComputeHash(viewModel.Password);
            usuario.Sexo = viewModel.Sexo;
            usuario.Telefono = viewModel.Telefono;
            usuario.CorreoElectronico = viewModel.CorreoElectronico;
            usuario.Username = viewModel.Username;
            usuario.Apellido = viewModel.Apellido;
            context.Usuario.Add(usuario);
            await context.SaveChangesAsync();
            return viewModel;

        }

       
    }
}
 