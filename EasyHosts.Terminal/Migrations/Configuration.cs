using EasyHosts.Terminal.Models;
using EasyHosts.Terminal.Models.Enums;
using System;
using System.Data.Entity.Migrations;

namespace EasyHosts.Terminal.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "EasyHosts.Terminal.Models.Context";
        }

        protected override void Seed(Context context)
        {
            context.Perfil.AddOrUpdate(
                   p => p.Description,
                   new Models.Perfil
                   {
                       Id = 1,
                       Description = "Admin"
                   },
                   new Models.Perfil
                   {
                       Id = 2,
                       Description = "Funcionario"
                   },
                   new Models.Perfil
                   {
                       Id = 3,
                       Description = "Hospede"
                   });


            context.User.AddOrUpdate(
                    p => p.Email,
                    new Models.User
                    {
                        Id = 1,
                        Name = "Aureo Alexandre Bueno Azevedo Filho",
                        Email = "aureo.bueno@easy.com.br",
                        Password = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        ConfirmPassword = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        Status = 1,
                        Cpf = "568.974.261/46",
                        Hash = "",
                        PerfilId = 1
                    },
                    new Models.User
                    {
                        Id = 2,
                        Name = "Luiz Guilherme Ribeiro",
                        Email = "luiz.gui@easy.com.br",
                        Password = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        ConfirmPassword = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        Status = 1,
                        Cpf = "568.974.261/46",
                        Hash = "",
                        PerfilId = 2
                    },
                    new Models.User
                    {
                        Id = 3,
                        Name = "Luiz Romao de Carvalho",
                        Email = "luiz.roman@easy.com.br",
                        Password = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        ConfirmPassword = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        Status = 0,
                        Cpf = "568.974.261/46",
                        Hash = "",
                        PerfilId = 1
                    },
                    new Models.User
                    {
                        Id = 4,
                        Name = "Joao Pedro",
                        Email = "joao.pedro@easy.com.br",
                        Password = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        ConfirmPassword = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        Status = 1,
                        Cpf = "568.974.261/46",
                        Hash = "",
                        PerfilId = 1
                    },
                    new Models.User
                    {
                        Id = 5,
                        Name = "Alex",
                        Email = "alex@easy.com.br",
                        Password = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        ConfirmPassword = "vDDsx1jGNpHGnmbYRjJmcJJL/5YJtf6/OcHobMqPtyeDrV5bcHY1nm1wm8WM03mt4UlZRfhZHph2yyY05DE5pg==",
                        Status = 1,
                        Cpf = "568.974.261/46",
                        Hash = "",
                        PerfilId = 3
                    });

            context.TypeBedroom.AddOrUpdate(
                  p => p.NameTypeBedroom,
                  new Models.TypeBedroom
                  {
                      Id = 1,
                      NameTypeBedroom = "Solteiro",
                      AmountOfPeople = 1,
                      AmountOfBed = 1,
                      ApartmentAmenities = TypeBedroomClass.Prata,
                  },
                  new Models.TypeBedroom
                  {
                      Id = 2,
                      NameTypeBedroom = "Casal",
                      AmountOfPeople = 2,
                      AmountOfBed = 1,
                      ApartmentAmenities = TypeBedroomClass.Ouro,
                  },
                  new Models.TypeBedroom
                  {
                      Id = 3,
                      NameTypeBedroom = "Familia",
                      AmountOfPeople = 5,
                      AmountOfBed = 3,
                      ApartmentAmenities = TypeBedroomClass.Diamante,
                  });

            context.Bedroom.AddOrUpdate(
                 p => p.NameBedroom,
                 new Models.Bedroom
                 {
                     Id = 1,
                     NameBedroom = "Quarto Single",
                     Value = 350,
                     Description = "Quarto para uma pessoa",
                     Picture = "https://picsum.photos/1200/720",
                     Status = BedroomStatus.Reservado,
                     TypeBedroomId = 1
                 },
                 new Models.Bedroom
                 {
                     Id = 2,
                     NameBedroom = "Quarto para Casal",
                     Value = 650,
                     Description = "Quarto para duas pessoas",
                     Picture = "https://picsum.photos/1200/720",
                     Status = BedroomStatus.Reservado,
                     TypeBedroomId = 2
                 },
                 new Models.Bedroom
                 {
                     Id = 3,
                     NameBedroom = "Quarto Familia",
                     Value = 1080,
                     Description = "Quarto para familia",
                     Picture = "https://picsum.photos/1200/720",
                     Status = BedroomStatus.Reservado,
                     TypeBedroomId = 3
                 },
                 new Models.Bedroom
                 {
                     Id = 4,
                     NameBedroom = "Quarto Single",
                     Value = 350,
                     Description = "Quarto para uma pessoa",
                     Picture = "https://picsum.photos/1200/720",
                     Status = BedroomStatus.Reservado,
                     TypeBedroomId = 1
                 });

            context.Booking.AddOrUpdate(
                 p => p.CodeBooking,
                 new Models.Booking
                 {
                     Id = 1,
                     CodeBooking = "654321",
                     DateCheckin = DateTime.Now,
                     DateCheckout = DateTime.Now,
                     ValueBooking = 1000,
                     UserId = 5,
                     BedroomId = 1,
                     Status = BookingStatus.Voucher
                 },
                 new Models.Booking
                 {
                     Id = 2,
                     CodeBooking = "123456",
                     DateCheckin = DateTime.Now,
                     DateCheckout = DateTime.Now,
                     ValueBooking = 3000,
                     UserId = 5,
                     BedroomId = 2,
                     Status = BookingStatus.Voucher
                 });

            context.AlbumEvent.AddOrUpdate(
                p => p.EventId,
                new Models.AlbumEvent
                {
                    Id = 1,
                    EventId = 1,
                    Picture = "https://picsum.photos/1200/720"
                },
                new Models.AlbumEvent
                {
                    Id = 2,
                    EventId = 1,
                    Picture = "https://picsum.photos/1200/720"
                });

            context.Event.AddOrUpdate(
                 p => p.NameEvent,
                 new Models.Event
                 {
                     Id = 1,
                     NameEvent = "",
                     Organizer = "",
                     DateEvent = DateTime.Now,
                     EventsPlace = "",
                     Picture = "",
                     DescriptionEvent = "",
                     Attractions = "",
                     TypeEvent = EventType.Show
                 },
                 new Models.Event
                 {
                     Id = 2,
                     NameEvent = "",
                     Organizer = "",
                     DateEvent = DateTime.Now,
                     EventsPlace = "",
                     Picture = "",
                     DescriptionEvent = "",
                     Attractions = "",
                     TypeEvent = EventType.Show
                 },
                 new Models.Event
                 {
                     Id = 3,
                     NameEvent = "",
                     Organizer = "",
                     DateEvent = DateTime.Now,
                     EventsPlace = "",
                     Picture = "",
                     DescriptionEvent = "",
                     Attractions = "",
                     TypeEvent = EventType.Comedia
                 },
                 new Models.Event
                 {
                     Id = 4,
                     NameEvent = "",
                     Organizer = "",
                     DateEvent = DateTime.Now,
                     EventsPlace = "",
                     Picture = "",
                     DescriptionEvent = "",
                     Attractions = "",
                     TypeEvent = EventType.Comedia
                 },
                 new Models.Event
                 {
                     Id = 5,
                     NameEvent = "",
                     Organizer = "",
                     DateEvent = DateTime.Now,
                     EventsPlace = "",
                     Picture = "",
                     DescriptionEvent = "",
                     Attractions = "",
                     TypeEvent = EventType.EventosReligiosos
                 });

        }
    }
}
