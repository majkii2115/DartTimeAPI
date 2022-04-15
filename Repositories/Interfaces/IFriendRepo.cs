using DartTimeAPI.DTOs.Friend;

namespace DartTimeAPI.Repositories.Interfaces;
public interface IFriendRepo
{
    Task AddFriend(int userId, int friendId);
    Task<bool> AreAlreadyFriend(int userId, int friendId);
    Task<List<FriendshipDTO>> GetFriends(int userId);
}