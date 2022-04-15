using System.Security.Cryptography;
using System.Text;
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
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        if(user != null)
        {
            using var hmac = new HMACSHA512(user.PasswordSalt);

            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for(int i = 0; i < passwordHash.Length; i++)
            {
                if(passwordHash[i] != user.PasswordHash[i]) return null;
            }
        }
        else 
        {
            return null;
        }

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    
    public async Task<UserDTO> GetUserByUsername(string username)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        if(user != null)
        {
            return _mapper.Map<UserDTO>(user);
        }
        return null;
    }
    #endregion
}
