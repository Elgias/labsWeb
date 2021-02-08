using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace labs.Models.ViewModels
{
    public class LaboratoryWorkDTO
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
    }
}
