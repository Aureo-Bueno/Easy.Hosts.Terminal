namespace EasyHosts.Terminal.Migrations
{
    using EasyHosts.Terminal.Models;
    using EasyHosts.Terminal.Models.Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EasyHosts.Terminal.Models.Context";
        }

        protected override void Seed(Context context)
        {
            context.Event.AddOrUpdate(
            p => p.NameEvent,
            new Models.Event
            {
                Id = 1,
                NameEvent = "Show de Dj",
                Organizer = "Organizador 01",
                DateEvent = DateTime.Now,
                EventsPlace = "Rua Antonio Jose, 28, Aparecida-SP",
                DescriptionEvent = "Evento de Show",
                Attractions = "Djs e Mc's",
                TypeEvent = EventType.Show
            },
            new Models.Event
            {
                Id = 2,
                NameEvent = "Show de MC",
                Organizer = "Organizador 02",
                DateEvent = DateTime.Now,
                EventsPlace = "Rua Antonio Moreira, 04, Guaratingueta-SP",
                DescriptionEvent = "Evento de Show",
                Attractions = "Djs e Mc's",
                TypeEvent = EventType.Show
            },
            new Models.Event
            {
                Id = 3,
                NameEvent = "Show de Comedia",
                Organizer = "Organizador 03",
                DateEvent = DateTime.Now,
                EventsPlace = "Rua Moreira Luiz, 17, Guaratingueta-SP",
                DescriptionEvent = "Evento de Comedia",
                Attractions = "Comediante da Noite",
                TypeEvent = EventType.Comedia
            });

            context.TypeBedroom.AddOrUpdate(
            p => p.AmountOfPeople,
            new Models.TypeBedroom
            {
              Id = 1,
              AmountOfPeople = 2,
              AmountOfBed = 1,
              ApartmentAmenities = "Ar-Condicionado, Frigobar e Fogao.",
            });

            context.TypeBedroom.AddOrUpdate(
            p => p.AmountOfPeople,
            new Models.TypeBedroom
            {
                Id = 2,
                AmountOfPeople = 4,
                AmountOfBed = 2,
                ApartmentAmenities = "Ar-Condicionado, Frigobar e Fogao.",
            });

            context.TypeBedroom.AddOrUpdate(
            p => p.AmountOfPeople,
            new Models.TypeBedroom
            {
                Id = 3,
                AmountOfPeople = 5,
                AmountOfBed = 4,
                ApartmentAmenities = "Ar-Condicionado, Frigobar e Fogao.",
            });

            context.Bedroom.AddOrUpdate(
            p => p.NameBedroom,
            new Models.Bedroom
            {
              Id = 1,
              NameBedroom = "Quarto de Casal",
              Value = 350.00M,
              Description = "Quarto de casal,confortavel e tambem acomodativo.",
              Status = BedroomStatus.Disponivel,
              TypeBedroomId = 1
            });

            context.Bedroom.AddOrUpdate(
            p => p.NameBedroom,
            new Models.Bedroom
            {
                Id = 2,
                NameBedroom = "Quarto para dois Casais",
                Value = 750.00M,
                Description = "Qaurto para dois casais,confortavel e tambem acomodativo.",
                Status = BedroomStatus.Disponivel,
                TypeBedroomId = 2
            });

            context.Bedroom.AddOrUpdate(
            p => p.NameBedroom,
            new Models.Bedroom
            {
                Id = 3,
                NameBedroom = "Quarto Familia",
                Value = 1250.00M,
                Description = "Quarto familia,confortavel e tambem acomodativo.",
                Status = BedroomStatus.Disponivel,
                TypeBedroomId = 3
            });
        }
    }
}
