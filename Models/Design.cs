namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Design
    {
        public Guid Id { get; set; }

        [Required]
        public string Content { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Quote { get; set; }

        public long DesignCategoryId { get; set; }

        public bool Status { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual DesignCategory DesignCategory { get; set; }
    }
}
