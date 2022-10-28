using System.ComponentModel.DataAnnotations;

namespace EasyHosts.Terminal.Models
{
    public class Perfil
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
    }
}