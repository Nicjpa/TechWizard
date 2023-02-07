using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechWizard.Data.Models.ShoppingCartEntities
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = Guid.NewGuid().ToString().ToUpper();
        public int NumOfDifferntProducts { get; set; }
        public int TotalNumOfProducts { get; set; }
        public decimal TotalCharge { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
