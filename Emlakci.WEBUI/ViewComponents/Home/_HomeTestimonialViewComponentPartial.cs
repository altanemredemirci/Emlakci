using Emlakci.BLL.Abstract;
using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Home
{
    public class _HomeTestimonialViewComponentPartial : ViewComponent
    {
        private readonly IClientService _clientService;

        public _HomeTestimonialViewComponentPartial(IClientService clientService)
        {
            _clientService = clientService;
        }

        public IViewComponentResult Invoke()
        {
            List<ResultClientModel> clientModels = new List<ResultClientModel>();
            foreach (var item in _clientService.GetAll())
            {
                clientModels.Add(new ResultClientModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Title = item.Title,
                    ImageUrl = item.ImageUrl,
                    Comment = item.Comment
                });
            } 
            return View(clientModels);
        }
    }
}