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
        }
    }
}