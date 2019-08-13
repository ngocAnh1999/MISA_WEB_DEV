using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Entities
{
    public class Customer
    {
        public Guid CustomerID { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public int CustomerPhone { get; set; }
        public DateTime Birthday { get; set; }
        public string CustomerGroup { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
    }
}
