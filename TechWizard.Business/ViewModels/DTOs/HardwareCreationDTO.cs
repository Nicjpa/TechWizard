using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechWizard.Business.ViewModels.DTOs
{
    public class HardwareCreationDTO
    {
        [Required]
        public string BrandName { get; set; }
        [Required(ErrorMessage = "Every product must have a name."), MaxLength(60)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Every product must have a price."), Range(0.01, 100000)]
        public decimal? Price { get; set; }
        public IFormFile Picture { get; set; }
        [Required]
        public bool OnPromotion { get; set; }
        [Required]
        public bool IsVisible { get; set; }
        [Required(ErrorMessage = "Product quantity must be declared, if none, enter '0'.")]
        public int? Quantity { get; set; }
        public string ProductType { get; set; }

    }
}
