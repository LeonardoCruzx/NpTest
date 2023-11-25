using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NpTest.Models;
using NpTest.Services.Interfaces;
using NpTest.ViewModels;

namespace NpTest.Controllers;

public class HomeController(ILogger<HomeController> logger, IBiddingService biddingService) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly IBiddingService _biddingService = biddingService;

    public async Task<IActionResult> Index(HomeViewModel model)
    {
        var biddings = await _biddingService.GetBiddingsAsync();

        if (!string.IsNullOrEmpty(model.FilterBy) && !string.IsNullOrEmpty(model.FilterByValue))
        {
            biddings = biddings.Where(b => b.GetType().GetProperty(model.FilterBy)?.GetValue(b)?.ToString()?.Contains(model.FilterByValue, StringComparison.OrdinalIgnoreCase) ?? false);
        }

        if (!string.IsNullOrEmpty(model.OrderBy) && !string.IsNullOrEmpty(model.OrderByType))
        {
            biddings = model.OrderByType switch
            {
                "asc" => biddings.OrderBy(b => b.GetType().GetProperty(model.OrderBy)?.GetValue(b)),
                "desc" => biddings.OrderByDescending(b => b.GetType().GetProperty(model.OrderBy)?.GetValue(b)),
                _ => biddings
            };
        }

        var biddingFields = typeof(Bidding).GetProperties().Where(p => p.PropertyType.IsValueType || p.PropertyType == typeof(string)).Select(p => p.Name);
        ViewBag.Fields = new SelectList(biddingFields);

        var viewModel = new HomeViewModel
        {
            Biddings = biddings,
            OrderBy = model.OrderBy,
            OrderByType = model.OrderByType,
            FilterBy = model.FilterBy,
            FilterByValue = model.FilterByValue
        };

        return View(viewModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
