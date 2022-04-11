using System.Security.Claims;

namespace DartTimeAPI.Extensions;
public static class ClaimsExtensions
{
    public static string GetUserName(this ClaimsPrincipal user) 
    {
        return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}