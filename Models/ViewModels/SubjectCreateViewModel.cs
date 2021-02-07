using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace labs.Models.ViewModels
{
    public class SubjectCreateViewModel
    {
        [Required(ErrorMessage = "Subject title required")]
        [MaxLength(255, ErrorMessage = "Subject title more then 255")]
        public string Title { get; set; }
    }
}
