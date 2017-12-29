using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MedicineTestTask.Models.Entities;

namespace MedicineTestTask.Orm.DbInitializers
{
    public class CreateDatabaseInitializer: CreateDatabaseIfNotExists<MainDataContext>
    {
        protected override void Seed(MainDataContext context)
        {
            using (var tranc = context.Database.BeginTransaction())
            {
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        var patient = new Patient();
                        if (i % 2 == 0)
                        {
                            patient.FirstName = "John";
                            patient.SecondName = $"Silver{i}";
                            patient.BirthDate = DateTime.Now.AddYears(-25);
                        }
                        else
                        {
                            patient.FirstName = "Richard";
                            patient.SecondName = $"Bower{i}";
                            patient.BirthDate = DateTime.Now.AddYears(-20);
                        }
                        patient.Guid = Guid.NewGuid();                        
                        context.Patients.Add(patient);
                        context.SaveChanges();
                    }
                    
                    tranc.Commit();
                }
                catch
                {
                    tranc.Rollback();
                    throw;                    
                }
            }            
        }
    }
}