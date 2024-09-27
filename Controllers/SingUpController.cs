using Microsoft.AspNetCore.Mvc;
using WhatDoYouOwn_ASPNET.Models;
using WhatDoYouOwn_ASPNET.Repository.Interfaces;

namespace WhatDoYouOwn_ASPNET.Controllers
{
    public class SingUpController : Controller
    {   
        private readonly IUserRepository _userRepository;

        public SingUpController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel user)
        {
            _userRepository.NewUser(user);
            return Redirect("/");
        }
    }
}
