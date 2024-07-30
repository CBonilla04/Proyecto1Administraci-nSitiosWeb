using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoNo1_Cristhian_Bonilla.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "El nombre del producto es requerido.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "La marca es requerida.")]
        [StringLength(50, ErrorMessage = "La marca no puede tener más de 50 caracteres.")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "El modelo es requerido.")]
        [StringLength(50, ErrorMessage = "El modelo no puede tener más de 50 caracteres.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "La categoría es requerida.")]
        [StringLength(50, ErrorMessage = "La categoría no puede tener más de 50 caracteres.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "El precio es requerido.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "La cantidad en stock es requerida.")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "El procesador es requerido.")]
        [StringLength(100, ErrorMessage = "El procesador no puede tener más de 100 caracteres.")]
        public string Processor { get; set; }

        [Required(ErrorMessage = "La memoria RAM es requerida.")]
        [StringLength(50, ErrorMessage = "La memoria RAM no puede tener más de 50 caracteres.")]
        public string RAM { get; set; }

        [Required(ErrorMessage = "El almacenamiento es requerido.")]
        [StringLength(100, ErrorMessage = "El almacenamiento no puede tener más de 100 caracteres.")]
        public string Storage { get; set; }

        [StringLength(100, ErrorMessage = "La tarjeta gráfica no puede tener más de 100 caracteres.")]
        public string? GraphicsCard { get; set; }

        [StringLength(50, ErrorMessage = "El sistema operativo no puede tener más de 50 caracteres.")]
        public string OperatingSystem { get; set; }

        [StringLength(50, ErrorMessage = "El peso no puede tener más de 50 caracteres.")]
        public string Weight { get; set; }

        [StringLength(100, ErrorMessage = "Las dimensiones no pueden tener más de 100 caracteres.")]
        public string Dimensions { get; set; }

        [StringLength(50, ErrorMessage = "La duración de la batería no puede tener más de 50 caracteres.")]
        public string BatteryLife { get; set; }

        [StringLength(255, ErrorMessage = "Los puertos no pueden tener más de 255 caracteres.")]
        public string Ports { get; set; }

        [StringLength(100, ErrorMessage = "La conectividad no puede tener más de 100 caracteres.")]
        public string Connectivity { get; set; }

        [StringLength(50, ErrorMessage = "El color no puede tener más de 50 caracteres.")]
        public string Color { get; set; }

        [StringLength(100, ErrorMessage = "La garantía no puede tener más de 100 caracteres.")]
        public string Warranty { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Column(TypeName = "image")]
        public byte[]? Image { get; set; }
    }
}
