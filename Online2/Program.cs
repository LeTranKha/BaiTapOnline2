using Microsoft.EntityFrameworkCore;
using Online2.Data;

namespace Online2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // =================== PHẦN QUAN TRỌNG NHẤT ===================
            // 1. Lấy chuỗi kết nối từ file appsettings.json
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // 2. ĐĂNG KÝ DBCONTEXT VÀO HỆ THỐNG DI
            //    DÒNG CODE NÀY BỊ THIẾU HOẶC SAI TRONG DỰ ÁN CỦA BẠN
            builder.Services.AddDbContext<StudentManagerDbContext>(options =>
                options.UseNpgsql(connectionString));
            // =============================================================

            // Thêm các dịch vụ khác cho controllers và views
            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
