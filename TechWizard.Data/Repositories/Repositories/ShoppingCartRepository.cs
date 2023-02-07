using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Models.ShoppingCartEntities;
using TechWizard.Data.Repositories.IRepositories;

namespace TechWizard.Data.Repositories.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly WizardDbContext _dbContext;

        public ShoppingCartRepository(WizardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ShoppingCart> GetMyCart(string userId)
        {
            var cart = await _dbContext.ShoppingCarts.FirstOrDefaultAsync(x => x.CustomerId == userId);
            return cart;
        }

        public async Task<Order> GetOrCreateActiveOrder(string shoppingCartId, string userId)
        {
            var activeOrder = await _dbContext.Orders
                .Include(x => x.AllItems)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.IsActive && x.ShoppingCartId == shoppingCartId);

            if (activeOrder == null)
            {
                var newActiveOrder = new Order()
                {
                    ShoppingCartId = shoppingCartId,
                    CustomerId = userId
                };

                await AddNewShoppingEntity(newActiveOrder);

                return newActiveOrder;
            }

            return activeOrder;
        }

        public async Task AddNewShoppingEntity<T>(T shoppingEntity)
        {
            try
            {
                _dbContext.Add(shoppingEntity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task UpdateShoppingEntity<T>(T shoppingEntity)
        {
            try
            {
                _dbContext.Entry(shoppingEntity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Order> GetActiveOrderById(int orderId)
        {
            var order = await _dbContext.Orders
                .Include(x => x.AllItems)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Type)
                .FirstOrDefaultAsync(x => x.Id == orderId);

            return order;
        }

        public async Task RemoveShoppingEntity<T>(T shoppingEntity)
        {
            try
            {
                _dbContext.Remove(shoppingEntity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<WizardUser> GetUser(string userId)
        {
            var wizard = await _dbContext.WizardUsers.FirstOrDefaultAsync(x => x.Id == userId);
            return wizard;
        }
    }
}
