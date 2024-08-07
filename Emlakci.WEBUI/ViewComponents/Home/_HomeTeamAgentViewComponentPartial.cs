﻿using AutoMapper;
using Emlakci.BLL.Abstract;
using Emlakci.BLL.DTOs.AgencyDTO;
using Emlakci.WEBUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emlakci.WEBUI.ViewComponents.Home
{
    public class _HomeTeamAgentViewComponentPartial : ViewComponent
    {
        private readonly IAgencyService _agencyService;
        private readonly IMapper _mapper;

        public _HomeTeamAgentViewComponentPartial(IAgencyService agencyService,IMapper mapper)
        {
            _agencyService = agencyService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            return View(_mapper.Map<List<ResultAgencyDTO>>(_agencyService.GetAll()));
        }
    }
}