using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyHosts.Terminal.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public int PerfilId { get; set; }
        public ICollection<Perfil> Perfil { get; set; }
    }
}