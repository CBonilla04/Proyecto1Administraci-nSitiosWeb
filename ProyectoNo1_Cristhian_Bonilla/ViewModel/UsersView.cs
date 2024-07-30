using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoNo1_Cristhian_Bonilla.ViewModel
{
    public class UsersView
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }
        public string PasswordCheck { get; set; }

        public bool IsAdmin { get; set; }
    }
}
