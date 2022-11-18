using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyHosts.Terminal.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Valor")]
        public decimal Value { get; set; }

        [DisplayName("Quantidade do Produto")]
        public int QuantityProduct { get; set; }
    }
}