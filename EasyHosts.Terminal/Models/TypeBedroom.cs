using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyHosts.Terminal.Models
{
    public class TypeBedroom
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AmountOfPeople { get; set; }

        [Required]
        public int AmountOfBed { get; set; }

        [Required]
        [MaxLength(255)]
        public string ApartmentAmenities { get; set; }

        

    }
}