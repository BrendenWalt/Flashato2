using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flashato.Controllers
{
    [RoutePrefix("Register")]
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Register()
        {
            return View();
        }
    }
}