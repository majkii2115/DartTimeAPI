namespace DartTime.Models;
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Firstname { get; set; }
    public string Surname { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string Description { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Email { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime DateOfBirth { get; set; }
}