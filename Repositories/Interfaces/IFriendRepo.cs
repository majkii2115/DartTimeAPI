namespace DartTimeAPI.Repositories.Interfaces;
public interface IFriendRepo
{
    Task AddFriend(int userId, int friendId);
}