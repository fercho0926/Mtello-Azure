using Data.Entities.UserManagement;
using UserManagement.Models;
using UserManagement.Models.User;

namespace UserManagement.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<GetUserByIdResponse> GetById(Guid userId);
        Task<CreateUserResponse> Create(CreateUserRequest request);
        Task<bool> IsUserCreated(CreateUserRequest userRequest);
        Task<bool> DeleteById(Guid id);
        Task<bool> Update(UpdateUserRequest request);



    }
}
