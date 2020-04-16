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

        public ViewerController(IDesignRepository designRepository)
        {
            _designRepository = designRepository;
        }

        public ActionResult NotFoundPage()
        {
            try
            {
                ViewBag.WelComeMessage = _designRepository.DisplayWelcome("Welcome");
                ViewBag.Info = _designRepository.DisplayInfo("Info");
            }
            catch
            {
                ViewBag.WelComeMessage = CommonData.DisplayWelcome;
                ViewBag.Info = CommonData.DisplayInfo;
            }
            return View();
        }

        public ActionResult Logged()
        {
            try
            {
                ViewBag.WelComeMessage = _designRepository.DisplayWelcome("Welcome");
                ViewBag.Info = _designRepository.DisplayInfo("Info");
            }
            catch
            {
                ViewBag.WelComeMessage = CommonData.DisplayWelcome;
                ViewBag.Info = CommonData.DisplayInfo;
            }
            return View();
        }
    }
}