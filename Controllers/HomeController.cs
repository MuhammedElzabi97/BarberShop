﻿using Microsoft.AspNetCore.Mvc;

namespace WebProjesi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
