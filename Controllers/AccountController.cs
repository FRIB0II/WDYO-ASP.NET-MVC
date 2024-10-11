using Microsoft.AspNetCore.Mvc;
using WhatDoYouOwn_ASPNET.Models;

namespace WhatDoYouOwn_ASPNET.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
