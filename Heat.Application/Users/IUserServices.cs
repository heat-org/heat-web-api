using System.Threading.Tasks;

namespace Heat.Application.Users
{
    public interface IUserService
    {
        Task<UsuarioVm> Login(UsuarioVm viewModel);
        Task<UsuarioVm> RegisterAsync(UsuarioVm viewModel);
        Task<UsuarioVm> GetByUserName(string username);
    }
}