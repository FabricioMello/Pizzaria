using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Catalogo.Application.DTOs
{
    public class PizzaDTO
    {
        [Required(ErrorMessage = "Os sabores são obrigatórios")]
        public List<FlavorDTO> Flavors {  get; set; }

        [Required(ErrorMessage = "Informe o preço")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
