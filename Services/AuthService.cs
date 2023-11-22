using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NpTest.Data;
using NpTest.Services.Interfaces;
using NpTest.ViewModels;

namespace NpTest.Services;

public class AuthService(
    ILogger<AuthService> logger, 
    IHttpContextAccessor httpContextAccessor, 
    BiddingContext biddingContext) : IAuthService
{
    private readonly ILogger<AuthService> _logger = logger;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly BiddingContext _biddingContext = biddingContext;

    public async Task<bool> Authenticate(LoginViewModel model)
    {
        try
        {
            if (_httpContextAccessor.HttpContext is null)
            {
                return false;
            }

            var user = await _biddingContext.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);

            if (user is null)
            {
                return false;
            }

            if (BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return false;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.UserName),
                new Claim(ClaimTypes.Role, "Administrator")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var props = new AuthenticationProperties
            {
                IsPersistent = true
            };

            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props);

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error authenticating user");
            return false;
        }
    }
}
