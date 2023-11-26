using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NpTest.Data;
using NpTest.Models;
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
    public async Task<IActionResult> Create([Bind("Number, Description, OpenDate, Status")] Bidding model)
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

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bidding = await _context.Biddings.FindAsync(id);
        if (bidding == null)
        {
            return NotFound();
        }

        _context.Biddings.Remove(bidding);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bidding = await _context.Biddings.FindAsync(id);
        if (bidding == null)
        {
            return NotFound();
        }

        ViewBag.Statuses = new SelectList(Enum.GetValues(typeof(BiddingStatus)));
        return View(bidding);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id, Number, Description, OpenDate, Status")] Bidding model)
    {
        ViewBag.Statuses = new SelectList(Enum.GetValues(typeof(BiddingStatus)));

        if (id != model.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _context.Update(model);
        await _context.SaveChangesAsync();
        
        ViewBag.SuccessMessage = "Bidding updated successfully!";
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}
