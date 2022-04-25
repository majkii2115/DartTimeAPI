namespace DartTimeAPI.Models;
public class MatchStats
{
    public int Id { get; set; }
    public User Player1 { get; set; }
    public int Player1Id { get; set; }
    public User Player2 { get; set; }
    public int Player2Id { get; set; }
    public User Winner { get; set; }
    public int WinnerId { get; set; }

}
