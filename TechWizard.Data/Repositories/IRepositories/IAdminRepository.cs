using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Models.Many2ManyEntities;
using TechWizard.Data.Models.ShoppingCartEntities;

namespace TechWizard.Data.Repositories.IRepositories
{
    public interface IAdminRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<List<ProductType>> GetAllProductTypes();
        Task<List<Brand>> GetAllBrands();
        Task<List<AttributeType>> GetAllAttributeTypes();
        Task<List<AttributeType>> GetAttributesByTypeId(int id);
        Task<string> GetProductTypeById(int id);
        Task Commit<T>(T product);
        Task CommitMany(List<Product_AttributeType> product);
        Task<Product> GetProductById(int id);
        Task Modify<T>(T entity);
        Task<List<OrderDetails>> GetOrderDetails();

    }
}
