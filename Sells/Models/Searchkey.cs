using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sells.Models
{
    public class Searchkey
    {
        public string SearchCust { set; get; }
        public string SearchPdct { set; get; }
        public string StartDay { set; get; }
        public string EndDay { set; get; }
    }
}
