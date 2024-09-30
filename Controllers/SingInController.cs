using Microsoft.AspNetCore.Mvc;
using WhatDoYouOwn_ASPNET.Models;
using WhatDoYouOwn_ASPNET.Repository.Interfaces;

namespace WhatDoYouOwn_ASPNET.Controllers
{
    public class SingInController : Controller
    {   
        private readonly IUserRepository _userRepository;

        public SingInController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EnterAccount(UserModel user)
        {
            bool SearcheUser = _userRepository.SearchByEmailAndPassword(user.Email, user.Senha);
            if (SearcheUser == false)
            {
                TempData["ErrorMensage"] = "Usuário não encontrado!";
                return RedirectToAction("Index");
            }
            else
            {
                return Redirect("/");
            }
        }
    }
}
