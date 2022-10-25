using EasyHosts.Terminal.Models;
using EasyHosts.Terminal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        //GET: Terminal/Bedroom
        public async Task<ActionResult> Quartos()
        {
            var listBedroom = await _context.Bedroom.ToListAsync();
            return View(listBedroom);
        }

        // GET: Terminal/DetailsBedroom/id
        public async Task<ActionResult> DetalhesQuarto(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not provided!" });
            }

            var bedroomDetails = await _context.Bedroom.FindAsync(id);

            if (bedroomDetails == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not provided!" });
            }
            return View(bedroomDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Pesquisar(FormCollection fc, string searchString)
        {
            ViewBag.Search = "";
            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.Search = searchString;
                var bedrooms = _context.Bedroom.Include(c => c.TypeBedroom)
                                               .Include(e => e.TypeBedroom.AmountOfBed)
                                               .Where(c => c.NameBedroom.Contains(searchString)).OrderBy(o => o.NameBedroom);

                await bedrooms.ToListAsync();
                return View("Index",bedrooms);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Eventos()
        {
            var listEvents = await _context.Event.ToListAsync();
            return View(listEvents);
        }

        public async Task<ActionResult> DetalhesEvento(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not provided!" });
            }

            var eventDetail= await _context.Event.FirstOrDefaultAsync(f => f.Id == id);

            if (eventDetail == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found!" });
            }

            return View(eventDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Checkin()
        {
            return View();
        }

        public async Task<ActionResult> Checkout()
        {
            return View();
        }

        public ActionResult Error(string message)
        {
            return View();
        }
    }
}