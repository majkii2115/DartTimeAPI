namespace DartTimeAPI.Models;
public class Friendship
{
    public User User { get; set; }
    public int UserId { get; set; }

    public User UserFriend { get; set; }
    public int UserFriendId { get; set; }
}