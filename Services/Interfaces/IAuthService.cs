using NpTest.ViewModels;

namespace NpTest.Services.Interfaces;

public interface IAuthService
{
    Task<bool> Authenticate(LoginViewModel model);
}
