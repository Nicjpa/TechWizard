using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Models.Many2ManyEntities;

namespace TechWizard.Data.Repositories.IRepositories
{
    public interface IHardwareRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetFilterTypes(int id);
        Task<List<string>> GetAllBrands(int? Id);
        Task<decimal?> GetMaxPrice();
    }
}
