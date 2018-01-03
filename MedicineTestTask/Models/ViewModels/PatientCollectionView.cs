using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicineTestTask.Models.ViewModels
{
    public class PatientCollectionView
    {
        public IEnumerable<PatientView> Items { get; set; }
        public long TotalCount { get; set; }
    }
}