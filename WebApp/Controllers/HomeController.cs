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
        private IUserRepository _userRepository;
        private readonly IFeedBackRepository _feedBackRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IDesignRepository _designRepository;
        private readonly IHotMenuRepository _hotMenuRepository;
        private readonly IMenuRepository _menuRepository;
        private static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG", ".JFIF", ".RAW", ".JPEG" };

        public HomeController(IUserRepository userRepository, 
            IFeedBackRepository feedBackRepository, 
            IDocumentRepository documentRepository, 
            IDesignRepository designRepository, 
            IHotMenuRepository hotMenuRepository,
            IMenuRepository menuRepository)
        {
            _userRepository = userRepository;
            _feedBackRepository = feedBackRepository;
            _documentRepository = documentRepository;
            _designRepository = designRepository;
            _hotMenuRepository = hotMenuRepository;
            _menuRepository = menuRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult Banner()
        {
            try
            {
                return PartialView("_Banner", _designRepository.DisplayBanner("Banner"));
            }
            catch (Exception ex)
            {
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
        public ActionResult Menu()
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
                return PartialView("_FoodCategory");
            }
            catch (Exception ex)
            {
                return PartialView("_FoodCategory");

            }
        }

        [ChildActionOnly]
        public ActionResult Blog()
        {
            try
            {
                return PartialView("_Blog");
            }
            catch (Exception ex)
            {
                return PartialView("_Blog");

            }
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string customerName, string phone, string title, string message, HttpPostedFileBase[] file)
        {
            try
            {
                var feebBackVM = new FeedBackVM()
                {
                    CustomerName = customerName,
                    Message = message,
                    Phone = phone,
                    Title = title
                };

                var id = _feedBackRepository.Create(feebBackVM);
                if (file != null)
                {
                    var listFileName = SaveImage(file);
                    _documentRepository.CreateForFeedBack(listFileName, id);
                }
                return View();
            }
            catch (Exception ex)
            {
                return View();
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