using BanDoNoiThat.Models;
using BanDoNoiThat.Utils;
using Microsoft.EntityFrameworkCore;

namespace BanDoNoiThat.Data
{
    public class SeedData
    {
        public static void SeedDingData(ApplicationDbContext context)
        {
            // Kiểm tra xem dữ liệu đã tồn tại trong bảng hay không
            context.Database.GetMigrations();
            if (!context.Accounts.Any() || !context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role { roleName = "ADMIN" },
                    new Role { roleName = "USER" }
                );
                context.SaveChanges();
                // Tạo dữ liệu cho bảng admin
                context.Accounts.AddRange(

                    new Account { FullName = "ADMIN", Username = "admin", role_id = 1, Password = PasswordHelper.HashPassword("123") },
                    new Account { FullName = "USER", Username = "user", role_id = 2, Password = PasswordHelper.HashPassword("123") }

                );
                context.SaveChanges();
            }
        }
    }
}
