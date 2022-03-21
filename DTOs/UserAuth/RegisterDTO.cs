using System.ComponentModel.DataAnnotations;

namespace DartTimeAPI.DTOs.UserAuth;
public class RegisterDTO
{
    [Required]
    public string Username { get; set; }
    [Required]
    [StringLength(16, MinimumLength = 6)]    
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
}