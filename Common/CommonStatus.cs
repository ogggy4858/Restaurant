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

        public const string ActiveDisplay = "Áp dụng";
        public const string DeleteDisplay = "Không áp dụng";

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
