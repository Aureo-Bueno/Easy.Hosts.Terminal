using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EasyHosts.Terminal.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public async Task<ActionResult> Error404()
        {
            Response.StatusCode = 404;
            return View();
        }

        public async Task<ActionResult> Error500()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}