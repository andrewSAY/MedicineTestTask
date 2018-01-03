using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MedicineTestTask.Models.ViewModels;
using MedicineTestTask.Interfaces;
using MedicineTestTask.Models;

namespace MedicineTestTask.Controllers
{
    public class PatientsController : ApiController
    {
        private IPatientAsyncService _patientService;
        public PatientsController(IPatientAsyncService patientService)
        {
            _patientService = patientService;
        }
        public async Task<IEnumerable<PatientView>> GetAll()
        {
            return await _patientService.GetPatientsAsync();
        }
        public async Task<PatientCollectionView> GetSorted(int from, int to, string fieldName, SortDirection sortDirection)
        {           
            var patients = await _patientService.GetFilteredPatientsAsync(from, to, fieldName, sortDirection);
            var patientsTotalCount= await _patientService.GetTotalPatientCountAsync();
           
            return new PatientCollectionView {
                Items = patients,
                TotalCount = patientsTotalCount
            };
        }
        public async Task<HttpResponseMessage> PostNew(PatientView patient)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            await _patientService.SaveNewPatientAsync(patient);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
