using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DigiShop.Models;
using DigiShop.Data;
using DigiShop.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DigiShop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDBContext _context;

    public HomeController(ILogger<HomeController> logger, AppDBContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new HomeViewModel
        {
            Categories = await _context.Categories.ToListAsync(),
            NewProducts = await _context.Products
                .Where(p => p.IsNewProduct)
                .Include(p => p.Category)
                .Take(6)
                .ToListAsync(),
            SaleProducts = await _context.Products
                .Where(p => p.IsOnSale)
                .Include(p => p.Category)
                .Take(6)
                .ToListAsync()
        };
        
        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
