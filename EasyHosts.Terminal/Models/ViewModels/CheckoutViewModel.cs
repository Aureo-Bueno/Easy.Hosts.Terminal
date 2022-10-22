using System.ComponentModel;

namespace EasyHosts.Terminal.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public int ChechoutId { get; set; }

        [DisplayName("Booking")]
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        [DisplayName("Usuario")]
        public int UsergId { get; set; }
        public User User { get; set; }
    }
}