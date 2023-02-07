using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Repositories.IRepositories;

namespace TechWizard.Data.Repositories.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly WizardDbContext _dbContext;
        public CategoryRepository(WizardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductType>> GearTypes()
        {
            var gear = await _dbContext.ProductTypes
                .OrderBy(x => x.Id)
                .ToListAsync();

            return gear;
        }
    }
}
