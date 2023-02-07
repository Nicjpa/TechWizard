using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Data.Models.Entities;

namespace TechWizard.Data.Models.ShoppingCartEntities
{
    public class Order
    {
        public int Id { get; set; }
        public string ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public string CustomerId { get; set; }
        public WizardUser Customer { get; set; }
        public List<OrderItem> AllItems { get; set; } = new List<OrderItem>();
        public int AmountOfDiffernetItems { get; set; }
        public int AmountOfAllItems { get; set; } = 0;
        public decimal TotalCharge { get; set; } = 0;
        public bool IsActive { get; set; } = true;
    }
}
