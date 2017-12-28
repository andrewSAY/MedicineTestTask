using System;
using System.Data.Entity.Migrations;

namespace MedicineTestTask.Orm
{
    public class Configuration : DbMigrationsConfiguration<MainDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}