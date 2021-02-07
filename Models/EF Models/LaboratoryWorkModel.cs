using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace labs.Models.EF_Models
{
    public class LaboratoryWorkModel
    {
        [Key]
        [Required(ErrorMessage = "Laboratory work id required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Subject id required")]
        public int SubjectId { get; set; }
        [Required(ErrorMessage = "Subject number required")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Subject price required")]
        public double Price { get; set; }

        public SubjectModel SubjectModel { get; set; }
        public ICollection<OrderModel> Orders { get; set; }
    }
}
