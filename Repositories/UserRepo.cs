using DartTime.DTOs;
using DartTime.Models;
using DartTime.Repositories.Interfaces;

namespace DartTime.Repositories;
public class UserRepo : IUserRepo
{
    public Task<UserDTO> CreateUser(User user)
    {
        return null;
    }

    public Task<UserDTO> LoginUser(string username, string password)
    {
        return null;
    }

    public Task<bool> SaveChangesAsync()
    {
        return null;
    }
}
