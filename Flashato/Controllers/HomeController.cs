using Flashato.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flashato.Controllers
{
    [RoutePrefix("cards")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("{id:int}/edit")]
        public ActionResult EditCard(int id)
        {
            Flashcard card = new Flashcard { Id = id };
            return View("Index", card);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}