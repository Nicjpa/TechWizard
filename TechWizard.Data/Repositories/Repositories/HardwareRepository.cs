using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Models.Many2ManyEntities;
using TechWizard.Data.Repositories.IRepositories;

namespace TechWizard.Data.Repositories.Repositories
{
    public class HardwareRepository : IHardwareRepository
    {
        private readonly WizardDbContext _dbContext;

        public HardwareRepository(WizardDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> allHardware = await _dbContext.Products
                .Include(x => x.Brand)
                .Include(x => x.Type)
                .Include(x => x.Attributes)
                .ThenInclude(x => x.AttributeType)
                .Where(x => x.Quantity > 0 && x.IsVisible)
                .ToListAsync();

            return allHardware;
        }

        public async Task<Product> GetProductById(int id)
        {
            Product hardware = await _dbContext.Products
                .Include(x => x.Brand)
                .Include(x => x.Type)
                .Include(x => x.Attributes)
                .ThenInclude(x => x.AttributeType)
                .FirstOrDefaultAsync(x => x.Id == id);

            return hardware;
        }

        public async Task<List<Product>> GetFilterTypes(int id)
        {
            var filters = await _dbContext.Products
                .Include(x => x.Attributes)
                .ThenInclude(x => x.AttributeType)
                .Where(x => x.TypeId == id && x.Quantity > 0 && x.IsVisible)
                .ToListAsync();


            return filters;
        }

        public async Task<List<string>> GetAllBrands(int? id)
        {
            List<string> brandNames;
            if (id != null)
            {
                brandNames = await _dbContext.Brands
                .Include(x => x.Products)
                .Where(x => x.Products.Any(x => x.TypeId == id && x.Quantity > 0 && x.IsVisible))
                .Select(x => x.Name)
                .OrderBy(x => x)
                .ToListAsync();
            }
            else
            {
                brandNames = await _dbContext.Brands
                .Select(x => x.Name)
                .OrderBy(x => x)
                .ToListAsync();
            }
            return brandNames;
        }

        public async Task<decimal?> GetMaxPrice()
        {
            decimal? highestPrice = await _dbContext.Products.MaxAsync(x => x.Price);
            return highestPrice;
        }
    }
}
