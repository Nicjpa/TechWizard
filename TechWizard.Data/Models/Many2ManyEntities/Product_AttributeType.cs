using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechWizard.Data.Models.Entities;

namespace TechWizard.Data.Models.Many2ManyEntities
{
    public class Product_AttributeType
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int AttributeTypeId { get; set; }
        public AttributeType AttributeType { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
