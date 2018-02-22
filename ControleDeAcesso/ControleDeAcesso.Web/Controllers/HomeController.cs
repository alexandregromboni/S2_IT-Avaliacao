using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2Games.Web.Controllers
{
    [Authorize(Roles = "Administrador, Usuario")]
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["Nome"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}