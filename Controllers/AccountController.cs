using Microsoft.AspNetCore.Mvc;
using WhatDoYouOwn_ASPNET.Helper;
using WhatDoYouOwn_ASPNET.Models;

namespace WhatDoYouOwn_ASPNET.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserSession _userSession;

        public AccountController(IUserSession userSession) { _userSession = userSession; }

        public IActionResult Index()
        {
            UserModel model = _userSession.GetUserSession();

            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("Index", "SingUp");
        }
    }
}
