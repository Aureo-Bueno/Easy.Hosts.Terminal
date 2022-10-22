using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyHosts.Terminal.Models.ViewModels
{
    public class CheckinCheckoutViewModel
    {
        public CheckinViewModel Checkin { get; set; }
        public CheckoutViewModel Checkout { get; set; }
    }
}