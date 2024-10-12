using Microsoft.AspNetCore.Mvc;
using WhatDoYouOwn_ASPNET.Helper;
using WhatDoYouOwn_ASPNET.Models;
using WhatDoYouOwn_ASPNET.Repository.Interfaces;

namespace WhatDoYouOwn_ASPNET.Controllers
{
    public class SingInController : Controller
    {   
        private readonly IUserRepository _userRepository;
        private readonly IUserSession _userSession;

        public SingInController(IUserRepository userRepository, IUserSession userSession)
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

        public IActionResult EnterAccount(UserModel user)
        {
            UserModel SearchedUser = _userRepository.SearchByEmailAndPassword(user.Email, user.Senha);
            if (SearchedUser == null)
            {
                TempData["ErrorMensage"] = "Usuário não encontrado!";
                return RedirectToAction("Index");
            }
            else
            {
                _userSession.CreateUserSession(SearchedUser);
                return Redirect("/");
            }
        }
    }
}
