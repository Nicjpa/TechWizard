using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Data.Models.Entities;

namespace TechWizard.Data.Models.ShoppingCartEntities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Units { get; set; } = 0;
        public decimal TotalPrice { get; set; } = 0;
    }
}
