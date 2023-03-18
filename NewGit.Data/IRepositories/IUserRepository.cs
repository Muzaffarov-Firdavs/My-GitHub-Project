using NewGit.Domain.Entities;

namespace NewGit.Data.IRepositories
{
    public interface IUserRepository
    {
        ValueTask<User> InsertUserAsync(User user);
        ValueTask<User> UpdateUserAsync(User user);
        ValueTask<bool> DeleteUserAsync(long id);
        ValueTask<User> SelectUserAsync(long id);
        IQueryable<User> SelectAllUsers();
    }
}
