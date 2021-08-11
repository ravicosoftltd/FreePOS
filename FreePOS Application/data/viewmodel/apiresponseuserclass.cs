using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreePOS.data.viewmodel
{
    public class apiresponseuserclass
    {
        public string _id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string FreePOSmembershipplan { get; set; } // values are Package 1,Package 2,Package 3
        public string smsplan { get; set; }
    }
}
