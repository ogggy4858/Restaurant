namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Document")]
    public partial class Document
    {
        public long Id { get; set; }

        [Required]
        public string FileName { get; set; }

        public Guid? DesignId { get; set; }

        public Guid? FeedBackId { get; set; }

        public bool Stauts { get; set; }

        public virtual Design Design { get; set; }

        public virtual FeedBack FeedBack { get; set; }
    }
}
