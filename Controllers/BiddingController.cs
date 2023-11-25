using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NpTest.Data;
using NpTest.Models;
using NpTest.ViewModels;

namespace NpTest.Controllers;

public class BiddingController(ILogger<BiddingController> logger, BiddingContext context) : Controller
{
    private readonly ILogger<BiddingController> _logger = logger;
    private readonly BiddingContext _context = context;

    public IActionResult Create()
    {
        ViewBag.Statuses = new SelectList(Enum.GetValues(typeof(BiddingStatus)));
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Number, Description, Status")] Bidding model)
    {
        ViewBag.Statuses = new SelectList(Enum.GetValues(typeof(BiddingStatus)));

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _context.Biddings.AddAsync(model);
        await _context.SaveChangesAsync();

        ViewBag.SuccessMessage = "Bidding created successfully!";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
