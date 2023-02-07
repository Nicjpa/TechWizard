using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechWizard.Business.Services.IServices;
using TechWizard.Business.ViewModels;
using TechWizard.Data;
using TechWizard.Data.Repositories.IRepositories;

namespace TechWizard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHardwareRepository _hardwareRepository;
        private readonly IMapper _mapper;
        private readonly IViewModelService _vmService;

        public HomeController(IHardwareRepository hardwareRepository, IMapper mapper, IViewModelService vmService)
        {
            _hardwareRepository = hardwareRepository;
            _mapper = mapper;
            _vmService = vmService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new PublicHardwareViewModel()
            {
                HardwareViewDTOs = await _vmService.GetAndMap()
            };
            viewModel.HardwareViewDTOs = viewModel.HardwareViewDTOs
                .Where(x => x.OnPromotion)
                .ToList();

            return View(viewModel);
        }
    }
}
