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

        public HomeController(IUserRepository userRepository, IFeedBackRepository feedBackRepository, IDocumentRepository documentRepository)
        {
            _userRepository = userRepository;
            _feedBackRepository = feedBackRepository;
            _documentRepository = documentRepository;
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
                string path = Path.Combine(Server.MapPath("~/Areas/Admin/Libraries/images/"), name);
                item.SaveAs(path);
                listFileName.Add(item.FileName);
            }
            return listFileName;
        }
    }
}