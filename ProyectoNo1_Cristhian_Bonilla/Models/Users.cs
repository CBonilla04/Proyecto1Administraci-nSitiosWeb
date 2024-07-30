using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProyectoNo1_Cristhian_Bonilla.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "El email es requerido.")]
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "El email no es válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El nombre es requerido.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "El primer apellido es requerido.")]
        [MaxLength(50)]
        public string Surname { get; set; }   

        [Required(ErrorMessage = "La contraseña es requerida.")]
        [MaxLength(256)]
        public string Password { get; set; }

        [Required(ErrorMessage = "El rol de usuario es requerido")]
        [DefaultValue(false)]
        public bool IsAdmin { get; set; }
        public ICollection<Historical> Historical { get; set; }

        public Users()
        {
            Historical = new List<Historical>();
        }
    }
}

