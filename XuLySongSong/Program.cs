// Thêm các thư viện cần thiết ở đầu file
using System.Diagnostics; // Dùng để đo thời gian

public class Program
{
    // Một phương thức giả lập công việc xử lý tốn thời gian
    static void XuLyCongViec(int sanPhamID)
    {
        Console.WriteLine($"Bắt đầu xử lý sản phẩm {sanPhamID} trên luồng (thread) ID: {Thread.CurrentThread.ManagedThreadId}");

        // Giả lập công việc tốn 1 giây
        Thread.Sleep(1000);

        Console.WriteLine($"---> Hoàn thành xử lý sản phẩm {sanPhamID}.");
    }

    public static void Main(string[] args)
    {
        int soLuongSanPham = 10;
        var stopwatch = new Stopwatch();

        Console.WriteLine("=============================================");
        Console.WriteLine("BẮT ĐẦU XỬ LÝ TUẦN TỰ (dùng vòng lặp for)");
        Console.WriteLine("=============================================");

        stopwatch.Start();
        // ----------- 1. Vòng lặp for thông thường -----------
        for (int i = 0; i < soLuongSanPham; i++)
        {
            XuLyCongViec(i);
        }
        stopwatch.Stop();
        Console.WriteLine($"\n>> Xử lý tuần tự mất: {stopwatch.Elapsed.TotalSeconds:F2} giây.\n\n");


        Console.WriteLine("=============================================");
        Console.WriteLine("BẮT ĐẦU XỬ LÝ SONG SONG (dùng Parallel.For)");
        Console.WriteLine("=============================================");

        stopwatch.Restart();
        // ----------- 2. Dùng Parallel.For -----------
        Parallel.For(0, soLuongSanPham, i =>
        {
            XuLyCongViec(i);
        });
        stopwatch.Stop();
        Console.WriteLine($"\n>> Xử lý song song mất: {stopwatch.Elapsed.TotalSeconds:F2} giây.");

        Console.WriteLine("\nNhấn Enter để thoát...");
        Console.ReadLine();
    }
}
