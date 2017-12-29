using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MedicineTestTask.Interfaces;
using MedicineTestTask.Models;
using MedicineTestTask.Models.Entities;
using MedicineTestTask.Models.ViewModels;

namespace MedicineTestTask.Services
{
    public class PatientAsyncService : IPatientAsyncService
    {
        private readonly IAsyncRepository _repository;
        public PatientAsyncService(IAsyncRepository repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<PatientView>> GetFilteredPatientsAsync(int from, int to, string sortedProperty, SortDirection sortDirection)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PatientView>> GetPatientsAsync()
        {
            return _repository.FindByAsync<Patient, PatientView>(patient => true
                , patient => new PatientView
                {                    
                    FirstName = patient.FirstName,
                    SecondName = patient.SecondName,
                    BirthDate = patient.BirthDate
                }
                ,new List<string>());
        }

        public async Task<bool> SaveNewPatientAsync(PatientView patientView)
        {
            var newPatient = GetPatient(patientView);
            _repository.Committer.Add(newPatient);
            var affectedRowsCount = await _repository.Committer.CommitStateAsync();
            return true;
        }
        private Patient GetPatient(PatientView view)
        {
            return new Patient
            {
                FirstName = view.FirstName,
                SecondName = view.SecondName,
                BirthDate = view.BirthDate,
                Guid = Guid.NewGuid()
            };
        }
    }
}