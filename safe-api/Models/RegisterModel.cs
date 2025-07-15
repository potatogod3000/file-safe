using System.ComponentModel.DataAnnotations;

namespace safe_api.Models;

public class RegisterModel
{
    [Required, MaxLength(20), MinLength(3)]
    public string UserName { get; set; }
    
    [Required, MaxLength(20), MinLength(8)]
    public string Password { get; set; }
    
    [Required, MaxLength(200)]
    public string Email { get; set; }

    [MaxLength(20)]
    public string PhoneNumber { get; set; }
    
    public RegisterModel()
    {
        UserName = string.Empty;
        Password = string.Empty;
        Email = string.Empty;
        PhoneNumber = string.Empty;
    }
}