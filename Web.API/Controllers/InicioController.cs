﻿using System.Web.Mvc;

namespace Web.API.Controllers
{
    public class InicioController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
