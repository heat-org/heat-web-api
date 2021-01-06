using Heat.Application.Common;
using Heat.Persistance.Context;
using Heat.Persistance.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Heat.Application.Users
{
    public class UserService : BaseService, IUserService
    {
        public UserService(HeatContext context) : base(context) { }
        public async Task<UsuarioVm> Login(UsuarioVm viewModel)
        {
            var user = (await _unit.Usuario.Get(filter: x => x.Password == SHA2Hasher.ComputeHash(viewModel.Password) 
                                                        && x.Username == viewModel.Username)).FirstOrDefault();

            if (user == null)
                return null;

            viewModel.Nombre = user.Nombre;
            viewModel.Apellido = user.Apellido;
            viewModel.CorreoElectronico = user.CorreoElectronico;
            viewModel.Sexo = user.Sexo;
            viewModel.Telefono = user.Telefono;

            return viewModel;
        }
        public async Task<UsuarioVm> RegisterAsync(UsuarioVm viewModel)
        {
            var usuario = new Usuario();
            var olduser = (await _unit.Usuario.Get(filter: p => p.CorreoElectronico.ToUpper() == viewModel.CorreoElectronico.ToUpper())).FirstOrDefault();

            if (olduser != null)
                return viewModel;

            usuario.Nombre = viewModel.Nombre;
            usuario.Password = SHA2Hasher.ComputeHash(viewModel.Password);
            usuario.Sexo = viewModel.Sexo;
            usuario.Telefono = viewModel.Telefono;
            usuario.CorreoElectronico = viewModel.CorreoElectronico;
            usuario.Username = viewModel.Username;
            usuario.Apellido = viewModel.Apellido;
            await _unit.Usuario.Insert(usuario);
            await _unit.Usuario.SaveChanges();
            return viewModel;
        }
        public async Task<UsuarioVm> GetByUserName(string username)
        {
            var user = (await _unit.Usuario.Get(filter: i => i.Username == username)).FirstOrDefault();
            var viewModel = new UsuarioVm();
            viewModel.Nombre = user.Nombre;
            viewModel.Apellido = user.Apellido;
            viewModel.CorreoElectronico = user.CorreoElectronico;
            viewModel.Sexo = user.Sexo;
            viewModel.Telefono = user.Telefono;

            return viewModel;
        }
    }
}