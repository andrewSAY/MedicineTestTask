using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MedicineTestTask.Interfaces;
using MedicineTestTask.Repositories;
using MedicineTestTask.Orm;
using MedicineTestTask.Services;

namespace MedicineTestTask.DI
{
    public static class DependencyConfiguration
    {
        public static void ConfigurateDependicies(DependencyResolver resolver)
        {
            resolver.RegisterAsSingltone<IDataContext, MainDataContext>();
            resolver.Register<IAsyncRepository, CommonRepository>();
            resolver.Register<IPatientAsyncService, PatientAsyncService>();
        }
    }
}