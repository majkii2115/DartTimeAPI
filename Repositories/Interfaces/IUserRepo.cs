using DartTime.DTOs;
using DartTime.Models;

namespace DartTime.Repositories.Interfaces;
public interface IUserRepo
{
    Task<UserDTO> CreateUser(User user);
    Task<UserDTO> LoginUser(string username, string password);
    Task<bool> SaveChangesAsync();
}