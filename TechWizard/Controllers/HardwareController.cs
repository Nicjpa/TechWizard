using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechWizard.Business.Services.IServices;
using TechWizard.Business.ViewModels;
using TechWizard.Business.ViewModels.DTOs;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Repositories.IRepositories;

namespace TechWizard.Controllers
{
    public class HardwareController : Controller
    {
        private readonly IHardwareRepository _hardwareRepository;
        private readonly IMapper _mapper;
        private readonly IViewModelService _vmService;

        public HardwareController(IHardwareRepository hardwareRepository, IMapper mapper, IViewModelService vmService)
        {
            _hardwareRepository = hardwareRepository;
            _mapper = mapper;
            _vmService = vmService;
        }


        [HttpGet]
        public async Task<IActionResult> GetHardwareByFilters(int? id, List<string> cb, List<string> brands, decimal maxPrice = 2499, decimal minPrice = 1)
        {
            var hardwareViewModel = new PublicHardwareViewModel()
            {
                HardwareViewDTOs = await _vmService.GetAndMap(),
                CbKeys = await _vmService.GetAttributeTypeIds(cb),
                CbValues = await _vmService.GetAttributeValues(cb),
                AllBrandNames = await _hardwareRepository.GetAllBrands(id),
                MaxPrice = await _hardwareRepository.GetMaxPrice(),
                CheckedBrandNames = brands,
                FilteredMinPrice = minPrice,
                FilteredMaxPrice = maxPrice
            };

            if ((minPrice > 1 || maxPrice <= hardwareViewModel.MaxPrice) && (maxPrice != 0))
            {
                hardwareViewModel.HardwareViewDTOs = hardwareViewModel.HardwareViewDTOs
                    .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                    .ToList();
            }

            if (id.HasValue)
            {
                hardwareViewModel.FilterDTO = await _vmService.GetFilters(hardwareViewModel, id);
                hardwareViewModel.FilterCriteria = await _vmService.GetFilteredCriteria(hardwareViewModel);
                hardwareViewModel.HardwareViewDTOs = hardwareViewModel.HardwareViewDTOs.Where(x => x.TypeId == id).ToList();
            }
            
            if (cb.Count != 0)
            {
                hardwareViewModel.HardwareViewDTOs = hardwareViewModel.HardwareViewDTOs
                    .Where(x => hardwareViewModel.FilterCriteria.All(y => x.Attributes.Any(x => y.Contains(x.Item2))))
                    .ToList();
            }

            if(brands.Count != 0)
            {
                hardwareViewModel.HardwareViewDTOs = hardwareViewModel.HardwareViewDTOs
                    .Where(x => brands.Any(y => y.Contains(x.Brand))).ToList();
            }
            return View(hardwareViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> GetHardwareBySearch(string search)
        {
            var hardwareViewModel = new PublicHardwareViewModel()
            {
                HardwareViewDTOs = await _vmService.GetAndMap()
            };

            if (!string.IsNullOrEmpty(search))
            {
                hardwareViewModel.HardwareViewDTOs = hardwareViewModel.HardwareViewDTOs
                    .Where(x => x.Name.Trim().ToUpper().Contains(search.Trim().ToUpper()))
                    .ToList();

                TempData["search"] = search;
            }
            return View(hardwareViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> HardwareDetails(int id)
        {
            var hardware = await _hardwareRepository.GetProductById(id);
            var productViewDTO = _mapper.Map<ProductViewDTO>(hardware);
            return View(productViewDTO);
        }
    }
}
