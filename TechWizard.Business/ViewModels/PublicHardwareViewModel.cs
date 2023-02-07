using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Business.ViewModels.DTOs;
using TechWizard.Data.Models.Entities;

namespace TechWizard.Business.ViewModels
{
    public class PublicHardwareViewModel
    {
        public List<ProductViewDTO> HardwareViewDTOs { get; set; }
        public FilterDTO FilterDTO { get; set; }
        public List<int> CbKeys { get; set; }
        public List<string> CbValues { get; set; }
        public List<List<string>> FilterCriteria { get; set; }
        public List<string> AllBrandNames { get; set; }
        public List<string> CheckedBrandNames { get; set; }
        public List<ProductType> ProductTypes { get; set; }
        public decimal? MaxPrice { get; set; }
        public decimal FilteredMinPrice { get; set; }
        public decimal FilteredMaxPrice { get; set; }
        public bool isFromCart { get; set; }
    }
}
