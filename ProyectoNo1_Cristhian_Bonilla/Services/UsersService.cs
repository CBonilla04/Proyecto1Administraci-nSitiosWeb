using Microsoft.EntityFrameworkCore;
using ProyectoNo1_Cristhian_Bonilla.Interfaces;
using ProyectoNo1_Cristhian_Bonilla.Models;
using ProyectoNo1_Cristhian_Bonilla.Utils;

namespace ProyectoNo1_Cristhian_Bonilla.Services
{
    public class UsersService : IUsersService
    {
        private readonly AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Users> GetUser(string email, string password, HttpContext httpContext)
        {
            try
                {
                HashData hashData = new HashData();
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

                if (user == null || !hashData.VerifyPassword(password, user.Password))
                {
                    return null;
                }
                httpContext.Session.SetObjectAsJson("CurrentUser", user);
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Users> Register(Users user)
        {
            try
                {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Users> UpdateUser(Users user)
        {
            try
                {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
