using Microsoft.AspNetCore.Identity;
using safe_api.Dtos;
using safe_api.Models;

namespace safe_api.Services;

public class AuthenticationService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthenticationService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<AuthenticationDto> CreateUserAsync(RegisterModel registerUser)
    {
        var result = new AuthenticationDto();
        
        var user = new IdentityUser()
        {
            Email = registerUser.Email,
            PhoneNumber = registerUser.PhoneNumber,
            UserName = registerUser.UserName,
            EmailConfirmed = false,
            PhoneNumberConfirmed = false
        };
        
        var createUserResult = await _userManager.CreateAsync(user, registerUser.Password);

        if (createUserResult.Succeeded)
            result.IsSuccess = true;
        else
        {
            result.IsError = true;
            result.ErrorMessage = createUserResult.Errors.First().Description;
        }
        
        return result;
    }

    public async Task<AuthenticationDto> SendEmailTokenAsync(IdentityUser currentUser)
    {
        var result = new AuthenticationDto();
        
        var user = await _userManager.FindByIdAsync(currentUser.Id);
        if (user == null)
        {
            result.IsError = true;
            result.IsAuthenticated = false;
            result.ErrorMessage = "User not found";
            return result;
        }

        if (!currentUser.EmailConfirmed)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            if (string.IsNullOrEmpty(token))
            {
                result.IsError = true;
                result.ErrorMessage = "Error when generating Token";
            }
            else
                result.IsSuccess = true;
        }
        else
        {
            result.IsSuccess = true;
            result.ErrorMessage = "Email already confirmed";
        }

        return result;
    }
    
    public async Task<AuthenticationDto> VerifyEmailTokenAsync(IdentityUser currentUser, string emailToken)
    {
        var result = new AuthenticationDto();
        
        var user = await _userManager.FindByIdAsync(currentUser.Id);
        if (user == null)
        {
            result.IsAuthenticated = false;
            result.IsError = true;
            result.ErrorMessage = "User not found";
            return result;
        }

        if (!currentUser.EmailConfirmed)
        {
            var confirmationResult = await _userManager.ConfirmEmailAsync(user, emailToken);

            if (confirmationResult.Succeeded)
                result.IsSuccess = true;
            else
            {
                result.IsError = true;
                result.ErrorMessage = confirmationResult.Errors.First().Description;
            }
        }
        else
        {
            result.IsSuccess = true;
            result.ErrorMessage = "Email already confirmed";
        }

        return result;
    }
    
    public async Task<AuthenticationDto> SendPhoneTokenAsync(IdentityUser currentUser)
    {
        var result = new AuthenticationDto();
        
        var user = await _userManager.FindByIdAsync(currentUser.Id);
        
        if (user == null)
        {
            result.IsAuthenticated = false;
            result.ErrorMessage = "User not found";
            return result;
        }
        else if (string.IsNullOrEmpty(currentUser.PhoneNumber))
        {
            result.IsError = true;
            result.ErrorMessage = "User doesn't have a Phone Number set";
            return result;
        }

        if (!currentUser.PhoneNumberConfirmed)
        {
            var token = await _userManager.GenerateChangePhoneNumberTokenAsync(user, currentUser.PhoneNumber);

            if (string.IsNullOrEmpty(token))
            {
                result.IsError = true;
                result.ErrorMessage = "Error when generating Token";
            }
            else
                result.IsSuccess = true;
        }
        else
        {
            result.IsSuccess = true;
            result.ErrorMessage = "Phone Number already confirmed";
        }

        return result;
    }
    
    public async Task<AuthenticationDto> VerifyPhoneNumberTokenAsync(IdentityUser currentUser, string phoneNumberToken)
    {
        var result = new AuthenticationDto();
        
        var user = await _userManager.FindByIdAsync(currentUser.Id);
        if (user == null)
        {
            result.IsAuthenticated = false;
            result.IsError = true;
            result.ErrorMessage = "User not found";
            return result;
        }

        if (string.IsNullOrEmpty(user.PhoneNumber))
        {
            result.IsError = true;
            result.ErrorMessage = "User doesn't have a Phone Number set";
            return result;
        }
        
        if (!currentUser.PhoneNumberConfirmed)
        {
            var confirmationResult = await _userManager.VerifyChangePhoneNumberTokenAsync(user, phoneNumberToken, user.PhoneNumber);

            if (confirmationResult)
                result.IsSuccess = true;
            else
            {
                result.IsError = true;
                result.ErrorMessage = "Error when verifying Phone Number Token";
            }
        }
        else
        {
            result.IsSuccess = true;
            result.ErrorMessage = "Phone Number already confirmed";
        }

        return result;
    }
    
    public async Task<AuthenticationDto> LoginUserAsync(LoginModel loginUser)
    {
        var result =  new AuthenticationDto();
        var user = await _userManager.FindByNameAsync(loginUser.UserName);
        if (user == null)
        {
            result.IsError = true;
            result.ErrorMessage = $"Entered Username or Password is incorrect";
            return result;
        }

        var passwordCheckResult = await _signInManager.CheckPasswordSignInAsync(user, loginUser.Password, false);
        if (passwordCheckResult.Succeeded)
        {
            result.User = user;
            result.IsSuccess = true;
            result.IsAuthenticated = true;
        }
        else
        {
            result.IsError = true;
        }
        
        return result;
    }
    
    public async Task LogoutUserAsync()
    {
        await _signInManager.SignOutAsync();
    }
}