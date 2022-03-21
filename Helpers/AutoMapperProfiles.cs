using AutoMapper;
using DartTimeAPI.DTOs;
using DartTimeAPI.DTOs.UserAuth;
using DartTimeAPI.Models;

namespace DartTimeAPI.Helpers;
public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<RegisterDTO, User>();
        CreateMap<User, UserDTO>();
    }
}