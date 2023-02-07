using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Business.ViewModels;
using TechWizard.Business.ViewModels.DTOs;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Models.Many2ManyEntities;

namespace TechWizard.Business.Services.IServices
{
    public interface IViewModelService
    {
        Task<List<ProductViewDTO>> GetAndMap();
        Task<List<int>> GetAttributeTypeIds(List<string> values);
        Task<List<string>> GetAttributeValues(List<string> values);
        Task<FilterDTO> GetFilters(PublicHardwareViewModel viewModel, int? id);
        Task<List<List<string>>> GetFilteredCriteria(PublicHardwareViewModel viewModel);
        Task<Product> MapNewGear(AdminHardwareViewModel viewModel);
        Task<List<Product_AttributeType>> BindProductsAttributes(AdminHardwareViewModel viewModel, int productId);
        Task<string> GetNewPictureAddress(IFormFile picture, string oldPicturePath);
        Task ModifyProductAttributes(AdminHardwareViewModel viewModel);
    }
}
