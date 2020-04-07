namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Design
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Design()
        {
            Documents = new HashSet<Document>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Document> Documents { get; set; }
    }
}
