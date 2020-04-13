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
        private readonly IHotMenuRepository _hotMenuRepository;

        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };


        public HomeController(IUserRepository userRepository, IFeedBackRepository feedBackRepository, IDocumentRepository documentRepository, IDesignRepository designRepository, IHotMenuRepository hotMenuRepository)
        {
            _userRepository = userRepository;
            _feedBackRepository = feedBackRepository;
            _documentRepository = documentRepository;
            _designRepository = designRepository;
            _hotMenuRepository = hotMenuRepository;
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
                var model = _designRepository.DisplayBanner("Banner");
                return PartialView("_Banner", model);
            }
            catch (Exception ex)
            {
                return PartialView("_Banner", new DesignVM()
                {
                    Quote = "Welcome",
                    Title = "Chào mừng thực khách đến với nhà hàng",
                    Content = ""
                });
            }
        }

        [ChildActionOnly]
        public ActionResult Info()
        {
            try
            {
                var list = _designRepository.DisplayInfo("Info");
                return PartialView("_Info", list);
            }
            catch (Exception ex)
            {
                return PartialView("_Info", new List<DesignVM>()
                {
                    new DesignVM(){},
                    new DesignVM(){},
                    new DesignVM(){},
                });
            }
        }

        [ChildActionOnly]
        public ActionResult Welcome()
        {
            try
            {
                var ob = _designRepository.DisplayWelcome("Welcome");
                return PartialView("_Welcome", ob);

            }
            catch (Exception ex)
            {
                return PartialView("_Welcome", new DesignVM()
                {
                    Title = "Chào mừng thực khách đến với nhà hàng",
                    Content = "Để tránh tình trạng hết bàn/bàn view sông đẹp trong những dịp quan trọng, cuối tuần, lễ tết, Khiem-Baba đã tạo ra một hệ thống tự đặt bàn trực tuyến dành cho bạn. Chỉ cần điền số điện thoại là ngay lập tức bạn đã bàn không lo hết mà còn được cả vị trí view sông đẹp. Chưa hết đâu, bạn còn nhận được giảm 10% tổng bill khi đặt trực tuyến nữa. Còn chân chừ gì mà không gọi mấy đứa cạ cứng đến chiến và thưởng thức view sông Sài Gòn có một không hai?"
                });
            }
        }

        [ChildActionOnly]
        public ActionResult Service()
        {
            try
            {
                var list = _designRepository.DisplayService("Service");
                return PartialView("_Service", list);
            }
            catch (Exception ex)
            {
                return PartialView("_Service", new List<DesignVM>()
                {
                     new DesignVM()
                     {
                        Title = "Dịch vụ của chúng tôi",
                        Content = "Đến với nhà hàng, bạn sẽ được trải nghiệm dịch vụ tuyệt vời của chúng tôi"
                     },
                    new DesignVM()
                    {
                        Title = "Thực phẩm sạch",
                        Content = "Thực phẩm hoàn toàn từ tự nhiên, không chất bảo quản"
                    },
                    new DesignVM()
                    {
                        Title = "Ship đồ ăn nhanh",
                        Content = "Chúng tôi có một đội dân tổ riêng"
                    },
                    new DesignVM()
                    {
                        Title = "Hoạt động 24h / ngày",
                        Content = "Gọi cho chúng tôi ngay"
                    },
                });
            }
        }

        [ChildActionOnly]
        public ActionResult HotMenu()
        {
            try
            {
                var hot = _designRepository.DisplayHotMenu("HotMenu");
                ViewBag.MenuHot = _hotMenuRepository.DisplayHotMenu();
                return PartialView("_HotMenu", hot);
            }
            catch (Exception ex)
            {
                ViewBag.MenuHot = new HotMenuVM()
                {

                };
                return PartialView("_HotMenu", new DesignVM()
                {
                    Title = "Hot Menu",
                    Content = "Những món ăn được nhiều người ưa chuộng nhất"
                });
            }
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            try
            {
                var menu = _designRepository.DisplayHotMenu("Menu");
                return PartialView("_Menu", menu);
            }
            catch (Exception ex)
            {
                return PartialView("_Menu", new DesignVM()
                {
                    Title = "Menu",
                    Content = "Món ăn hấp dẫn của nhà hàng"
                });

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