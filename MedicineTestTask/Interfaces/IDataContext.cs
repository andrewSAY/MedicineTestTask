using System.Threading.Tasks;

namespace MedicineTestTask.Interfaces
{
    public interface IDataContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
