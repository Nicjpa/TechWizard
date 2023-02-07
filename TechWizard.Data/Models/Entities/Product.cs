using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using TechWizard.Data.Models.Many2ManyEntities;

namespace TechWizard.Data.Models.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductCode { get; set; } = Guid.NewGuid().ToString().Substring(0,18).ToUpper();
        [Required]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        [Required(ErrorMessage = "Every product must have name."), MaxLength(60)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Every product must have a price."), Range(0.01, 100000)]
        public decimal Price { get; set; }
        
        public string Picture { get; set; }
        [Required]
        public int TypeId { get; set; }
        public ProductType Type { get; set; }
        public List<Product_AttributeType> Attributes { get; set; }
        public bool OnPromotion { get; set; }
        public bool IsVisible { get; set; }
        [Required(ErrorMessage = "Product quantity must be declared, if none, enter '0'.")]
        public int? Quantity { get; set; }

    }
}
