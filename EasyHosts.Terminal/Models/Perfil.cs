using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyHosts.Terminal.Models
{
    public class Perfil
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}