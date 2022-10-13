using EasyHosts.Terminal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyHosts.Terminal.Controllers
{
    public class HomeController : Controller
    {
        private Context db = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }


        public ActionResult VisualizarQuartos()
        {
            var listBedroom = db.Bedroom.ToList();
            if (listBedroom == null)
            {
                return View();
            }
            return View(listBedroom);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public JsonResult EditarUsuario(string id, string name)
        {
            try
            {
                Bedroom bed = db.Bedroom.Find(Convert.ToInt32(id));
                if (bed != null)
                {
                    bed.NameBedroom = name;
                    if (TryValidateModel(bed))
                    {
                        db.Entry(bed).State = EntityState.Modified;
                        db.SaveChanges();
                        return Json("ok");
                    }
                    else
                        return Json("erro");
                }
                else
                    return Json("n");
            }
            catch
            {
                return Json("n");
            }
        }


        public ActionResult VisualizarEventos()
        {
            return View();
        }

        public ActionResult DetalhesEvento()
        {
            return View();
        }

        public ActionResult Checkin()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }
    }
}