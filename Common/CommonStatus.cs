using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CommonStatus
    {
        public const bool Active = true;
        public const bool Delete = false;

        public const string ActiveDisplay = "Active";
        public const string DeleteDisplay = "Deleted";

        public static IDictionary<bool, string> StatusDisplay
        {
            get
            {
                return new Dictionary<bool, string>
                {
                    { Active, ActiveDisplay },
                    { Delete, DeleteDisplay }
                };
            }
        }

    }
}
