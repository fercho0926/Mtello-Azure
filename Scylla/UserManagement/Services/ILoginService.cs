using Data.Entities.UserManagement;
using UserManagement.Models.Login;

namespace UserManagement.Services
{
    public interface ILoginService
    {
        Task<User> IsEmailCreated(string email);
        Task<bool> Login(LoginDTORequest request, User user);
    }
}
