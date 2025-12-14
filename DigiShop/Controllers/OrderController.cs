using DigiShop.Data;
using DigiShop.Models;
using DigiShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DigiShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly AppDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        private const string CartSessionKey = "ShoppingCart";

        public OrderController(AppDBContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var cart = GetCart();
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var cart = GetCart();
            if (!cart.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }

            var order = new Order
            {
                UserId = user.Id,
                Status = "Pending",
                CreatedAt = DateTime.Now,
                OrderProducts = cart.Select(c => new OrderProduct
                {
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    Price = c.Price
                }).ToList()
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Clear cart
            HttpContext.Session.Remove(CartSessionKey);

            return RedirectToAction(nameof(Confirmation), new { id = order.Id });
        }

        public IActionResult Confirmation(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }

        private List<CartItem> GetCart()
        {
            var cartJson = HttpContext.Session.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(cartJson))
            {
                return new List<CartItem>();
            }

            return JsonSerializer.Deserialize<List<CartItem>>(cartJson) ?? new List<CartItem>();
        }
    }
}
