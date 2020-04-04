using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class FoodVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Image { get; set; }
        public long FoodCategoryId { get; set; }
        public bool Status { get; set; }
        public FoodCategoryVM FoodCategory { get; set; }

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
