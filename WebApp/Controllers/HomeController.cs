using Repositories.Interfaces;
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
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };


        public HomeController(IUserRepository userRepository, IFeedBackRepository feedBackRepository, IDocumentRepository documentRepository, IDesignRepository designRepository)
        {
            _userRepository = userRepository;
            _feedBackRepository = feedBackRepository;
            _documentRepository = documentRepository;
            _designRepository = designRepository;
        }

        public ActionResult Index()
        {
            //var list =  _userRepository.List();
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
                var model = _designRepository.DisplayBanner("Banner");
                return PartialView("_Banner", model);
            }
            catch (Exception ex)
            {
                return PartialView("_Banner", new DesignVM());
            }
        }

        [ChildActionOnly]
        public ActionResult Info()
        {
            try
            {
                return PartialView("_Info");
            }
            catch (Exception ex)
            {
                return PartialView("_Info");
            }
        }

        [ChildActionOnly]
        public ActionResult Welcome()
        {
            try
            {
                return PartialView("_Welcome");
            }
            catch (Exception ex)
            {
                return PartialView("_Welcome");
            }
        }

        [ChildActionOnly]
        public ActionResult Service()
        {
            try
            {
                return PartialView("_Service");
            }
            catch (Exception ex)
            {
                return PartialView("_Service");
            }
        }


        [ChildActionOnly]
        public ActionResult HotMenu()
        {
            try
            {
                return PartialView("_HotMenu");
            }
            catch (Exception ex)
            {
                return PartialView("_HotMenu");
            }
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            try
            {
                return PartialView("_Menu");
            }
            catch (Exception ex)
            {
                return PartialView("_Menu");

            }
        }

        [ChildActionOnly]
        public ActionResult Image()
        {
            try
            {
                return PartialView("_Image");
            }
            catch (Exception ex)
            {
                return PartialView("_Image");

            }
        }


        [ChildActionOnly]
        public ActionResult SynthesizeInfo()
        {
            try
            {
                return PartialView("_SynthesizeInfo");
            }
            catch (Exception ex)
            {
                return PartialView("_SynthesizeInfo");

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