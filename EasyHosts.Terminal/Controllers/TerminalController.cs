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
        private Context _context = new Context();

        public async Task<ActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> Menu()
        {
            return View();
        }

        //GET: Terminal/Bedroom  LISTAGEM DE QUARTOS
        public async Task<ActionResult> Quartos()
        {

            var listBedroom = await _context.Bedroom.ToListAsync();
            return View(listBedroom);
        }

        // GET: Terminal/DetailsBedroom/id  DETALHES DO QUARTO SELECIONADO NA PAGINA ACIMA
        public async Task<ActionResult> DetalhesQuarto(int? id)
        {
            if (id == null)
            {
                TempData["MSG"] = "warning|Desculpe, quarto não encontrado!";
                return RedirectToAction("Quartos");
            }

            var bedroomDetails = await _context.Bedroom.FindAsync(id);

            if (bedroomDetails == null)
            {
                TempData["MSG"] = "error|Desculpe, detalhes não disponiveis!";
                return RedirectToAction("Quartos");
            }
            return View(bedroomDetails);
        }

        //POST: Terminal/Pesquisar    PESQUISA DO QUARTO
        [HttpPost]
        public async Task<ActionResult> Pesquisar(FormCollection fc, string searchString)
        {
            ViewBag.Search = "";
            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.Search = searchString;
                var bedrooms = _context.Bedroom.Include(c => c.TypeBedroom)
                                               .Where(c => c.NameBedroom.Contains(searchString)).OrderBy(o => o.NameBedroom);


                return View("Quartos", await bedrooms.ToListAsync());
            }
            else
            {
                return RedirectToAction("Quartos");
            }
        }


        //GET: Terminal/Events   LISTAGEM DOS EVENTOS
        public async Task<ActionResult> Eventos()
        {
            var listEvents = await _context.Event.ToListAsync();
            return View(listEvents);
        }

        //GET: Terminal/Events/id  DETALHES DO EVENTO SELECIONADO NA PAGINA ACIMA
        public async Task<ActionResult> DetalhesEvento(int? id)
        {
            if (id == null)
            {
                TempData["MSG"] = "warning|Desculpe,não encontramos evento solicitado!";
                return RedirectToAction("Eventos");
            }

            var eventDetail = await _context.Event.FirstOrDefaultAsync(f => f.Id == id);

            if (eventDetail == null)
            {
                TempData["MSG"] = "warning|Desculpe, não encontramos evento solicitado!";
                return RedirectToAction("Eventos");
            }

            return View(eventDetail);
        }

        //POST Terminal/Checkin  CHECKIN DO USUARIO PARA DIRECIONAR PARA A PAGINA DE SUMARIO DO CHECKIN
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Checkin(CheckinCheckoutViewModel checkinViewModel)
        {
            Booking checkinOfUser = await _context.Booking
                               .Where(x => x.User.Cpf == checkinViewModel.Checkin.User.Cpf && x.CodeBooking == checkinViewModel.Checkin.Booking.CodeBooking)
                               .Where(x => x.Bedroom.Status == BedroomStatus.Reservado)
                               .Where(x => x.Status == BookingStatus.Voucher)
                               .Include(x => x.User)
                               .Include(x => x.Bedroom)
                               .FirstOrDefaultAsync();

            if (checkinOfUser != null)
            {
                TempData["MSG"] = "success|Dados Verificados com sucesso!";
                return RedirectToAction("SumarioCheckin", "Terminal", new { checkinOfUser.Id });
            }
            TempData["MSG"] = "error|Desculpe, não encontramos a sua reserva, verifique os campos novamente!";
            return View("Menu", checkinViewModel);
        }

        //GET: Terminal/SumariosCheckin MOSTRA AS INFORMACOES DO USUARIO E DO QUARTO PELO ID DO CHECKIN
        [HttpGet]
        public async Task<ActionResult> SumarioCheckin(Booking idBooking)
        {
            if (idBooking != null)
            {
                Booking finalizarCheckin = await _context.Booking.Where(x => x.Id == idBooking.Id).FirstOrDefaultAsync();

                return View(finalizarCheckin);
            }

            return RedirectToAction(nameof(Error), new { message = "Reserva não encontrada!" });
        }

        //POST: Terminal/FinalizarCheckin ALTERA O STATUS DA RESERVA E DO QUARTO
        [HttpPost]
        public async Task<ActionResult> FinalizarCheckin([Bind(Include = "Id")] Booking booking)
        {
            Booking bookingFinal = _context.Booking.Find(booking.Id);

            if (bookingFinal == null)
            {
                TempData["MSG"] = "error|Reserva não encontrada!";
                return RedirectToAction("SumarioCheckin");
            }

            bookingFinal.Bedroom.Status = BedroomStatus.Ocupado;
            bookingFinal.Status = BookingStatus.Checkin;
            _context.Entry(bookingFinal).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            TempData["MSG"] = "success|Checkin finalizado com sucesso, aproveite a estadia!";
            return View("Menu");
        }

        //POST Terminal/Checkout  CHECKOUT DO USUARIO PARA DIRECIONAR PARA A PAGINA DE SUMARIO DO CHECKOUT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Checkout(CheckinCheckoutViewModel checkoutViewModel)
        {
            Booking checkoutOfUser = await _context.Booking
                                             .Where(x => x.User.Cpf == checkoutViewModel.Checkout.User.Cpf && x.CodeBooking == checkoutViewModel.Checkout.Booking.CodeBooking)
                                             .Where(x => x.Bedroom.Status == BedroomStatus.Ocupado)
                                             .Where(x => x.Status == BookingStatus.Checkin)
                                             .Include(x => x.User)
                                             .Include(x => x.Bedroom)
                                             .FirstOrDefaultAsync();

            if (checkoutOfUser != null)
            {
                TempData["MSG"] = "success|Dados Verificados com sucesso!";
                return RedirectToAction("SumarioCheckout", "Terminal", new { checkoutOfUser.Id });
            }

            TempData["MSG"] = "error|Desculpe, não encontramos a sua reserva, verifique os campos novamente!";
            return View("Menu", checkoutViewModel);
        }


        //GET: Terminal/SumariosCheckout MOSTRA AS INFORMACOES DO USUARIO E DO QUARTO PELO ID DO CHECKOUT
        [HttpGet]
        public async Task<ActionResult> SumarioCheckout(Booking idBooking)
        {
            if (idBooking != null)
            {
                Booking finalizarCheckout = await _context.Booking.Where(x => x.Id == idBooking.Id).FirstOrDefaultAsync();

                return View(finalizarCheckout);
            }

            return RedirectToAction(nameof(Error), new { message = "Reserva nao encontrada!" });
        }

        //POST: Terminal/FinalizarCheckout ALTERA O STATUS DA RESERVA E DO QUARTO
        [HttpPost]
        public async Task<ActionResult> FinalizarCheckout([Bind(Include = "Id")] Booking booking)
        {
            Booking finalBooking = _context.Booking.Find(booking.Id);

            if (finalBooking == null)
            {
                TempData["MSG"] = "error|Reserva não encontrada!";
                return RedirectToAction("SumarioCheckout");
            }

            finalBooking.Bedroom.Status = BedroomStatus.Disponivel;
            finalBooking.Status = BookingStatus.Checkout;
            finalBooking.CodeBooking = "000000";
            _context.Entry(finalBooking).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            TempData["MSG"] = "success|Checkout finalizado com sucesso, boa viagem e volte sempre!";
            return View("Menu");
        }

        //GET: MOSTRA PAGINA DE ERRO AO USUARIO
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
