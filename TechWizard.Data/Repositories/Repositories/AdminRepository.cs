using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Models.Many2ManyEntities;
using TechWizard.Data.Models.ShoppingCartEntities;
using TechWizard.Data.Repositories.IRepositories;

namespace TechWizard.Data.Repositories.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly WizardDbContext _dbContext;

        public AdminRepository(WizardDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> entities = await _dbContext.Products
                .Include(x => x.Brand)
                .Include(x => x.Type)
                .Include(x => x.Attributes)
                .ThenInclude(x => x.AttributeType)
                .ToListAsync();

            return entities;
        }

        public async Task<List<ProductType>> GetAllProductTypes()
        {
            List<ProductType> entities = await _dbContext.ProductTypes
                .Include(x => x.Attributes)
                .ToListAsync();

            return entities;
        }

        public async Task<List<Brand>> GetAllBrands()
        {
            List<Brand> entities = await _dbContext.Brands.OrderBy(x => x.Name).ToListAsync();

            return entities;
        }

        public async Task<List<AttributeType>> GetAllAttributeTypes()
        {
            List<AttributeType> entities = await _dbContext.AttributeTypes.ToListAsync();

            return entities;
        }

        public async Task<List<AttributeType>> GetAttributesByTypeId(int id)
        {
            var attNames = await _dbContext.ProductTypes_AttributeTypes
                .Include(x => x.AttributeType)
                .Where(x => x.ProductTypeId == id)
                .Select(x => x.AttributeType)
                .ToListAsync();

            return attNames;
        }

        public async Task<string> GetProductTypeById(int id)
        {
            var productName = await _dbContext.ProductTypes.FirstOrDefaultAsync(x => x.Id == id);

            return productName.Name;
        }

        public async Task<Product> GetProductById(int id)
        {
            var entity = await _dbContext.Products
                .Include(x => x.Type)
                .Include(x => x.Brand)
                .Include(x => x.Attributes)
                .ThenInclude(x => x.AttributeType)
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }

        public async Task Commit<T>(T product)
        {
            try
            {
                _dbContext.Add(product);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                await Task.FromException(ex);
            }
            
        }

        public async Task CommitMany(List<Product_AttributeType> productsAttributes)
        {
            try
            {
                _dbContext.AddRange(productsAttributes);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task Modify<T>(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<OrderDetails>> GetOrderDetails()
        {
            var orderDetails = await _dbContext.OrderDetails.OrderByDescending(x => x.DateCreated).ToListAsync();
            return orderDetails;
        }
    }
}
