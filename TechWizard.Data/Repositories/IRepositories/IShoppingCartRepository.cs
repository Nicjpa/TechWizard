using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Models.ShoppingCartEntities;

namespace TechWizard.Data.Repositories.IRepositories
{
    public interface IShoppingCartRepository
    {
        Task AddNewShoppingEntity<T>(T shoppingEntity);
        Task UpdateShoppingEntity<T>(T shoppingEntity);
        Task RemoveShoppingEntity<T>(T shoppingEntity);
        Task<ShoppingCart> GetMyCart(string userId);
        Task<Order> GetOrCreateActiveOrder(string shoppingCartId, string userId);
        Task<Order> GetActiveOrderById(int orderId);
        Task<WizardUser> GetUser(string userId);
    }
}
