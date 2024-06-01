using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.MailDTO;
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
    }
}
