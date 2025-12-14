using DigiShop.Models;
using Microsoft.AspNetCore.Identity;

namespace DigiShop.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(AppDBContext context, UserManager<AppUser> userManager)
        {
            context.Database.EnsureCreated();

            // Check if data already exists
            if (context.Categories.Any())
            {
                return; // DB has been seeded
            }

            // Seed Categories
            var categories = new Category[]
            {
                new Category { Name = "Điện thoại", Description = "Điện thoại di động các loại" },
                new Category { Name = "Laptop", Description = "Laptop và phụ kiện" },
                new Category { Name = "Tablet", Description = "Máy tính bảng" },
                new Category { Name = "Phụ kiện", Description = "Phụ kiện điện tử" }
            };

            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();

            // Seed Products
            var products = new Product[]
            {
                new Product
                {
                    Name = "iPhone 15 Pro",
                    Description = "Điện thoại iPhone 15 Pro với chip A17 Pro mạnh mẽ",
                    Price = 25000000,
                    ImageUrl = "/assets/img/dummyimg.png",
                    CategoryId = categories[0].Id,
                    IsNewProduct = true,
                    IsOnSale = false
                },
                new Product
                {
                    Name = "Samsung Galaxy S24",
                    Description = "Samsung Galaxy S24 flagship với camera AI",
                    Price = 22000000,
                    SalePrice = 19000000,
                    ImageUrl = "/assets/img/dummyimg.png",
                    CategoryId = categories[0].Id,
                    IsNewProduct = true,
                    IsOnSale = true
                },
                new Product
                {
                    Name = "MacBook Pro M3",
                    Description = "MacBook Pro với chip M3 Pro hiệu năng cao",
                    Price = 45000000,
                    ImageUrl = "/assets/img/dummyimg.png",
                    CategoryId = categories[1].Id,
                    IsNewProduct = true,
                    IsOnSale = false
                },
                new Product
                {
                    Name = "Dell XPS 15",
                    Description = "Dell XPS 15 - Laptop cao cấp cho dân văn phòng",
                    Price = 35000000,
                    SalePrice = 30000000,
                    ImageUrl = "/assets/img/dummyimg.png",
                    CategoryId = categories[1].Id,
                    IsNewProduct = false,
                    IsOnSale = true
                },
                new Product
                {
                    Name = "iPad Pro 12.9",
                    Description = "iPad Pro 12.9 inch với chip M2",
                    Price = 28000000,
                    ImageUrl = "/assets/img/dummyimg.png",
                    CategoryId = categories[2].Id,
                    IsNewProduct = true,
                    IsOnSale = false
                },
                new Product
                {
                    Name = "Samsung Galaxy Tab S9",
                    Description = "Samsung Galaxy Tab S9 - Máy tính bảng Android cao cấp",
                    Price = 18000000,
                    SalePrice = 15000000,
                    ImageUrl = "/assets/img/dummyimg.png",
                    CategoryId = categories[2].Id,
                    IsNewProduct = false,
                    IsOnSale = true
                },
                new Product
                {
                    Name = "AirPods Pro 2",
                    Description = "Tai nghe AirPods Pro thế hệ 2 với chống ồn chủ động",
                    Price = 6000000,
                    ImageUrl = "/assets/img/dummyimg.png",
                    CategoryId = categories[3].Id,
                    IsNewProduct = true,
                    IsOnSale = false
                },
                new Product
                {
                    Name = "Magic Mouse",
                    Description = "Chuột không dây Magic Mouse của Apple",
                    Price = 2000000,
                    SalePrice = 1500000,
                    ImageUrl = "/assets/img/dummyimg.png",
                    CategoryId = categories[3].Id,
                    IsNewProduct = false,
                    IsOnSale = true
                }
            };

            context.Products.AddRange(products);
            await context.SaveChangesAsync();

            // Create a test user
            var testUser = new AppUser
            {
                UserName = "test@digishop.com",
                Email = "test@digishop.com",
                EmailConfirmed = true,
                FirstName = "Test",
                LastName = "User"
            };

            var result = await userManager.CreateAsync(testUser, "Test@123");
            if (!result.Succeeded)
            {
                // Log error if needed
            }
        }
    }
}
