using BanDoNoiThat.Data;
using BanDoNoiThat.Models;
using BanDoNoiThat.Utils;
using Microsoft.EntityFrameworkCore;

namespace BanDoNoiThat.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Account Authenticate(string username, string password)
        {
            // Mã hóa mật khẩu người dùng nhập vào
            var hashedPassword = PasswordHelper.HashPassword(password);
            // Tìm kiếm người dùng trong cơ sở dữ liệu
            var account = _context.Accounts.FirstOrDefault(a => a.Username == username && a.Password == hashedPassword);

            if (account == null)
            {
                return null; // Nếu không tìm thấy người dùng
            }

            return account; // Trả về thông tin người dùng
        }
        public Role FindRoleName(int roleID)
        {
            // Tìm kiếm người dùng trong cơ sở dữ liệu
            var role = _context.Roles.Find(Convert.ToInt32(roleID));

            if (role == null)
            {
                return null; // Nếu không tìm thấy người dùng
            }

            return role; // Trả về quyền
        }
    }
}
