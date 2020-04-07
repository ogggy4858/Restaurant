using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class FeedBackVM
    {
        public Guid Id { get; set; }

        public string CustomerName { get; set; }

        public string Phone { get; set; }

        public string Message { get; set; }

        public bool Status { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateDateDisplay
        {
            get
            {
                return CreateDate.ToLongDateString();
            }
        }

        public long OrderIndex { get; set; }

        public string Title { get; set; }

        public List<string> ListFileName { get; set; }



        public ICollection<DocumentVM> Documents { get; set; }
    }
}
