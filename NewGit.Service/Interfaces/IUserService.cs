using NewGit.Domain.Configurations;
using NewGit.Domain.Entities;
using NewGit.Service.Helpers;

namespace NewGit.Service.Interfaces
{
    public interface IUserService
    {
        ValueTask<Response<User>> AddUserAsync(User user);
        ValueTask<Response<User>> ModifyUserAsync(long id, User user);
        ValueTask<Response<bool>> RemoveAsync(long id);
        ValueTask<Response<User>> GetUserByIdAsync(long id);
        ValueTask<Response<List<User>>> GetAllUserAsync(
            PaginationParams @params, string search = null);
    }
}
