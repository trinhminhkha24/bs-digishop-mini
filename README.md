# DigiShop - E-Commerce Website

Đây là dự án website bán hàng điện tử được xây dựng bằng ASP.NET Core MVC.

## Tính năng

### Trang khách hàng
- **Trang chủ**: Hiển thị danh sách danh mục, sản phẩm mới nhất và sản phẩm khuyến mãi
- **Trang danh mục**: Xem sản phẩm theo từng danh mục
- **Trang chi tiết sản phẩm**: Xem thông tin chi tiết sản phẩm
- **Giỏ hàng**: Quản lý giỏ hàng (thêm, sửa, xóa sản phẩm)
- **Đặt hàng**: Tạo đơn hàng từ giỏ hàng
- **Đăng ký/Đăng nhập**: Hệ thống xác thực người dùng với ASP.NET Core Identity

### Trang quản trị (Admin)
- **Quản lý danh mục**: Thêm, sửa, xóa, hiển thị danh sách danh mục
- **Quản lý sản phẩm**: Thêm, sửa, xóa, hiển thị danh sách sản phẩm

## Công nghệ sử dụng

- **Framework**: ASP.NET Core 8.0 MVC
- **Database**: SQLite (dễ dàng chuyển sang SQL Server nếu cần)
- **ORM**: Entity Framework Core 8.0
- **Authentication**: ASP.NET Core Identity
- **Frontend**: Bootstrap 3 (từ template DIGI Shop mini)
- **Session Management**: ASP.NET Core Session cho giỏ hàng

## Cấu trúc dự án

```
DigiShop/
├── Areas/
│   ├── Admin/          # Khu vực quản trị
│   │   ├── Controllers/
│   │   │   ├── CategoriesController.cs
│   │   │   └── ProductsController.cs
│   │   └── Views/
│   └── Identity/       # Các trang đăng ký/đăng nhập
├── Controllers/        # Controllers chính
│   ├── HomeController.cs
│   ├── ProductController.cs
│   ├── CartController.cs
│   └── OrderController.cs
├── Data/
│   ├── AppDBContext.cs
│   └── DbInitializer.cs
├── Models/            # Các model dữ liệu
│   ├── AppUser.cs
│   ├── Category.cs
│   ├── Product.cs
│   ├── Order.cs
│   └── OrderProduct.cs
├── ViewModels/        # View models
│   ├── HomeViewModel.cs
│   └── CartItem.cs
├── Views/             # Các view
└── wwwroot/           # Static files (CSS, JS, images)
```

## Cài đặt và chạy

### Yêu cầu
- .NET 8.0 SDK
- SQLite (đã được cài đặt mặc định trong hầu hết các hệ điều hành)

### Các bước chạy

1. Clone repository:
```bash
git clone https://github.com/trinhminhkha24/bs-digishop-mini.git
cd bs-digishop-mini/DigiShop
```

2. Restore packages:
```bash
dotnet restore
```

3. Tạo database (nếu chưa có):
```bash
dotnet ef database update
```

4. Chạy ứng dụng:
```bash
dotnet run
```

5. Mở trình duyệt và truy cập: `http://localhost:5000` hoặc `https://localhost:5001`

## Dữ liệu mẫu

Khi chạy lần đầu, hệ thống sẽ tự động tạo dữ liệu mẫu bao gồm:
- 4 danh mục sản phẩm
- 8 sản phẩm mẫu
- 1 tài khoản test:
  - Email: test@digishop.com
  - Password: Test@123

## Chức năng chính

### Khách hàng
1. Xem sản phẩm theo danh mục
2. Xem chi tiết sản phẩm
3. Thêm sản phẩm vào giỏ hàng
4. Quản lý giỏ hàng (cập nhật số lượng, xóa sản phẩm)
5. Đặt hàng (yêu cầu đăng nhập)

### Quản trị viên
1. Đăng nhập vào hệ thống
2. Quản lý danh mục (CRUD)
3. Quản lý sản phẩm (CRUD)

## Ghi chú

- Database sử dụng SQLite để dễ dàng triển khai và test
- Để chuyển sang SQL Server, chỉ cần thay đổi connection string trong `appsettings.json` và sử dụng `UseSqlServer` thay vì `UseSqlite` trong `Program.cs`
- Template giao diện giữ nguyên từ DIGI Shop mini template

## Tác giả

Dự án được phát triển bởi trinhminhkha24
