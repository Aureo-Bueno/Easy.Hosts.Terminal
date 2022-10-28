using EasyHosts.Terminal.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyHosts.Terminal.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Nome do evento muito extenso!")]
        public string NameEvent { get; set; }

        [MaxLength(100, ErrorMessage = "Nome do organizador muito extenso!")]
        public string Organizer { get; set; }

        public DateTime DateEvent { get; set; }

        [MaxLength(150, ErrorMessage = "Local muito extenso!")]
        public string EventsPlace { get; set; }

        [MaxLength(100)]
        public string Picture { get; set; }
        public ICollection<AlbumEvent> AlbumEvent { get; set; }

        [MaxLength(100, ErrorMessage = "Descricao muito extensa!")]
        public string DescriptionEvent { get; set; }

        [MaxLength(100, ErrorMessage = "Atracao muito extensa!")]
        public string Attractions { get; set; }

        public EventType TypeEvent { get; set; }
    }
}