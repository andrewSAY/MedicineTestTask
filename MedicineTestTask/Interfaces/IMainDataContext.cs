using System.Data.Entity;
using MedicineTestTask.Models.Entities;

namespace MedicineTestTask.Interfaces
{
    public interface IMainDataContext
    {
        DbSet<Patient> Patients { get; set; }
    }
}
