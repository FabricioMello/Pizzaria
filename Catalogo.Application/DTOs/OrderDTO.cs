using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalogo.Application.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }

        [Required]
        public DeliveryDetailsDTO DeliveryDetails { get; set; }

        [Required]
        public ICollection<PizzaDTO> Pizzas { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }

        public DateTime RequestDate { get; set; }
    }
}
