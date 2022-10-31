using EasyHosts.Terminal.Models;
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
        public async Task<ActionResult> Checkin(CheckinViewModel checkinViewModel)
        {
            var checkinOfUser = await context.Booking.Include(x => x.Bedroom)
                                                      .Include(x => x.User)
                                                      .Where(x => x.User.Cpf == checkinViewModel.User.Cpf && x.CodeBooking == checkinViewModel.Booking.CodeBooking).FirstOrDefaultAsync();
            if (checkinOfUser == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Erro no Chekin!" });
            }

            return View("FinalizarCheckin", checkinOfUser);
        }

        public async Task<ActionResult> FinalizarCheckin(int checkin)
        {
            
            return View();
        }

        public async Task<ActionResult> Checkout()
        {
            return View();
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


