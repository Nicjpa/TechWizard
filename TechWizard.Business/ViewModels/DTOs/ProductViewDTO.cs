using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechWizard.Business.ViewModels.DTOs
{
    public class ProductViewDTO
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public int TypeId { get; set; }
        public string ProductType { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public List<(string, string)> Attributes { get; set; }
        public bool OnPromotion { get; set; }
    }
}
