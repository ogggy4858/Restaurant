using Repositories.Interfaces;
using Repositories.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ViewerController : Controller
    {
        private readonly IDesignRepository _designRepository;
        private readonly IUserRepository _userRepository;

        public ViewerController(IDesignRepository designRepository,
            IUserRepository userRepository)
        {
            _designRepository = designRepository;
            _userRepository = userRepository;
        }

        public ActionResult NotFoundPage()
        {
            try
            {
                ViewBag.IsAdmin = _userRepository.IsAdmin(User.Identity.Name);
                ViewBag.WelComeMessage = _designRepository.DisplayWelcome("Welcome");
                ViewBag.Info = _designRepository.DisplayInfo("Info");
            }
            catch
            {
                ViewBag.IsAdmin = false;
                ViewBag.WelComeMessage = CommonData.DisplayWelcome;
                ViewBag.Info = CommonData.DisplayInfo;
            }
            return View();
        }

        public ActionResult Logged()
        {
            try
            {
                ViewBag.IsAdmin = _userRepository.IsAdmin(User.Identity.Name);
                ViewBag.WelComeMessage = _designRepository.DisplayWelcome("Welcome");
                ViewBag.Info = _designRepository.DisplayInfo("Info");
            }
            catch
            {
                ViewBag.IsAdmin = false;
                ViewBag.WelComeMessage = CommonData.DisplayWelcome;
                ViewBag.Info = CommonData.DisplayInfo;
            }
            return View();
        }
    }
}