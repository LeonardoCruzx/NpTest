using Microsoft.AspNetCore.Mvc;

namespace NpTest.Controllers;

public class BiddingController : Controller
{
    private readonly ILogger<BiddingController> _logger;

    public BiddingController(ILogger<BiddingController> logger)
    {
        _logger = logger;
    }

    public IActionResult Create()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
