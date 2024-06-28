using System.ComponentModel.DataAnnotations;

namespace Catalogo.Application.DTOs
{
    public class PizzaFlavorDTO
    {
        [Required]
        public int IdPizza {  get; set; }
        [Required]
        public int IdFlavor { get; set; }
    }
}
