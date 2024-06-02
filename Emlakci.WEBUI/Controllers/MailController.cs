using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.MailDTO;
using Emlakci.Entity;
using Emlakci.WEBUI.EmailServices;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.Controllers
{
    public class MailController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;

        public MailController(IMailService mailService, IMapper mapper)
        {
            _mailService = mailService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var mails = _mailService.GetAll();

            return View(_mapper.Map<List<ResultMailDTO>>(mails));
        }

        public IActionResult StatusChange(int id)
        {
            var mail = _mailService.GetById(id);

            //mail.IsRead = mail.IsRead == false ? true : false;

            mail.IsRead = !mail.IsRead;

            _mailService.Update(mail);
            return RedirectToAction("Index");
        }
        public IActionResult ReplyMail(Mail mail)
        {
            string body = $"<h3>Merhaba {mail.Name};</h3><br><h5>{mail.Subject} konusunda cevabımız aşağıdadır.</h5><br>{mail.Message}";
            bool result = MailHelper.SendMail(body, mail.Email, mail.Subject);
            if (result)
            {
                var email = _mailService.GetById(mail.Id);
                email.IsReply = true;
                _mailService.Update(email);
            }

            return RedirectToAction("Index");
        } 
    }
}
