using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class MenuVM
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Món ăn là bắt buộc")]
        public Guid FoodId1 { get; set; }
        [Required(ErrorMessage = "Món ăn là bắt buộc")]
        public Guid FoodId2 { get; set; }
        [Required(ErrorMessage = "Món ăn là bắt buộc")]
        public Guid FoodId3 { get; set; }
        [Required(ErrorMessage = "Món ăn là bắt buộc")]
        public Guid FoodId4 { get; set; }
        [Required(ErrorMessage = "Món ăn là bắt buộc")]
        public Guid FoodId5 { get; set; }
        [Required(ErrorMessage = "Món ăn là bắt buộc")]
        public Guid FoodId6 { get; set; }
        [Required(ErrorMessage = "Món ăn là bắt buộc")]
        public Guid FoodId7 { get; set; }
        [Required(ErrorMessage = "Món ăn là bắt buộc")]
        public Guid FoodId8 { get; set; }

        public bool Status { get; set; }

        public DateTime CreateDate { get; set; }

        public FoodVM Food { get; set; }

        public FoodVM Food1 { get; set; }

        public FoodVM Food2 { get; set; }

        public FoodVM Food3 { get; set; }

        public FoodVM Food4 { get; set; }

        public FoodVM Food5 { get; set; }

        public FoodVM Food6 { get; set; }

        public FoodVM Food7 { get; set; }
    }
}
