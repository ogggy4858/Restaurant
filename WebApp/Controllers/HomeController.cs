using Repositories.Interfaces;
using Repositories.StaticData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IFeedBackRepository _feedBackRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IDesignRepository _designRepository;
        private readonly IHotMenuRepository _hotMenuRepository;
        private readonly IMenuRepository _menuRepository;
        private readonly IFoodCategoryRepository _foodCategoryRepository;
        private static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG", ".JFIF", ".RAW", ".JPEG" };

        public HomeController(IUserRepository userRepository, 
            IFeedBackRepository feedBackRepository, 
            IDocumentRepository documentRepository, 
            IDesignRepository designRepository, 
            IHotMenuRepository hotMenuRepository,
            IMenuRepository menuRepository,
            IFoodCategoryRepository foodCategoryRepository)
        {
            _userRepository = userRepository;
            _feedBackRepository = feedBackRepository;
            _documentRepository = documentRepository;
            _designRepository = designRepository;
            _hotMenuRepository = hotMenuRepository;
            _menuRepository = menuRepository;
            _foodCategoryRepository = foodCategoryRepository;
        }

        public ActionResult Index()
        {
            try
            {
                ViewBag.IsAdmin = _userRepository.IsAdmin(User.Identity.Name);
                ViewBag.WelComeMessage = _designRepository.DisplayWelcome("Welcome");
                ViewBag.Info = _designRepository.DisplayInfo("Info");
            }
            catch(Exception ex)
            {
                ViewBag.IsAdmin = false;
                ViewBag.WelComeMessage = CommonData.DisplayWelcome;
                ViewBag.Info = CommonData.DisplayInfo;
            }
            return View();
        }

        public ActionResult Menu()
        {
            try
            {
                ViewBag.IsAdmin = _userRepository.IsAdmin(User.Identity.Name);
                ViewBag.WelComeMessage = _designRepository.DisplayWelcome("Welcome");
                ViewBag.Info = _designRepository.DisplayInfo("Info");
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.IsAdmin = false;
                ViewBag.WelComeMessage = CommonData.DisplayWelcome;
                ViewBag.Info = CommonData.DisplayInfo;
                return View();
            }
        }

        [ChildActionOnly]
        public ActionResult Banner()
        {
            try
            {
                ViewBag.Info = _designRepository.DisplayInfo("Info");
                return PartialView("_Banner", _designRepository.DisplayBanner("Banner"));
            }
            catch (Exception ex)
            {
                ViewBag.Info = CommonData.DisplayInfo;
                return PartialView("_Banner", CommonData.DisplayBanner);
            }
        }

        [ChildActionOnly]
        public ActionResult Info()
        {
            try
            {
                return PartialView("_Info", _designRepository.DisplayInfo("Info"));
            }
            catch (Exception ex)
            {
                return PartialView("_Info", CommonData.DisplayInfo);
            }
        }

        [ChildActionOnly]
        public ActionResult Welcome()
        {
            try
            {
                return PartialView("_Welcome", _designRepository.DisplayWelcome("Welcome"));

            }
            catch (Exception ex)
            {
                return PartialView("_Welcome", CommonData.DisplayWelcome);
            }
        }

        [ChildActionOnly]
        public ActionResult Service()
        {
            try
            {
                return PartialView("_Service", _designRepository.DisplayService("Service"));
            }
            catch (Exception ex)
            {
                return PartialView("_Service", CommonData.DisplayService);
            }
        }

        [ChildActionOnly]
        public ActionResult HotMenu()
        {
            try
            {
                ViewBag.MenuHot = _hotMenuRepository.DisplayHotMenu();
                return PartialView("_HotMenu", _designRepository.DisplayHotMenu("HotMenu"));
            }
            catch (Exception ex)
            {
                ViewBag.MenuHot = CommonData.HotMenu;
                return PartialView("_HotMenu", CommonData.DisplayHotMenu);
            }
        }

        [ChildActionOnly]
        public ActionResult Menus()
        {
            try
            {
                ViewBag.Menu = _menuRepository.DisplayMenu();
                return PartialView("_Menu", _designRepository.DisplayMenu("Menu"));
            }
            catch (Exception ex)
            {
                ViewBag.Menu = CommonData.Menu;
                return PartialView("_Menu", CommonData.DisplayMenu);
            }
        }

        [ChildActionOnly]
        public ActionResult Image()
        {
            try
            {
                return PartialView("_Image", _designRepository.DisplayImage("Image"));
            }
            catch (Exception ex)
            {
                return PartialView("_Image", CommonData.DisplayImage);
            }
        }

        [ChildActionOnly]
        public ActionResult SynthesizeInfo()
        {
            try
            {
                return PartialView("_SynthesizeInfo", _designRepository.DisplaySynthesizeInfo("SynthesizeInfo"));
            }
            catch (Exception ex)
            {
                return PartialView("_SynthesizeInfo", CommonData.DisplaySynthesizeInfo);
            }
        }

        [ChildActionOnly]
        public ActionResult FoodCategory()
        {
            try
            {
                ViewBag.ImageFoodCategory = _designRepository.DisplayImageFoodCategory("FoodCategory");
                return PartialView("_FoodCategory", _foodCategoryRepository.DisplayFoodCategories());
            }
            catch (Exception ex)
            {
                ViewBag.ImageFoodCategory = CommonData.DisplayImageFoodCategory;
                return PartialView("_FoodCategory", CommonData.DisplayFoodCategory);
            }
        }

        private List<string> SaveImage(HttpPostedFileBase[] file)
        {
            List<string> listFileName = new List<string>();
            foreach (var item in file)
            {
                var name = Path.GetFileName(item.FileName);
                if (ImageExtensions.Contains(Path.GetExtension(name).ToUpperInvariant()))
                {
                    string path = Path.Combine(Server.MapPath("~/Areas/Admin/Libraries/images/"), name);
                    item.SaveAs(path);
                    listFileName.Add(item.FileName);
                }
            }
            return listFileName;
        }
    }
}