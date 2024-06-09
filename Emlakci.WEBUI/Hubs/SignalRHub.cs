using Emlakci.BLL.Abstract;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlakci.WEBUI.Hubs
{
    public class SignalRHub: Hub
    {
        private readonly IStatisticService _statisticService;
        private readonly ITodoListService _todoListService;

        public SignalRHub(IStatisticService statisticService, ITodoListService todoListService)
        {
            _statisticService = statisticService;
            _todoListService = todoListService;
        }

        public async Task SendTodoList()
        {
            var todoLists = _todoListService.GetAll();

            await Clients.All.SendAsync("ReceiveTodoList", todoLists);
        }

        public async Task SendCategory()
        {
            var categoryCount = _statisticService.CategoryCount();

            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);
        }

    }
}
