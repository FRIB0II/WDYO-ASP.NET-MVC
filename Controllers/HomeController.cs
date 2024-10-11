using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WhatDoYouOwn_ASPNET.Helper;
using WhatDoYouOwn_ASPNET.Models;

namespace WhatDoYouOwn_ASPNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserSession _userSession;

        public HomeController(IUserSession userSession)
        {
            _userSession = userSession;
        }

        public IActionResult Index()
        {

            if (_userSession.GetUserSession() != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "SingUp");
            }
        }
    }
}
