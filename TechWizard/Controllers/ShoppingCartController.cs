using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TechWizard.Business.ViewModels;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Models.ShoppingCartEntities;
using TechWizard.Data.Repositories.IRepositories;

namespace TechWizard.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IHardwareRepository _hardwareRepository;
        private readonly IMapper _mapper;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IHardwareRepository hardwareRepository, IMapper mapper)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _hardwareRepository = hardwareRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AddItemToCart(int productId)
        {
            string userId = User.Claims.FirstOrDefault().Value;
            var cart = await _shoppingCartRepository.GetMyCart(userId);
            cart.ActiveOrder = await _shoppingCartRepository.GetOrCreateActiveOrder(cart.Id, userId);

            if(!cart.ActiveOrder.AllItems.Any(x => x.ProductId == productId))
            {
                var productEntity = await _hardwareRepository.GetProductById(productId);

                var orderItem = new OrderItem()
                {
                    OrderId = cart.ActiveOrder.Id,
                    ProductId = productId,
                    Units = 1
                };
                orderItem.TotalPrice += productEntity.Price;
                cart.ActiveOrder.AllItems.Add(orderItem);

                await _shoppingCartRepository.AddNewShoppingEntity(orderItem);

                cart.ActiveOrder.TotalCharge += productEntity.Price;
                cart.ActiveOrder.AmountOfAllItems++;
            }
            else
            {
                foreach (var item in cart.ActiveOrder.AllItems)
                {
                    if(item.ProductId == productId)
                    {
                        item.TotalPrice += item.Product.Price;
                        item.Units += 1;
                        await _shoppingCartRepository.UpdateShoppingEntity(item);

                        cart.ActiveOrder.TotalCharge += item.Product.Price;
                        cart.ActiveOrder.AmountOfAllItems++;
                    }
                }
            }
            cart.ActiveOrder.AmountOfDiffernetItems = cart.ActiveOrder.AllItems.Count;

            await _shoppingCartRepository.UpdateShoppingEntity(cart.ActiveOrder);

            return RedirectToAction("ShoppingCartView");
        }


        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> ShoppingCartView()
        {
            string userId = User.Claims.FirstOrDefault().Value;
            var cart = await _shoppingCartRepository.GetMyCart(userId);
            cart.ActiveOrder = await _shoppingCartRepository.GetOrCreateActiveOrder(cart.Id, userId);

            return View(cart);
        }


        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AdjustItemUnits(int orderId, int productId, decimal itemPrice, bool flipper)
        {
            var order = await _shoppingCartRepository.GetActiveOrderById(orderId);
            var orderItem = order.AllItems.FirstOrDefault(x => x.OrderId == orderId && x.ProductId == productId);

            if(flipper)
            {
                orderItem.Units += 1;
                orderItem.TotalPrice += itemPrice;

                order.AmountOfAllItems += 1;
                order.TotalCharge += itemPrice;
            }
            else
            {
                if(orderItem.Units <= 1)
                {
                    await _shoppingCartRepository.RemoveShoppingEntity(orderItem);
                    order.AmountOfDiffernetItems -= 1;
                }
                else
                {
                    orderItem.Units -= 1;
                    orderItem.TotalPrice -= itemPrice;
                }
                order.TotalCharge -= itemPrice;
                order.AmountOfAllItems -= 1;
            }
            await _shoppingCartRepository.UpdateShoppingEntity(order);

            return RedirectToAction("ShoppingCartView");
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Payment(string userId, int orderId)
        {
           var shoppingViewModel = new ShoppingViewModel()
            {
                Customer = await _shoppingCartRepository.GetUser(userId),
                Order = await _shoppingCartRepository.GetActiveOrderById(orderId)
            };
            
            return View(shoppingViewModel);
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> OrderMade(ShoppingViewModel viewModel)
        {
            var orderDetails = _mapper.Map<OrderDetails>(viewModel);
            await _shoppingCartRepository.AddNewShoppingEntity(orderDetails);
            await _shoppingCartRepository.RemoveShoppingEntity(viewModel.Order);

            TempData["message"] = $"{orderDetails.FirstName}, your order has been made, you can track your deivery with order number '{orderDetails.OrderNumber}'" +
                $", expected delivery is between 3-5 working days.. ";

            return RedirectToAction("EndMessage");
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> EndMessage()
        {
            if (TempData["message"] != null)
            {
                var viewModel = new ShoppingViewModel()
                {
                    Message = TempData["message"].ToString()
                };
                return View(viewModel);
            }
            return RedirectToAction("ShoppingCartView");
        }
    }
}
