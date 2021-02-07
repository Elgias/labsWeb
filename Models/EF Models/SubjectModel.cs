using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace labs.Models.EF_Models
{
    public class SubjectModel
    {
        [Key]
        [Required(ErrorMessage = "Subject id required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Subject title required")]
        [MaxLength(255, ErrorMessage = "Subject title more then 255")]
        public string Title { get; set; }

        public ICollection<LaboratoryWorkModel> LaboratoryWorkModel;
    }
}
