using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace labs.Models.EF_Models.Views
{
    public class LaboratoryWorkDetailedViewModel
    {
        public int LabWorkId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectTitle { get; set; }
        public int LabWorkNum { get; set; }
        public string ShortName { get; set; }
        public int LabPrice { get; set; }
    }
}
