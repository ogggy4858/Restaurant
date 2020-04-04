namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public Guid Id { get; set; }

        public Guid? FoodId1 { get; set; }

        public Guid? FoodId2 { get; set; }

        public Guid? FoodId3 { get; set; }

        public Guid? FoodId4 { get; set; }

        public Guid? FoodId5 { get; set; }

        public Guid? FoodId6 { get; set; }

        public Guid? FoodId7 { get; set; }

        public Guid? FoodId8 { get; set; }

        public bool Status { get; set; }

        public virtual Food Food { get; set; }

        public virtual Food Food1 { get; set; }

        public virtual Food Food2 { get; set; }

        public virtual Food Food3 { get; set; }

        public virtual Food Food4 { get; set; }

        public virtual Food Food5 { get; set; }

        public virtual Food Food6 { get; set; }

        public virtual Food Food7 { get; set; }
    }
}
