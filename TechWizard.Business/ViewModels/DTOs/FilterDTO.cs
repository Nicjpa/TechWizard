using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechWizard.Business.ViewModels.DTOs
{
    public class FilterDTO
    {
        public List<(int, string)> AttIdAttName { get; set; }
        public List<(int, string)> AttIdValue { get; set; }
    }
}
