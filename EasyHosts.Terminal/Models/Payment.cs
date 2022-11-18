using EasyHosts.Terminal.Models.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyHosts.Terminal.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        public PaymentType TypePayment { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("CVV")]
        public int Cvv { get; set; }

        [DisplayName("Número do cartão")]
        public string NumberCard { get; set; }

        public DateTime DateExpire { get; set; }

        [DisplayName("Nome do hóspede")]
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}