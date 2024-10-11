using Microsoft.AspNetCore.Mvc;
using WhatDoYouOwn_ASPNET.Helper;
using WhatDoYouOwn_ASPNET.Models;
using WhatDoYouOwn_ASPNET.Repository.Interfaces;

namespace WhatDoYouOwn_ASPNET.Controllers
{
    public class SingUpController : Controller
    {   
        private readonly IUserRepository _userRepository;
        private readonly IUserSession _userSession;

        public SingUpController(IUserRepository userRepository, IUserSession userSession)
        {
            _userRepository = userRepository;
            _userSession = userSession;
        }

        public IActionResult Index()
        {
            if (_userSession.GetUserSession() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            _userRepository.NewUser(user);
            _userSession.CreateUserSession(user);
            return Redirect("/");
        }
    }
}
