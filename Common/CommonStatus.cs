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

        public const string ActiveFeedBack = "Hiện";
        public const string DeleteFeedBack = "Ẩn";

        public const byte FeedBackActive = 1;
        public const byte FeedBackDelete = 0;
        public const byte FeedBackDefault = 99;

        public const string AdminRole = "Admin";
        public const string CustomerRole = "Customer";

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

        public static IDictionary<byte, string> StatusFeedBack
        {
            get
            {
                return new Dictionary<byte, string>
                {
                    { FeedBackDefault, "" },
                    { FeedBackActive, ActiveFeedBack },
                    { FeedBackDelete, DeleteFeedBack }
                };
            }
        }

    }
}
