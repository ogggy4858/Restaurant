using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class DesignCategoryVM
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<DesignVM> Designs { get; set; }
    }
}
