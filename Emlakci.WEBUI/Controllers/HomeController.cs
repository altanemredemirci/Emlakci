using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.ProductDTO;
using Emlakci.Entity;
using Emlakci.WEBUI.EmailServices;
using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Emlakci.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        //Injection
        public HomeController(ICategoryService categoryService,IProductService productService,IMapper mapper,IMailService mailService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _mailService = mailService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            ViewBag.ReadMore = "true";
            return View(_categoryService.GetAll());
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult ProductDetail(int id)
        {
            return View(id);
        }

        public IActionResult ProductList()
        {
            return View();
        }

        public IActionResult AgencyList()
        {
            return View();
        }

        public IActionResult AgencyDetail(int id)
        {
            return View(id);
        }

        public IActionResult SendMail(Mail mail)
        {
            string body = $"<h1>Ýletiþim Bilgileri</h1><br>Ad Soyad:{mail.Name}<br>Email:{mail.Email}<br>Konu:{mail.Subject}<br>Mesaj:{mail.Message}";
            bool result = MailHelper.SendMail(body, "altanemre1989@gmail.com", mail.Subject);
            if (result)
            {
                mail.IsRead = false;
                _mailService.Create(mail);
                TempData["MailSuccess"] = "true";
            }
            else
            {
                TempData["MailSuccess"] = "false";
            }

            return RedirectToAction("Contact");
        }
    }
}
