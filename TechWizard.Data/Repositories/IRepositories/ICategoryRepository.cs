using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Data.Models.Entities;

namespace TechWizard.Data.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        Task<List<ProductType>> GearTypes();
    }
}
