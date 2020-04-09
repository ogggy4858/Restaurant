using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    public class InterfaceManagerController : Controller
    {
        private readonly IDesignRepository _designRepository;
        private readonly IDocumentRepository _documentRepository;
        private static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG", ".JFIF" };

        public InterfaceManagerController(IDesignRepository designRepository, IDocumentRepository documentRepository)
        {
            _designRepository = designRepository;
            _documentRepository = documentRepository;
        }

        // GET: Admin/InterfaceManager
        public ActionResult Banner()
        {
            var list = _designRepository.GetList("Banner");
            return View(list);
        }

        [HttpGet]
        public ActionResult BannerCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BannerCreate(DesignVM model, HttpPostedFileBase image)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Quote))
                {
                    ModelState.AddModelError("", "Welcome không được để trống");
                    return View(model);
                }

                if (string.IsNullOrEmpty(model.Title))
                {
                    ModelState.AddModelError("", "Tiêu đề không được để trống");
                    return View(model);
                }

                if (string.IsNullOrEmpty(model.Content))
                {
                    ModelState.AddModelError("", "Nội dung không được để trống");
                    return View(model);
                }

                if (image == null)
                {
                    ModelState.AddModelError("", "Hình ảnh không được để trống");
                    return View(model);
                }

                if (model.Quote.Length > 50)
                {
                    ModelState.AddModelError("", "Welcome không được quá 50 ký tự");
                    return View(model);
                }

                if (model.Title.Length > 50)
                {
                    ModelState.AddModelError("", "Tiêu đề không được quá 200 ký tự");
                    return View(model);
                }

                var bannerId = _designRepository.Create(model, "Banner");
                string fileName = SaveImage(image);
                _documentRepository.CreateForDesign(fileName, bannerId);
                return RedirectToAction("Banner");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi sảy ra, Vui lòng thử lại sau");
                return View(model);
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

        private string SaveImage(HttpPostedFileBase file)
        {
            var name = Path.GetFileName(file.FileName);
            if (ImageExtensions.Contains(Path.GetExtension(name).ToUpperInvariant()))
            {
                string path = Path.Combine(Server.MapPath("~/Areas/Admin/Libraries/images/"), name);
                file.SaveAs(path);
            }
            return file.FileName;
        }
    }
}