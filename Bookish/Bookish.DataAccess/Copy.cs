using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.DataAccess
{
    public class Copy
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public int UserID { get; set; }
        public string DueDate { get; set; }
    }
}
