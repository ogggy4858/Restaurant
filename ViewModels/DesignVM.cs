using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class DesignVM
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public string Title { get; set; }

        public string Quote { get; set; }

        public long DesignCategoryId { get; set; }

        public bool Status { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual DesignCategoryVM DesignCategory { get; set; }

        public ICollection<DocumentVM> Documents { get; set; }
    }
}
