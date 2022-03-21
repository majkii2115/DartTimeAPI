using DartTimeAPI.DTOs;

namespace DartTimeAPI.Repositories.Interfaces;
public interface ITokenRepo
{
    string CreateToken(UserDTO user);
}