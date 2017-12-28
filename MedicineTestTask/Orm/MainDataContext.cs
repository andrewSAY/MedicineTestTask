using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MedicineTestTask.Interfaces;
using MedicineTestTask.Models.Entities;
using MedicineTestTask.Orm.DbInitializers;

namespace MedicineTestTask.Orm
{
    public class MainDataContext : DbContext, IMainDataContext
    {
        public MainDataContext() : base("MainData")
        {
            if (!Database.Exists())
            {
                Database.SetInitializer(new CreateDatabaseInitializer());
            }
            else
            {
                Database.SetInitializer(new NormalInitializer());
            }
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
            Database.Initialize(false);
        }

        public override int SaveChanges()
        {
            BeforeSaving();
            return base.SaveChanges();
        }

        public async override Task<int> SaveChangesAsync()
        {
            BeforeSaving();
            return await base.SaveChangesAsync();
        }

        private void BeforeSaving()
        {
            if (ChangeTracker.HasChanges())
            {
                var now = DateTime.UtcNow;
                var entities = ChangeTracker.Entries<Entity>()
                    .Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified);
                    
                entities.ToList().ForEach(entity => {
                    if (entity.State == EntityState.Added)
                        entity.Entity.CreatedDate = now;
                    if (entity.State == EntityState.Modified)
                        entity.Entity.LastModifiedDate = now;
                });
            }
        }        

        public DbSet<Patient> Patients { get; set; }
    }
}