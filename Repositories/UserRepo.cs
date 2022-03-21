using AutoMapper;
using DartTimeAPI.Data;
using DartTimeAPI.DTOs;
using DartTimeAPI.Models;
using DartTimeAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DartTimeAPI.Repositories;
public class UserRepo : IUserRepo
{
    #region Variables
    public readonly DataContext _context;
    public readonly IMapper _mapper;
    #endregion

    #region Constructor
    public UserRepo(DataContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }
    #endregion

    #region Methods
    public async Task<bool> DoesUserExist(string username) 
    {
        return await _context.Users.AnyAsync(x => x.Username == username);
    }
    public async Task<UserDTO> CreateUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> LoginUser(string username, string password)
    {
        return null;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    #endregion
}
