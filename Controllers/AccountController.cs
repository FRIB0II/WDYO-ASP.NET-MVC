using Microsoft.AspNetCore.Mvc;
using WhatDoYouOwn_ASPNET.Helper;
using WhatDoYouOwn_ASPNET.Models;
using WhatDoYouOwn_ASPNET.Repository.Interfaces;
using WhatDoYouOwn_ASPNET.Filters;
    //0800 021 6304

namespace WhatDoYouOwn_ASPNET.Controllers
{
    [LoggedUserPages]
    public class AccountController : Controller
    {
        private readonly IUserSession _userSession;
        private readonly IUserRepository _userRepo;

        public AccountController(IUserSession userSession, IUserRepository userRepo) 
        { 
            _userSession = userSession;
            _userRepo = userRepo;
        }

        public IActionResult Index()
        {
            UserModel model = _userSession.GetUserSession();

            if (model != null)
            {
                return View(model);
            }
        
            return RedirectToAction("Index", "SingUp");
        }

        public IActionResult Edit()
        {
            UserModel model = _userSession.GetUserSession();

            if (model != null) { return View(model); }

            return RedirectToAction("Index", "SingUp");
        }

        public IActionResult DeleteConfirm() 
        {
            UserModel model = _userSession.GetUserSession();

            return View(model);
        }

        public IActionResult Delete(int id)
        { 
            bool result = _userRepo.DeleteUser(id);

            if (result)
            {
                _userSession.RemoveUserSession();

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(UserModel model)
        {
            var result = _userRepo.EditUser(model);


            if (result != null) 
            {
                _userSession.RemoveUserSession();
                _userSession.CreateUserSession(result);
                TempData["SuccesMessage"] = "Informações atualizadas com sucesso!";
                return RedirectToAction("Index");  
            } 
            else 
            {
                TempData["ErrorMessage"] = "Houve algum erro ao atualizar as informações, tente novamente.";
                return View(model); 
            }
        }
    }
}
