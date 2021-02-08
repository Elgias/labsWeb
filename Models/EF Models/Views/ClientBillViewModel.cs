using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labs.Models.EF_Models.Views
{
    public class ClientBillViewModel
    {
        public string ClientFullName { get; set; }
        public int Total { get; set; }
        public int CompletedWorksTotal { get; set; }
        public int Payed { get; set; }
    }
}
