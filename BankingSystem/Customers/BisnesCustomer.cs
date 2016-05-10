using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Customers
{
    class BisnesCustomer : Customer
    {
        public string FirmName { get; set; }
        public long Nip { get; set; }
        public DateTime FirmDate { get; set; }



    }
}
