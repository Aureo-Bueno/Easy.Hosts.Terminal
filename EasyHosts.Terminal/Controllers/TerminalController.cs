using EasyHosts.Terminal.Models;
using EasyHosts.Terminal.Models.Enums;
using EasyHosts.Terminal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EasyHosts.Terminal.Controllers
{
    public class TerminalController : Controller
    {
        private Context context = new Context();

        public async Task<ActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> Menu()
        {
            return View();
        }

        //GET: Terminal/Bedroom
        public async Task<ActionResult> Quartos()
        {

            var listBedroom = await context.Bedroom.ToListAsync();
            return View(listBedroom);
        }

        // GET: Terminal/DetailsBedroom/id
        public async Task<ActionResult> DetalhesQuarto(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Quarto não encontrado!" });
            }

            var bedroomDetails = await context.Bedroom.FindAsync(id);

            if (bedroomDetails == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Não encontramos o quarto solicitado!" });
            }
            return View(bedroomDetails);
        }

        [HttpPost]
        public async Task<ActionResult> Pesquisar(FormCollection fc, string searchString)
        {
            ViewBag.Search = "";
            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.Search = searchString;
                var bedrooms = context.Bedroom.Include(c => c.TypeBedroom)
                                               .Where(c => c.NameBedroom.Contains(searchString)).OrderBy(o => o.NameBedroom);


                return View("Quartos", await bedrooms.ToListAsync());
            }
            else
            {
                return RedirectToAction("Quartos");
            }
        }


        //GET: Terminal/Events
        public async Task<ActionResult> Eventos()
        {
            var listEvents = await context.Event.ToListAsync();
            return View(listEvents);
        }

        //GET: Terminal/Events/id
        public async Task<ActionResult> DetalhesEvento(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Evento não encontrado!" });
            }

            var eventDetail = await context.Event.FirstOrDefaultAsync(f => f.Id == id);

            if (eventDetail == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Não encontramos o evento solicitado!" });
            }

            return View(eventDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Checkin(CheckinCheckoutViewModel checkinViewModel)
        {
            Booking checkinOfUser = await context.Booking
                                    .Where(x => x.User.Cpf == checkinViewModel.Checkin.User.Cpf && x.CodeBooking == checkinViewModel.Checkin.Booking.CodeBooking)
                                    .Where(x => x.Bedroom.Status == BedroomStatus.Reservado)
                                    .Where(x => x.Status == BookingStatus.Voucher)
                                    .Include(x => x.User)
                                    .Include(x => x.Bedroom)
                                    .FirstOrDefaultAsync();

            return RedirectToAction("SumarioCheckin", "Terminal", new { checkinOfUser.Id });
        }

        [HttpGet]
        public async Task<ActionResult> SumarioCheckin(Booking idBooking)
        {
            if (idBooking != null)
            {
                Booking finalizarCheckin = await context.Booking.Where(x => x.Id == idBooking.Id).FirstOrDefaultAsync();

                return View(finalizarCheckin);
            }

            return RedirectToAction(nameof(Error), new { message = "Reserva não encontrada!" });
        }

        [HttpPost]
        public async Task<ActionResult> FinalizarCheckin([Bind(Include = "Id")] Booking booking)
        {
            Booking bookingFinal = context.Booking.Find(booking.Id);

            bookingFinal.Bedroom.Status = BedroomStatus.Ocupado;
            bookingFinal.Status = BookingStatus.Checkin;
            context.Entry(bookingFinal).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return View("Menu");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Checkout(CheckinCheckoutViewModel checkoutViewModel)
        {
            Booking checkoutOfUser = await context.Booking
                                             .Where(x => x.User.Cpf == checkoutViewModel.Checkout.User.Cpf && x.CodeBooking == checkoutViewModel.Checkout.Booking.CodeBooking)
                                             .Where(x => x.Bedroom.Status == BedroomStatus.Ocupado)
                                             .Where(x => x.Status == BookingStatus.Checkin)
                                             .Include(x => x.User)
                                             .Include(x => x.Bedroom)
                                             .FirstOrDefaultAsync();

            return RedirectToAction("SumarioCheckout", "Terminal", new { checkoutOfUser.Id });
        }

        public async Task<ActionResult> SumarioCheckout(Booking idBooking)
        {
            if (idBooking != null)
            {
                Booking finalizarCheckout = await context.Booking.Where(x => x.Id == idBooking.Id).FirstOrDefaultAsync();

                return View(finalizarCheckout);
            }

            return RedirectToAction(nameof(Error), new { message = "Reserva nao encontrada!" });
        }

        [HttpPost]
        public async Task<ActionResult> FinalizarCheckout([Bind(Include = "Id")] Booking booking)
        {
            Booking finalBooking = context.Booking.Find(booking.Id);

            finalBooking.Bedroom.Status = BedroomStatus.Disponivel;
            finalBooking.Status = BookingStatus.Checkout;
            context.Entry(finalBooking).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return View("Menu");
        }

        public ActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
            };
            return View(viewModel);

        }
    }
}
