using Microsoft.AspNetCore.Mvc;
using WhatDoYouOwn_ASPNET.Filters;
using WhatDoYouOwn_ASPNET.Helper;
using WhatDoYouOwn_ASPNET.Models;
using WhatDoYouOwn_ASPNET.Repository.Interfaces;

namespace WhatDoYouOwn_ASPNET.Controllers
{
    [LoggedUserPages]
    public class DeviceController : Controller
    {
        private readonly IDeviceRepository _deviceRepo;
        private readonly IUserRepository _userRepo;
        private readonly IUserSession _session;

        public DeviceController(IDeviceRepository deviceRepo, IUserRepository userRepo, IUserSession session) 
        {
            _deviceRepo = deviceRepo;
            _userRepo = userRepo;
            _session = session;
        }

        public async Task<IActionResult> Index()
        {
            TempData["SuccesMessage"] = null;
            TempData["ErrorMessage"] = null;

            UserModel user = _session.GetUserSession();

            IEnumerable<DeviceModel> devices = await _deviceRepo.GetDevicesByUserIdAsync(user.IdUsuario);

            return View(devices);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _deviceRepo.DeleteDeviceAsync(id);

            if (result)
            {
                TempData["SuccessMessage"] = "Computador deletado com sucesso!";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Houve um erro ao deletar o computador";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(DeviceModel device)
        {
            DeviceModel result = await _deviceRepo.AddDeviceAsync(device);

            if (result != null) { return RedirectToAction("Index"); }

            return View();
        }


    }
}
