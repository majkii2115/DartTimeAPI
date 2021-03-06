using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using DartTimeAPI.DTOs.UserAuth;
using DartTimeAPI.Models;
using DartTimeAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DartTimeAPI.Controllers;

public class UserAuthController : BaseApiController
{
    #region Variables
    private readonly IUserRepo _userRepo;
    private readonly IMapper _mapper;
    private readonly ITokenRepo _tokenRepo;
    #endregion

    #region Constructor
    public UserAuthController(IUserRepo userRepo, IMapper mapper, ITokenRepo tokenRepo)
    {
        _tokenRepo = tokenRepo;
        _mapper = mapper;
        _userRepo = userRepo;
    }
    #endregion

    #region Endpoints

    [HttpPost("register")]
    public async Task<ActionResult> RegisterUser([FromBody] RegisterDTO registerDTO) 
    {
        if(await _userRepo.DoesUserExist(registerDTO.Username.ToLower())) return BadRequest("User already exists.");
        
        var user = _mapper.Map<User>(registerDTO);
        user.Username = user.Username.ToLower();

        using var hmac = new HMACSHA512();

        user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password));
        user.PasswordSalt = hmac.Key;

        var userDTO = await _userRepo.CreateUser(user);
        if(userDTO != null) return Ok(new {
            user = userDTO,
            token = _tokenRepo.CreateToken(userDTO)
        });
        else return BadRequest("Something went wrong. Try again.");
    }

    [HttpPost("login")]
    public async Task<ActionResult> LoginUser([FromBody] LoginDTO loginDTO)
    {
        var user = await _userRepo.LoginUser(loginDTO.Username, loginDTO.Password);
        
        if(user == null) return BadRequest("Invalid password or username");

        return Ok(new {
            user = user,
            token = _tokenRepo.CreateToken(user)
        });
    }
    #endregion
}