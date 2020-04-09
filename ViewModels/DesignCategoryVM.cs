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

        [Required(ErrorMessage = "Tên danh mục là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên danh mục không được dài quá 100 ký tự")]
        public string Name { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<DesignVM> Designs { get; set; }
    }
}
