using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class HotMenuVM
    {
        public Guid Id { get; set; }

        public Guid FoodId1 { get; set; }

        public Guid FoodId2 { get; set; }

        public Guid FoodId3 { get; set; }

        public Guid FoodId4 { get; set; }

        public Guid FoodId5 { get; set; }

        public Guid FoodId6 { get; set; }

        public bool Status { get; set; }

        public DateTime CreateDate { get; set; }

        public FoodVM Food { get; set; }

        public FoodVM Food1 { get; set; }

        public FoodVM Food2 { get; set; }

        public FoodVM Food3 { get; set; }

        public FoodVM Food4 { get; set; }

        public FoodVM Food5 { get; set; }
    }
}
