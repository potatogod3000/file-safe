using Microsoft.AspNetCore.Identity;

namespace safe_api.Dtos;

public class AuthenticationDto: BaseDto
{
    public bool IsAuthenticated { get; set; }

    public IdentityUser? User { get; set; }
    
    public AuthenticationDto()
    {
        IsAuthenticated = false;
    }
}