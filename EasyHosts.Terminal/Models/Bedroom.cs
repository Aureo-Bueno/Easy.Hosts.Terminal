using EasyHosts.Terminal.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace EasyHosts.Terminal.Models
{
    public class Bedroom
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string NameBedroom { get; set; }

        [Required]
        public decimal Value { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public BedroomStatus Status { get; set; }
        public int TypeBedroomId { get; set; }
        public virtual TypeBedroom TypeBedroom { get; set; }
    }
}