using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flashato.Controllers
{
    [RoutePrefix("decks")]
    public class DecksController : Controller
    {
        // GET: Decks
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult All()
        {
            return View();
        }
    }
}