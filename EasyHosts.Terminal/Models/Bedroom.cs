using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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

        [EnumDataType(typeof(TypeStatus))]
        [Required]
        public TypeStatus Status { get; set; }
        public enum TypeStatus
        {
            disponivel = 0,
            ocupado = 1,
            manutencao = 2,
            reservado = 3
        }

        public int TypeBedroomId { get; set; }
        public virtual TypeBedroom TypeBedroom { get; set; }
    }
}