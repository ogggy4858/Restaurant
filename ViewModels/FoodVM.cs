using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class FoodVM
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Tên món ăn là bắt buộc")]
        [StringLength(200, ErrorMessage = "Tên quá dài")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Mô tả là bắt buộc")]
        [StringLength(200, ErrorMessage = "Mô tả quá dài")]
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal? Price { get; set; }
        public string PriceDisplay 
        { 
            get 
            {
                return Price + " đ";
            } 
        }
        [Required(ErrorMessage = "Hình ảnh là bắt buộc")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Loại món ăn là bắt buộc")]
        public long FoodCategoryId { get; set; }
        public bool Status { get; set; }
        public FoodCategoryVM FoodCategory { get; set; }
        public DateTime CreateDate { get; set; }
        public long OrderIndex { get; set; }
        public ICollection<MenuVM> Menus { get; set; }
        public ICollection<MenuVM> Menus1 { get; set; }
        public ICollection<MenuVM> Menus2 { get; set; }
        public ICollection<MenuVM> Menus3 { get; set; }
        public ICollection<MenuVM> Menus4 { get; set; }
        public ICollection<MenuVM> Menus5 { get; set; }
        public ICollection<MenuVM> Menus6 { get; set; }
        public ICollection<MenuVM> Menus7 { get; set; }
    }
}
