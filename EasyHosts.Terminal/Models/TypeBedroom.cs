using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyHosts.Terminal.Models
{
    public class TypeBedroom
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [DisplayName("Nome")]
        public string NameTypeBedroom { get; set; }

        [Required]
        [DisplayName("Quantidade de pessoas")]
        public int AmountOfPeople { get; set; }

        [Required]
        [DisplayName("Quantidade de camas")]
        public int AmountOfBed { get; set; }

        [Required]
        [MaxLength(255)]
        [DisplayName("Comodidades")]
        public string ApartmentAmenities { get; set; }

        

    }
}