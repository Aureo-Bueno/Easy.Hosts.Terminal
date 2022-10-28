using System.ComponentModel.DataAnnotations;

namespace EasyHosts.Terminal.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }
    }
}