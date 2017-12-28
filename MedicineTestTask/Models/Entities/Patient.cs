using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicineTestTask.Models.Entities
{
    public class Patient: Entity
    {
        [StringLength(150)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(150)]
        [Required]
        public string SecondName { get; set; }        
        public DateTime BirthDate { get; set; }
        [Index(IsUnique = true)]
        public Guid Guid { get; set; }
    }
}