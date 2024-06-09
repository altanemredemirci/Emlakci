using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.TodoListDTO;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Dashboard
{
    public class _DashboardTodoListViewComponentPartial:ViewComponent
    {
        private readonly ITodoListService _todoListService;
        private readonly IMapper _mapper;
        public _DashboardTodoListViewComponentPartial(ITodoListService todoListService,IMapper mapper)
        {
            _todoListService = todoListService;
            _mapper=mapper;
        }

        public IViewComponentResult Invoke()
        {
            //var model = _todoListService.GetAll();

            //return View(_mapper.Map<List<ResultTodoListDTO>>(model));

            return View();
        }
    }
}
