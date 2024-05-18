using Emlakci.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Contact
{
    public class _ContactStartViewComponentPartial:ViewComponent
    {
        private readonly IContactService _contactService;

        public _ContactStartViewComponentPartial(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            return View(_contactService.GetContact());
        }
    }
}
