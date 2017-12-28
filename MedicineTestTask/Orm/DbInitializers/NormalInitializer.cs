using System.Data.Entity;

namespace MedicineTestTask.Orm.DbInitializers
{
    public class NormalInitializer: MigrateDatabaseToLatestVersion<MainDataContext, Configuration>
    {
    }
}