using EasyHosts.Terminal.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyHosts.Terminal.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        public PaymentType TypePayment { get; set; }

        public string Name { get; set; }

        public int Cvv { get; set; }

        public string NumberCard { get; set; }

        public DateTime DateExpire { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}