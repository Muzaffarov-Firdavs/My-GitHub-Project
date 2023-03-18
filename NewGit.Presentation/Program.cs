using Microsoft.IdentityModel.Tokens;
using NewGit.Data.IRepositories;
using NewGit.Data.Repositories;
using NewGit.Domain.Entities;
using NewGit.Service.Interfaces;
using NewGit.Service.Services;

IUserRepository userRepository = new UserRepository();
IUserService userService = new UserService();

var user = new User()
{
    Name = "Muhammadjon",
    Username = "M2001",
    Parol = "2001",
    FollowerCount = 0,
    FollowingCount = 0
};
//  insert
await userRepository.InsertUserAsync(user);


//await userService.GetUserByIdAsync(1);

//// get all

//var results = userRepository.SelectAllUsers();
//foreach (var i in results)
//{
//    Console.WriteLine(i.Id + " " + i.Name + " " + i.Username);
//}
