using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
//using WhatDoYouOwn_ASPNET.Models;

namespace WhatDoYouOwn_ASPNET.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
