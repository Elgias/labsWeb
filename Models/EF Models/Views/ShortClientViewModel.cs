using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labs.Models.EF_Models.Views
{
    public class ShortClientViewModel
    {
        public int ClientId { get; set; }
        public string ClientFullName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientSequentialNum { get; set; }
    }
}
