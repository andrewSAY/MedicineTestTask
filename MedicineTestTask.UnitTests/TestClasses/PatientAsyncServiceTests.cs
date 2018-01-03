using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MedicineTestTask.Services;
using MedicineTestTask.Interfaces;
using MedicineTestTask.Repositories;
using MedicineTestTask.UnitTests.Fakes;
using MedicineTestTask.Models.Entities;
using MedicineTestTask.Models.ViewModels;
using MedicineTestTask.Models;

namespace MedicineTestTask.UnitTests.TestClasses
{
    public class PatientAsyncServiceTests
    {
        #region Prepapring area
        private FakeDataContext GetDataContext()
        {
            var dataContext = new FakeDataContext();
            var patients = new List<Patient>();
            for(int i = 1; i <= 5; i++)
            {
                var patient = new Patient
                {
                    Id = i,
                    FirstName = $"F{i}",
                    SecondName = $"S{i}",
                    BirthDate = DateTime.Now,
                    Guid = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                };
                patients.Add(patient);
            }

            dataContext.SetCollectionAsDbSet<Patient>(patients);

            return dataContext;
        }
        private IAsyncRepository GetRepository(IMainDataContext dataContext)
        {
            return new CommonRepository(dataContext);
        }
        private PatientAsyncService GetServiceUnderTest(IMainDataContext dataContext)
        {
            var repository = GetRepository(dataContext);
            return new PatientAsyncService(repository);
        }
        #endregion
        #region Common methods
        private IEnumerable<PatientView> GetFilteredPatientTestCommon(int from, int to, string sotringPropertyName, SortDirection sortDirection)
        {
            var dataContext = GetDataContext();
            var service = GetServiceUnderTest(dataContext);

            return service.GetFilteredPatientsAsync(from, to, sotringPropertyName, sortDirection).Result;
        }
        #endregion
        [Test]
        public void SaveNewPatientAsync_Always_DataContextHasNewRecord()
        {
            var dataContext = GetDataContext();
            var service = GetServiceUnderTest(dataContext);            
            var patient = new PatientView { FirstName = "UniquePatientFirstName", SecondName = "UniquePatientSecondName" };

            service.SaveNewPatientAsync(patient).Wait();

            Assert.IsTrue(dataContext
                .Patients.Any(p => p.FirstName == patient.FirstName && p.SecondName == patient.SecondName));
        }
        [Test]
        public void GetPatientsAsync_Always_CountReturnedRecordsEqualsOneCountInDataContext()
        {
            var dataContext = GetDataContext();
            var service = GetServiceUnderTest(dataContext);

            var recordsCount = service.GetPatientsAsync().Result.Count();
            var expectedCount = dataContext.Patients.Count();

            Assert.AreEqual(expectedCount, recordsCount);
        }
        [Test]
        [TestCase(1, 3, 3)]
        [TestCase(2, 3, 2)]
        [TestCase(1, 5, 5)]
        [TestCase(3, 5, 3)]
        [TestCase(0, 4, 4)]
        public void GetFilteredPatientsAsync_Always_CountReturnedRecordsEqualsExpectedOne(int from, int to, int expectedRecordsCount)
        {
            var patients = GetFilteredPatientTestCommon(from, to, "SecondName", SortDirection.Asc);
            var resultCount = patients.Count();

            Assert.AreEqual(expectedRecordsCount, resultCount);
        }
        [Test]
        [TestCase(1, 3, "FirstName", SortDirection.Asc, "F1")]
        [TestCase(2, 3, "SecondName", SortDirection.Asc, "F2")]
        [TestCase(1, 5, "BirthDate", SortDirection.Desc, "F5")]
        [TestCase(3, 5, "Id", SortDirection.Desc, "F5")]
        public void GetFilteredPatientsAsync_Always_FirstNameOfFirstReturnedRecordEqualsExpectedOne(int from, int to, string sotringPropertyName, SortDirection sortDirection, string firstNameFirstReturnedRecord)
        {
            var patients = GetFilteredPatientTestCommon(from, to, sotringPropertyName, sortDirection);
            var firstPatient = patients.FirstOrDefault();

            Assert.AreEqual(firstNameFirstReturnedRecord, firstPatient.FirstName);
        }
        [Test]
        [TestCase(1, 3, "FirstName", SortDirection.Asc, "F3")]
        [TestCase(2, 3, "SecondName", SortDirection.Asc, "F3")]
        [TestCase(1, 4, "BirthDate", SortDirection.Desc, "F1")]
        [TestCase(3, 5, "Id", SortDirection.Desc, "F3")]
        public void GetFilteredPatientsAsync_Always_FirstNameOfLastReturnedRecordEqualsExpectedOne(int from, int to, string sotringPropertyName, SortDirection sortDirection, string firstNameLastReturnedRecord)
        {
            var patients = GetFilteredPatientTestCommon(from, to, sotringPropertyName, sortDirection);
            var lastPatient = patients.LastOrDefault();

            Assert.AreEqual(firstNameLastReturnedRecord, lastPatient.FirstName);
        }
        [Test]
        public void GetTotalPatientCountAsync_Always_ReturnExceptedNumber()
        {
            var dataContext = GetDataContext();
            var service = GetServiceUnderTest(dataContext);

            long expectedCount = 5;
            var result = service.GetTotalPatientCountAsync().Result;

            Assert.AreEqual(expectedCount, result);
        }
    }
}
