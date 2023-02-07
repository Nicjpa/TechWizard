using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Data.Models.Many2ManyEntities;

namespace TechWizard.Data.Models.Entities
{
    public class AttributeType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<ProductType_AttributeType> ProductTypes { get; set; }
        public List<Product_AttributeType> Products { get; set; }
    }
}
