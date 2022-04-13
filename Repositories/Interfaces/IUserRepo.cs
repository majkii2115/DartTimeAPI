using DartTimeAPI.DTOs;
using DartTimeAPI.Models;

namespace DartTimeAPI.Repositories.Interfaces;
public interface IUserRepo
{
    Task<UserDTO> CreateUser(User user);
    Task<UserDTO> LoginUser(string username, string password);
    Task<UserDTO> GetUserByUsername(string username);
    Task<bool> DoesUserExist(string username);
    Task<bool> SaveChangesAsync();
}