using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MedicineTestTask.Attributes
{
    public class DateIsGreaterThanAttribute : ValidationAttribute
    {
        private DateTime _etalonDate;
        public DateIsGreaterThanAttribute(DateTime etalonDate)
        {
            _etalonDate = etalonDate;
        }
        public override bool IsValid(object value)
        {
            if (!(value is DateTime))
                throw new ArgumentException("The attribute must be applied to DateTime field only.");
            var comparedDate = (DateTime)value;
            return comparedDate > _etalonDate;
        }
    }
}