using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MedicineTestTask.Models.Entities
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}