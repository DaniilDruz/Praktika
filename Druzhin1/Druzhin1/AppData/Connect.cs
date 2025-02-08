using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Druzhin1.AppData
{
    internal class Connect
    {
        public static Database1Entities1 c;
        public static Database1Entities1 context
        {
            get
            {
                if (c == null)
                    c = new Database1Entities1();
                return c;

            }
        }
    }
}
