using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Data.Models.Entities;

namespace TechWizard.Data.Models.ShoppingCartEntities
{
    public class ShoppingCart
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public WizardUser Customer { get; set; }
        public Order ActiveOrder { get; set; }
    }
}
