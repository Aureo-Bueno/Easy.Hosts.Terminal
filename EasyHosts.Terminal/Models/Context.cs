using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EasyHosts.Terminal.Models
{
    public class Context : DbContext
    {
        public Context() : base(nameOrConnectionString: "EasyHostsBd")
        { }

        public DbSet<Bedroom> Bedroom { get; set; }

        public DbSet<TypeBedroom> TypeBedroom { get; set; }

        public DbSet<Event> Event { get; set; }
        protected override void OnModelCreating(DbModelBuilder mb)
        {
            var bedroom = mb.Entity<Bedroom>();
            bedroom.ToTable("TB_BEDROOM");
            bedroom.Property(x => x.Id).HasColumnName("ID");
            bedroom.Property(x => x.NameBedroom).HasColumnName("NAME_BEDROOM");
            bedroom.Property(x => x.Value).HasColumnName("VALUE");
            bedroom.Property(x => x.Description).HasColumnName("DESCRIPTION");
            bedroom.Property(x => x.Status).HasColumnName("STATUS");
            bedroom.Property(x => x.TypeBedroomId).HasColumnName("TYPE_BEDROOM");

            var typebedroom = mb.Entity<TypeBedroom>();
            typebedroom.ToTable("TB_TYPE_BEDROOM");
            typebedroom.Property(x => x.Id).HasColumnName("ID");
            typebedroom.Property(x => x.AmountOfPeople).HasColumnName("AMOUNT_OF_PEOPLE");
            typebedroom.Property(x => x.AmountOfBed).HasColumnName("AMOUNT_OF_BED");
            typebedroom.Property(x => x.ApartmentAmenities).HasColumnName("APARTMENT_AMENITIES");

            var eventBd = mb.Entity<Event>();
            eventBd.ToTable("TB_EVENT");
            eventBd.Property(x => x.Id).HasColumnName("ID");
            eventBd.Property(x => x.NameEvent).HasColumnName("NAME_EVENT");
            eventBd.Property(x => x.Organizer).HasColumnName("ORGANIZER");
            eventBd.Property(x => x.DateEvent).HasColumnName("DATE_EVENT");
            eventBd.Property(x => x.EventsPlace).HasColumnName("EVENTS_PLACE");
            eventBd.Property(x => x.DescriptionEvent).HasColumnName("DESCRIPTION_EVENT");
            eventBd.Property(x => x.Attractions).HasColumnName("ATTRACTIONS");
            eventBd.Property(x => x.TypeEvent).HasColumnName("TYPE_EVENT");
        }
    }
}