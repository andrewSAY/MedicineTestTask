using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MedicineTestTask.Attributes;

namespace MedicineTestTask.Models.ViewModels
{
    public class PatientView
    {        
        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(150)]
        public string SecondName{ get; set; }
        [DateIsGreaterThan("1800-01-01 00:00:00")]
        public DateTime BirthDate { get; set; }
    }
}