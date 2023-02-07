using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechWizard.Data.Models.Entities
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(30, ErrorMessage = "Brand cannot be nameless")]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
