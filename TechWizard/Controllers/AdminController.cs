using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TechWizard.Business.Services.IServices;
using TechWizard.Business.ViewModels;
using TechWizard.Business.ViewModels.DTOs;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Models.Many2ManyEntities;
using TechWizard.Data.Repositories.IRepositories;


namespace TechWizard.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IViewModelService _viewModelService;

        public AdminController(IAdminRepository adminRepository, IViewModelService viewModelService)
        {
            _adminRepository = adminRepository;
            _viewModelService = viewModelService;
        }

        public async Task<IActionResult> Overview(bool isShoppingOperation)
        {
            var viewModel = new AdminHardwareViewModel()
            {
                Products = await _adminRepository.GetAllProducts(),
                Categories = await _adminRepository.GetAllProductTypes(),
                Brands = await _adminRepository.GetAllBrands(),
                Attributes = await _adminRepository.GetAllAttributeTypes(),
                OrderDetails = await _adminRepository.GetOrderDetails(),
                isShoppingOperation = isShoppingOperation
            };

            if (TempData["operation"] != null)
            {
                if (TempData["operation"].ToString() == "Create")
                    viewModel.ConfirmationMessage = $"NEW {TempData["productType"]} '{TempData["productName"]}' has been CREATED.";

                else if (TempData["operation"].ToString() == "Update")
                    viewModel.ConfirmationMessage = $"{TempData["productType"]} '{TempData["productName"]}' has been UPDATED.";
            }
            else if (TempData["brandName"] != null)
            {
                viewModel.ConfirmationMessage = $"NEW Brand '{TempData["brandName"]}' has been CREATED.";
            }

            return View(viewModel);
        }


        // CREATE
        public async Task<IActionResult> CreateProduct(int productTypeid)
        {
            var viewModel = new AdminHardwareViewModel()
            {
                Brands = await _adminRepository.GetAllBrands(),
                Attributes = await _adminRepository.GetAttributesByTypeId(productTypeid),
                ProductTypeName = await _adminRepository.GetProductTypeById(productTypeid),
                ProductTypeId = productTypeid,
                DefaultNoImage = "/images/NO_IMAGE500x500.png"
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(AdminHardwareViewModel viewModel)
        {
            viewModel.Brands = await _adminRepository.GetAllBrands();
            viewModel.Attributes = await _adminRepository.GetAttributesByTypeId(viewModel.ProductTypeId);
            viewModel.ProductTypeName = await _adminRepository.GetProductTypeById(viewModel.ProductTypeId);

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var productEntity = await _viewModelService.MapNewGear(viewModel);
            await _adminRepository.Commit(productEntity);

            var productsAttributes = await _viewModelService.BindProductsAttributes(viewModel, productEntity.Id);
            await _adminRepository.CommitMany(productsAttributes);

            TempData["productType"] = viewModel.ProductTypeName;
            TempData["productName"] = viewModel.NewGear.Name;
            TempData["operation"] = "Create";

            return RedirectToAction("Overview");
        }


        // UPDATE
        public async Task<IActionResult> UpdateProduct(string productTypeName, int productId)
        {
            var viewModel = new AdminHardwareViewModel()
            {
                Brands = await _adminRepository.GetAllBrands(),
                Product = await _adminRepository.GetProductById(productId),
                ProductTypeName = productTypeName
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(AdminHardwareViewModel viewModel)
        {
            viewModel.Brands = await _adminRepository.GetAllBrands();

            if (!ModelState.IsValid)
            {
                viewModel.Product.Attributes = new List<Product_AttributeType>();
                for (int i = 0; i < viewModel.AttributeValues.Count; i++)
                {
                    viewModel.Product.Attributes.Add(new Product_AttributeType()
                    {
                        ProductId = viewModel.Product.Id,
                        AttributeTypeId = viewModel.AttributeIDs[i],
                        Value = viewModel.AttributeValues[i],
                        AttributeType = new AttributeType() { Id = i , Name = viewModel.AttributeNames[i] }
                    });
                }
                return View(viewModel);
            }

            if (viewModel.PictureForStream != null)
            {
                viewModel.Product.Picture = await _viewModelService.GetNewPictureAddress(viewModel.PictureForStream, viewModel.Product.Picture);
            }

            await _adminRepository.Modify(viewModel.Product);
            await _viewModelService.ModifyProductAttributes(viewModel);

            TempData["productType"] = viewModel.ProductTypeName;
            TempData["productName"] = viewModel.Product.Name;
            TempData["operation"] = "Update";

            return RedirectToAction("Overview");
        }

        public async Task<IActionResult> AddNewBrand()
        {
            var viewModel = new AdminHardwareViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBrand(AdminHardwareViewModel viewModel)
        {
            var brand = new Brand()
            {
                Name = viewModel.BrandName.ToUpper()
            };

            await _adminRepository.Commit(brand);
            TempData["brandName"] = brand.Name;

            return RedirectToAction("Overview");
        }
    }
}
