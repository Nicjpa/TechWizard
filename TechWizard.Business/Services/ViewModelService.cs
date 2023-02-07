using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Business.Services.IServices;
using TechWizard.Business.ViewModels;
using TechWizard.Business.ViewModels.DTOs;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Models.Many2ManyEntities;
using TechWizard.Data.Repositories.IRepositories;

namespace TechWizard.Business.Services
{
    public class ViewModelService : IViewModelService
    {
        private readonly IHardwareRepository _hardwareRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public ViewModelService(IHardwareRepository hardwareRepository, IAdminRepository adminRepository , IFileService fileService, IMapper mapper)
        {
            _hardwareRepository = hardwareRepository;
            _adminRepository = adminRepository;
            _fileService = fileService;
            _mapper = mapper;
        }

        public async Task<List<ProductViewDTO>> GetAndMap()
        {
            var allHardware = await _hardwareRepository.GetAllProducts();
            var hardwareViewDTO = _mapper.Map<List<ProductViewDTO>>(allHardware);
            return hardwareViewDTO;
        }

        public async Task<FilterDTO> GetFilters(PublicHardwareViewModel viewModel, int? id)
        {
            var filters = await _hardwareRepository.GetFilterTypes(id.Value);
            var vm = _mapper.Map(filters, viewModel);
            return vm.FilterDTO;
        }

        public async Task<List<int>> GetAttributeTypeIds(List<string> values)
        {
            var keyList = new List<int>();

            var keysValues = await DestructureCheckboxValues(values);
            keysValues.ForEach(x => keyList.Add(x.Item1));
            return keyList;
        }

        public async Task<List<string>> GetAttributeValues(List<string> values)
        {
            var valueList = new List<string>();

            var keysValues = await DestructureCheckboxValues(values);
            keysValues.ForEach(x => valueList.Add(x.Item2));

            return valueList;
        }

        private async Task<List<(int, string)>> DestructureCheckboxValues(List<string> KeyValuesStr)
        {
            var destructuredValues = new List<(int, string)>();

            foreach(string value in KeyValuesStr)
            {
                string[] keyValue = value.Split('-');
                int.TryParse(keyValue[0], out int key);
                destructuredValues.Add((key, keyValue[1]));
            }
            return destructuredValues;
        }

        public async Task<List<List<string>>> GetFilteredCriteria(PublicHardwareViewModel viewModel)
        {
            var filteredCriteria = new List<List<string>>();

            foreach (var filterCategory in viewModel.FilterDTO.AttIdAttName)
            {
                var categoryType = new List<string>();

                for (int i = 0; i < viewModel.CbKeys.Count; i++)
                {
                    if (viewModel.CbKeys[i] == filterCategory.Item1)
                    {
                        categoryType.Add(viewModel.CbValues[i]);
                    }
                }
                if (categoryType.Count != 0)
                {
                    filteredCriteria.Add(categoryType);
                }
            }
            return filteredCriteria;
        }
        public async Task<Product> MapNewGear(AdminHardwareViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel.NewGear);
            if (viewModel.NewGear.Picture != null)
                entity.Picture = await GetPictureAddress(viewModel.NewGear.Picture);
            else
                entity.Picture = viewModel.DefaultNoImage;
            entity.TypeId = viewModel.ProductTypeId;
            entity.BrandId = viewModel.Brands
                .Where(x => x.Name == viewModel.NewGear.BrandName)
                .Select(x => x.Id)
                .FirstOrDefault();

            return entity;
        }

        private async Task<string> GetPictureAddress(IFormFile picture)
        {
            string picturePath = "";

            if (picture != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await picture.CopyToAsync(memoryStream);
                    var content = memoryStream.ToArray();
                    var extension = Path.GetExtension(picture.FileName);
                    picturePath = await _fileService.SaveFile(content, extension, "images");
                }
            }
            return picturePath;
        }

        public async Task<string> GetNewPictureAddress(IFormFile picture, string oldPicturePath)
        {
            string picturePath = "";
            using (var memoryStream = new MemoryStream())
            {
                await picture.CopyToAsync(memoryStream);
                var content = memoryStream.ToArray();
                var extension = Path.GetExtension(picture.FileName);
                picturePath = await _fileService.EditFile(content, extension, "images", oldPicturePath);
            }
            return picturePath;
        }

        public async Task<List<Product_AttributeType>> BindProductsAttributes(AdminHardwareViewModel viewModel, int productId)
        {
            var productsAttributes = new List<Product_AttributeType>();

            for(int i = 0; i < viewModel.AttributeValues.Count; i++)
            {
                productsAttributes.Add(new Product_AttributeType()
                {
                    ProductId = productId,
                    AttributeTypeId = viewModel.AttributeIDs[i],
                    Value = viewModel.AttributeValues[i]
                });
            }

            return productsAttributes;
        }

        public async Task ModifyProductAttributes(AdminHardwareViewModel viewModel)
        {
            for(int i = 0; i < viewModel.AttributeValues.Count; i++)
            {
                var attribute = new Product_AttributeType() 
                { 
                    ProductId = viewModel.Product.Id,
                    AttributeTypeId = viewModel.AttributeIDs[i],
                    Value = viewModel.AttributeValues[i],
                };

                await _adminRepository.Modify(attribute);
            }
        }
    }
}
