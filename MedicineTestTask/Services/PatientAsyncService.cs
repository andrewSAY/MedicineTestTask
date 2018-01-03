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
        public async Task<IEnumerable<PatientView>> GetFilteredPatientsAsync(int from, int to, string sortingProperty, SortDirection sortDirection)
        {            
            var patients = await _repository
                .FindFilteredAsync<Patient>(p => true, from, to, sortingProperty, sortDirection == SortDirection.Desc);
            return patients.Select(patient => new PatientView
            {
                FirstName = patient.FirstName,
                SecondName = patient.SecondName,
                BirthDate = patient.BirthDate
            });
        }

        public async Task<IEnumerable<PatientView>> GetPatientsAsync()
        {
            return await _repository.FindByAsync<Patient, PatientView>(patient => true
                , patient => new PatientView
                {                    
                    FirstName = patient.FirstName,
                    SecondName = patient.SecondName,
                    BirthDate = patient.BirthDate
                }
                ,new List<string>());
        }

        public async Task<long> GetTotalPatientCountAsync()
        {
            return await _repository.GetCountAsync<Patient>(patient => true);
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