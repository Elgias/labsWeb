using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace labs.Models.ViewModels
{
    public class ClientCreateViewModel
    {
        [Key]
        [Required(ErrorMessage = "Client id required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Client first name required")]
        [MaxLength(55)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Client last name required")]
        [MaxLength(55)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Client email required")]
        [EmailAddress(ErrorMessage = "Incorect email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Client sequential number required")]
        [Range(1, 40, ErrorMessage = "Client sequential number must be in 1 to 40 range")]
        public int SequentialNumber { get; set; }
    }
}
