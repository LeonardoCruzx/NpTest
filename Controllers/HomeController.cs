using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NpTest.Models;
using NpTest.Services.Interfaces;

namespace NpTest.Controllers;

public class HomeController(ILogger<HomeController> logger, IBiddingService biddingService) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly IBiddingService _biddingService = biddingService;

    public async Task<IActionResult> Index()
    {
        var biddings = await _biddingService.GetBiddingsAsync();

        return View(biddings);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
