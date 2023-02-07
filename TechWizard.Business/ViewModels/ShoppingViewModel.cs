using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Models.ShoppingCartEntities;

namespace TechWizard.Business.ViewModels
{
    public class ShoppingViewModel
    {
        public WizardUser Customer { get; set; }
        public Order Order { get; set; }
        public string Message { get; set; }
    }
}
