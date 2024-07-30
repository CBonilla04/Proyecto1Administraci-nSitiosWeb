using ProyectoNo1_Cristhian_Bonilla.Models;
using ProyectoNo1_Cristhian_Bonilla.ViewModel;

namespace ProyectoNo1_Cristhian_Bonilla.Interfaces
{
    public interface IUsersService
    {
        Task<Users> Register(Users user);
        Task<Users> GetUser(string email, string password, HttpContext httpContext);
        Task<Users> UpdateUser(Users user);
    }
}
