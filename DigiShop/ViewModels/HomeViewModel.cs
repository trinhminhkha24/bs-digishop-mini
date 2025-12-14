using DigiShop.Models;

namespace DigiShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Product> NewProducts { get; set; } = new List<Product>();
        public IEnumerable<Product> SaleProducts { get; set; } = new List<Product>();
    }
}
