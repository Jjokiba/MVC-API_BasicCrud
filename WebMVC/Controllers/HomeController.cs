using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: home
        public ActionResult Index()
        {
            return Redirect("~/Cliente");
        }
    }
}