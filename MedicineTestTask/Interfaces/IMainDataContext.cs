using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MedicineTestTask.Models.Entities;

namespace MedicineTestTask.Interfaces
{
    public interface IMainDataContext: IDataContext
    {
        DbSet<Patient> Patients { get; set; }
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
