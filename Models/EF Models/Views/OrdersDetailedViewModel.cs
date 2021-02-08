using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labs.Models.EF_Models.Views
{
    public class OrdersDetailedViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientFullName { get; set; }
        public int LabWorkId { get; set; }
        public string LabWorkSubjTitle { get; set; }
        public int LabWorkNum { get; set; }
        public DateTime RegisterDateTime { get; set; }
        public DateTime? CompleteDateTime { get; set; }
        public double Price { get; set; }
        public double? Discount { get; set; }
        public double? Payed { get; set; }
    }
}
