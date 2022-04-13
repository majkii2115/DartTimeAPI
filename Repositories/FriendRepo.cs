using AutoMapper;
using DartTimeAPI.Data;
using DartTimeAPI.DTOs;
using DartTimeAPI.Models;
using DartTimeAPI.Repositories.Interfaces;

namespace DartTimeAPI.Repositories;
public class FriendRepo : IFriendRepo
{
    #region Variables
    public readonly DataContext _context;
    public readonly IMapper _mapper;
    #endregion

    #region Constructor
    public FriendRepo(DataContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }
    #endregion

    #region Methods
    public async Task AddFriend(int userId, int friendId)
    {
        var friendShip = new Friendship {
            UserId = userId,
            UserFriendId = friendId
        };

        await _context.Friendships.AddAsync(friendShip);

        await _context.SaveChangesAsync();        
    }

    #endregion
}