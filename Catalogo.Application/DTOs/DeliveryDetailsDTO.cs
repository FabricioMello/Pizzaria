using System.ComponentModel.DataAnnotations;

namespace Catalogo.Application.DTOs
{
    public class DeliveryDetailsDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatório")]
        [MinLength(5)]
        [MaxLength(150)]
        public string Address { get; set; }

        [Required(ErrorMessage = "O número de telefone é obrigatório")]
        [MinLength(9)]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "O número da casa é obrigatório")]
        [MinLength(1)]
        [MaxLength(7)]
        public string HouseNumber { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório")]
        [MinLength(3)]
        [MaxLength(50)]
        public string District { get; set; }
    }
}
