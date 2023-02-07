using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechWizard.Data;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Repositories.IRepositories;

namespace TechWizard.Components
{
    public class Categories : ViewComponent
    {
        private readonly ICategoryRepository _gearRepository;

        public Categories(ICategoryRepository gearRepository)
        {
            _gearRepository = gearRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var gears = await _gearRepository.GearTypes();
            return View(gears);
        }
    }
}
