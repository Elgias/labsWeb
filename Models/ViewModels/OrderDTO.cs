using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace labs.Models.ViewModels
{
    public class OrderDTO
    {
        [Key]
        [Required(ErrorMessage = "Order id required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Client id required")]
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Laboratory work id required")]
        public int LaboratoryWorkId { get; set; }
        [Required(ErrorMessage = "Register time stamp required")]
        public DateTime RegisterDateTime { get; set; }

        public DateTime CompleteDateTime { get; set; }

        public double Discount { get; set; }

        public double Payed { get; set; }
    }
}
