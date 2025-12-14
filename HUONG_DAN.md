# Tài liệu hướng dẫn sử dụng DigiShop

## Giới thiệu

DigiShop là một website bán hàng điện tử được xây dựng hoàn chỉnh bằng ASP.NET Core MVC. Dự án bao gồm đầy đủ các chức năng cơ bản của một trang thương mại điện tử.

## Hướng dẫn cài đặt chi tiết

### 1. Cài đặt .NET SDK

Tải và cài đặt .NET 8.0 SDK từ: https://dotnet.microsoft.com/download

### 2. Clone và chạy dự án

```bash
# Clone repository
git clone https://github.com/trinhminhkha24/bs-digishop-mini.git

# Di chuyển vào thư mục dự án
cd bs-digishop-mini/DigiShop

# Restore các package
dotnet restore

# Tạo database (nếu chưa tồn tại)
dotnet ef database update

# Chạy ứng dụng
dotnet run
```

### 3. Truy cập website

Mở trình duyệt và truy cập:
- HTTP: http://localhost:5000
- HTTPS: https://localhost:5001

## Tài khoản test

- **Email**: test@digishop.com
- **Password**: Test@123

## Hướng dẫn sử dụng

### A. Dành cho khách hàng

#### 1. Trang chủ
- Xem các danh mục sản phẩm
- Xem sản phẩm mới nhất
- Xem sản phẩm đang khuyến mãi
- Click vào danh mục để xem sản phẩm theo danh mục

#### 2. Xem sản phẩm
- Click vào tên sản phẩm để xem chi tiết
- Xem giá, mô tả, hình ảnh sản phẩm
- Chọn số lượng và thêm vào giỏ hàng

#### 3. Giỏ hàng
- Click "Giỏ hàng" trên menu để xem giỏ hàng
- Cập nhật số lượng sản phẩm
- Xóa sản phẩm không cần
- Click "Đặt hàng" để hoàn tất đơn hàng

#### 4. Đặt hàng
- Phải đăng nhập trước khi đặt hàng
- Sau khi đặt hàng thành công, sẽ nhận được mã đơn hàng
- Đơn hàng được lưu vào database với trạng thái "Pending"

#### 5. Đăng ký tài khoản
- Click "Đăng ký" trên menu
- Điền thông tin: Email, Password, Confirm Password
- Click "Register" để tạo tài khoản

#### 6. Đăng nhập
- Click "Đăng nhập" trên menu
- Nhập Email và Password
- Click "Log in"

### B. Dành cho quản trị viên

#### 1. Truy cập trang quản lý
- Đăng nhập với tài khoản
- Click "Quản lý" trên menu

#### 2. Quản lý danh mục

**Xem danh sách danh mục:**
- Truy cập: Admin > Categories > Index
- Hiển thị danh sách tất cả danh mục

**Thêm danh mục mới:**
- Click "Thêm danh mục mới"
- Nhập tên danh mục và mô tả
- Click "Lưu"

**Sửa danh mục:**
- Click "Sửa" ở danh mục muốn chỉnh sửa
- Cập nhật thông tin
- Click "Lưu"

**Xóa danh mục:**
- Click "Xóa" ở danh mục muốn xóa
- Xác nhận xóa

#### 3. Quản lý sản phẩm

**Xem danh sách sản phẩm:**
- Truy cập: Admin > Products > Index
- Hiển thị danh sách tất cả sản phẩm

**Thêm sản phẩm mới:**
- Click "Thêm sản phẩm mới"
- Nhập thông tin:
  - Tên sản phẩm
  - Mô tả
  - Giá
  - Giá khuyến mãi (nếu có)
  - Đường dẫn hình ảnh
  - Chọn danh mục
  - Tick "Sản phẩm mới" nếu muốn hiển thị ở trang chủ
  - Tick "Khuyến mãi" nếu sản phẩm đang giảm giá
- Click "Lưu"

**Sửa sản phẩm:**
- Click "Sửa" ở sản phẩm muốn chỉnh sửa
- Cập nhật thông tin
- Click "Lưu"

**Xóa sản phẩm:**
- Click "Xóa" ở sản phẩm muốn xóa
- Xác nhận xóa

## Cấu trúc Database

### Bảng Categories (Danh mục)
- Id: INT (Primary Key)
- Name: STRING (Tên danh mục)
- Description: STRING (Mô tả)

### Bảng Products (Sản phẩm)
- Id: INT (Primary Key)
- Name: STRING (Tên sản phẩm)
- Description: STRING (Mô tả)
- Price: DOUBLE (Giá)
- SalePrice: DOUBLE (Giá khuyến mãi)
- ImageUrl: STRING (Đường dẫn hình ảnh)
- IsNewProduct: BOOL (Sản phẩm mới)
- IsOnSale: BOOL (Đang khuyến mãi)
- CategoryId: INT (Foreign Key -> Categories)

### Bảng Orders (Đơn hàng)
- Id: INT (Primary Key)
- UserId: STRING (Foreign Key -> AspNetUsers)
- Status: STRING (Trạng thái: Pending, Processing, Completed, Cancelled)
- CreatedAt: DATETIME (Ngày tạo)

### Bảng OrderProducts (Chi tiết đơn hàng)
- Id: INT (Primary Key)
- OrderId: INT (Foreign Key -> Orders)
- ProductId: INT (Foreign Key -> Products)
- Quantity: INT (Số lượng)
- Price: DOUBLE (Giá tại thời điểm mua)

### Bảng AspNetUsers (Người dùng - từ Identity)
- Id: STRING (Primary Key)
- UserName: STRING
- Email: STRING
- FirstName: STRING
- LastName: STRING
- ... (các trường khác của Identity)

## Chuyển đổi sang SQL Server

Nếu muốn sử dụng SQL Server thay vì SQLite:

1. Cập nhật connection string trong `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=DigiShopDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

2. Cập nhật `Program.cs`:
```csharp
// Thay đổi từ
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlite(connectionString));

// Thành
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(connectionString));
```

3. Xóa migrations cũ và tạo lại:
```bash
dotnet ef migrations remove
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Troubleshooting

### Lỗi không kết nối được database
- Kiểm tra file `digishop.db` có tồn tại trong thư mục DigiShop không
- Chạy lệnh: `dotnet ef database update`

### Lỗi build failed
- Chạy: `dotnet clean` và sau đó `dotnet build`
- Kiểm tra .NET SDK version: `dotnet --version` (cần >= 8.0)

### Không thấy dữ liệu mẫu
- Xóa file `digishop.db`
- Chạy lại: `dotnet ef database update`
- Chạy lại ứng dụng: `dotnet run`

## Mở rộng tính năng

Dự án có thể mở rộng với các tính năng:
- Phân quyền Admin/User
- Quản lý đơn hàng cho admin
- Lịch sử đơn hàng cho khách hàng
- Tìm kiếm sản phẩm
- Phân trang danh sách sản phẩm
- Upload hình ảnh sản phẩm
- Đánh giá và nhận xét sản phẩm
- Wishlist (Danh sách yêu thích)
- Payment gateway integration
- Email notifications

## Liên hệ

- GitHub: https://github.com/trinhminhkha24
- Email: (Thêm email nếu cần)
