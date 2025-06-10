using System.ComponentModel.DataAnnotations;

namespace Api_SistemaRegistroGastos.Models
{
    public class Gastos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0.")]
        public decimal Monto { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string Descripcion { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Gastos), "ValidarFecha")]
        public DateTime Fecha { get; set; }
        [Required]
        [StringLength(250)]
        public string NombreComercio { get; set; }

        public static ValidationResult ValidarFecha(DateTime fecha, ValidationContext context)
        {
            //if
            return fecha > DateTime.Today//{}
                ? new ValidationResult("La fecha no puede ser futura.")//else
                : ValidationResult.Success;
        }
        //es como un if pero lo hace en menos lineas, es como un ifternario
        //si la fecha es mayor a la fecha de hoy 
        //validations representa que la validacion fue true


    }
}
