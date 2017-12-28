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
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondNmae{ get; set; }
        public DateTime BirthDate { get; set; }
    }
}