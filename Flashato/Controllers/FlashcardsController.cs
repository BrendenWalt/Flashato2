using Flashato.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flashato.Controllers
{
    [RoutePrefix("flashcards")]
    public class FlashcardsController : Controller
    {
        // GET: Flashcards
        public ActionResult Add()
        {
            return View("Index");
        }

        [Route("{id:int}/edit")]
        public ActionResult EditCard(int id)
        {
            Flashcard card = new Flashcard { Id = id };
            return View("Index", card);
        }

        public ActionResult All()
        {
            return View();
        }

        public ActionResult Study()
        {
            return View();
        }
    }
}