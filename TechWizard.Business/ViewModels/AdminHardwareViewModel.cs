using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using TechWizard.Business.ViewModels.DTOs;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Models.ShoppingCartEntities;

namespace TechWizard.Business.ViewModels
{
    public class AdminHardwareViewModel
    {
  
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductType> Categories { get; set; }
        public List<Brand> Brands { get; set; }
        public string BrandName { get; set; }
        public List<AttributeType> Attributes { get; set; }
        public List<int> AttributeIDs { get; set; }
        public List<string> AttributeNames { get; set; }
        public List<string> AttributeValues { get; set; } = new List<string>();
        public HardwareCreationDTO NewGear { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public string ConfirmationMessage { get; set; }
        public IFormFile PictureForStream { get; set; }
        public string DefaultNoImage { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public bool isShoppingOperation { get; set; }
    }
}
