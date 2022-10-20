using EasyHosts.Terminal.Models;
using EasyHosts.Terminal.Models.ViewModels;
using EasyHosts.Terminal.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EasyHosts.Terminal.Controllers
{
    public class HomeController : Controller
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

        public async Task<ActionResult> Quartos()
        {
            var listBedroom = await context.Bedroom.ToListAsync();
            return View(listBedroom);
        }

        [HttpPost]
        public async Task<ActionResult> Pesquisar(FormCollection fc, string searchString)
        {
            ViewBag.Search = "";
            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.Search = searchString;
                var bedrooms = context.Bedroom.Include(c => c.TypeBedroom)
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
            var listEvents = await context.Event.ToListAsync();
            return View(listEvents);
        }

        public async Task<ActionResult> DetalhesEvento(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not provided!" });
            }
            var eventDetail= await context.Event.FirstOrDefaultAsync(f => f.Id == id);

            if (eventDetail == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Not Found!" });
            }

            return View(eventDetail);
        }

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