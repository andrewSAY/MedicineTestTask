using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MedicineTestTask.Models.ViewModels
{
    public class PatientView
    {        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName{ get; set; }
        public DateTime BirthDate { get; set; }
    }
}