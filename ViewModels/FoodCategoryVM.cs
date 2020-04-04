using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class FoodCategoryVM
    {
        public long Id { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }
        public bool Status { get; set; }
        
        public ICollection<FoodVM> Foods { get; set; }
    }
}
