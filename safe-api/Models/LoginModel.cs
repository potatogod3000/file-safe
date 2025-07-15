using System.ComponentModel.DataAnnotations;

namespace safe_api.Models;

public class LoginModel
{
    [Required, MinLength(3), MaxLength(20)]
    public string UserName { get; set; }
    
    [Required, MinLength(8), MaxLength(20)]
    public string Password { get; set; }
    
    public bool IsPersistent { get; set; }
    
    public LoginModel()
    {
        UserName = string.Empty;
        Password = string.Empty;
        IsPersistent = false;
    }
}