using Microsoft.AspNetCore.Mvc;
using NpTest.Services.Interfaces;
using NpTest.ViewModels;

namespace NpTest.Controllers;

public class AccountController(ILogger<AccountController> logger, IAuthService authService) : Controller
{
    private readonly ILogger<AccountController> _logger = logger;
    private readonly IAuthService _authService = authService;

    [HttpGet]
    public IActionResult Login()
    {
        if (User.Identity?.IsAuthenticated == true)
        {
            return RedirectToAction("Index", "Home");
        }

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        if (!await _authService.Authenticate(model))
        {
            return View();
        }

        return RedirectToAction("Index", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
