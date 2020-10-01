using System.Threading.Tasks;

namespace Heat.Application.Users
{
    public interface IUserService
    {
        UsuarioVm Login(UsuarioVm viewModel);
        Task<UsuarioVm> RegisterAsync(UsuarioVm viewModel);
    }
}
