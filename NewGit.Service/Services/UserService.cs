using Microsoft.EntityFrameworkCore;
using NewGit.Data.IRepositories;
using NewGit.Data.Repositories;
using NewGit.Domain.Configurations;
using NewGit.Domain.Entities;
using NewGit.Service.Helpers;
using NewGit.Service.Interfaces;

namespace NewGit.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository = new UserRepository();


        public async ValueTask<Response<User>> AddUserAsync(User user)
        {
            var users = await this.userRepository.SelectAllUsers()
                .ToListAsync();
            User takenUser = users.FirstOrDefault(u => u.Id == user.Id);
            if (takenUser is not null)
                return new Response<User>
                {
                    Code = 404,
                    Message = "User is already existed",
                    Value = user
                };

            var addedUser = await this.userRepository.InsertUserAsync(user);

            return new Response<User>
            {
                Code = 200,
                Message = "Success",
                Value = addedUser
            };
        }

        public async ValueTask<Response<bool>> RemoveAsync(long id)
        {
            User user =
                await this.userRepository.SelectUserAsync(id);
            if (user is null)
                return new Response<bool>
                {
                    Code = 404,
                    Message = "Couldn't find for given ID",
                    Value = false
                };

            await this.userRepository.DeleteUserAsync(id);
            return new Response<bool>
            {
                Code = 200,
                Message = "Success",
                Value = true
            };
        }

        public async ValueTask<Response<List<User>>> GetAllUserAsync(
                            PaginationParams @params, string search = null)
        {
            var users = await this.userRepository.SelectAllUsers()
                .ToListAsync();
            if (users.Count() == 0)
                return new Response<List<User>>
                {
                    Code = 404,
                    Message = "Success",
                    Value = null
                };

            var result = users.Where(user => user.Name
                .Contains(search, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return new Response<List<User>>
            {
                Code = 200,
                Message = "Success",
                Value = result
            };
        }

        public async ValueTask<Response<User>> GetUserByIdAsync(long id)
        {
            User user =
                await this.userRepository.SelectUserAsync(id);
            if (user is null)
                return new Response<User>
                {
                    Code = 404,
                    Message = "Couldn't find for given ID",
                    Value = null
                };

            return new Response<User>()
            {
                Code = 200,
                Message = "Success",
                Value = user
            };
        }

        public async ValueTask<Response<User>> ModifyUserAsync(long id, User user)
        {
            User userClarify =
                await this.userRepository.SelectUserAsync(id);
            if (user is null)
                return new Response<User>
                {
                    Code = 404,
                    Message = "Couldn't find for given ID",
                    Value = null
                };

            var updatedUser = await this.userRepository.UpdateUserAsync(user);
            return new Response<User>
            {
                Code = 200,
                Message = "Success",
                Value = updatedUser
            };
        }

    }
}
