using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Data.Models.Entities;

namespace TechWizard.Data.Models.Many2ManyEntities
{
    public class ProductType_AttributeType
    {
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public int AttributeTypeId { get; set; }
        public AttributeType AttributeType { get; set; }
    }
}
