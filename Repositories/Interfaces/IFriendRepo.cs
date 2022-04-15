namespace DartTimeAPI.Repositories.Interfaces;
public interface IFriendRepo
{
    Task AddFriend(int userId, int friendId);
    Task<bool> AreAlreadyFriend(int userId, int friendId);
}