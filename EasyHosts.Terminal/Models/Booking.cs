using System;
using System.ComponentModel.DataAnnotations;

namespace EasyHosts.Terminal.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public string CodeBooking { get; set; }
        public int UserId { get; set; }

        public DateTime DateCheckin { get; set; }
        public DateTime DateCheckout { get; set; }

        public decimal ValueBooking { get; set; }

        public virtual User User { get; set; }

        public int BedroomId { get; set; }
        public virtual Bedroom Bedroom { get; set; }
    }
}