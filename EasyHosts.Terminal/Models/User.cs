using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyHosts.Terminal.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int Status { get; set; }

        [DisplayName("CPF do Usuário:")]
        public string Cpf { get; set; }

        public string Hash { get; set; }
        public int PerfilId { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}