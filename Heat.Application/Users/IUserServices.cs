namespace Heat.Application.Users
{
    public interface IUserService
    {
        User Login(User viewModel);
        User Register(User viewModel);
    }
}
