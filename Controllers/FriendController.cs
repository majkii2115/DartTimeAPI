using DartTimeAPI.DTOs.Friend;
using DartTimeAPI.Extensions;
using DartTimeAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DartTimeAPI.Controllers;

[Authorize]
public class FriendController : BaseApiController
{
    #region Variables
    private readonly IUserRepo _userRepo;
    private readonly IFriendRepo _friendRepo;
    #endregion

    #region Constructor
    public FriendController(IUserRepo userRepo, IFriendRepo friendRepo)
    {
        _friendRepo = friendRepo;
        _userRepo = userRepo;
    }
    #endregion

    #region Endpoints

    [HttpPost("addFriend")]
    public async Task<IActionResult> AddFriend([FromBody] AddFriendDTO addFriendDTO) 
    {
        var username = User.GetUsername();
        var user = await _userRepo.GetUserByUsername(username);
        var friend = await _userRepo.GetUserByUsername(addFriendDTO.Username);

        if(friend != null)
        {
            if(friend.Id == user.Id) return BadRequest("Cannot add yourself to friends.");
            if(await _friendRepo.AreAlreadyFriend(user.Id, friend.Id)) return BadRequest("Users are already friends.");
            await _friendRepo.AddFriend(user.Id, friend.Id);
            return Ok();
        }
        else
        {
            return BadRequest("User not found.");
        }
    }
    #endregion
}