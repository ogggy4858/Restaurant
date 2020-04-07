using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class DocumentVM
    {
        public long Id { get; set; }

        public string FileName { get; set; }

        public Guid? DesignId { get; set; }

        public Guid? FeedBackId { get; set; }

        public bool Stauts { get; set; }

        public virtual DesignVM Design { get; set; }

        public virtual FeedBackVM FeedBack { get; set; }
    }
}
