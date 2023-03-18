using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NewGit.Data.Contexts;
using NewGit.Data.IRepositories;
using NewGit.Domain.Entities;

namespace NewGit.Data.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext appDbContext = new AppDbContext();

        public async ValueTask<User> InsertUserAsync(User user)
        {
            EntityEntry<User> entity = await this.appDbContext.Users.AddAsync(user);
            await this.appDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public async ValueTask<User> UpdateUserAsync(User user)
        {
            EntityEntry<User> entity = this.appDbContext.Users.Update(user);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }

        public async ValueTask<bool> DeleteUserAsync(long id)
        {
            User entity =
                await this.appDbContext.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
            if (entity is null)
                return false;

            this.appDbContext.Users.Remove(entity);
            await this.appDbContext.SaveChangesAsync();
            return true;
        }

        public async ValueTask<User> SelectUserAsync(long id)
        {
            return await this.appDbContext.Users.FirstOrDefaultAsync(u => u.Id.Equals(id));
        }

        public IQueryable<User> SelectAllUsers()
        {
            var query = "select * from \"Users\"";
            return this.appDbContext.Users.FromSqlRaw(query);
        }
    }
}
