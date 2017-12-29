using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MedicineTestTask.Models.ViewModels;
using MedicineTestTask.Models;

namespace MedicineTestTask.Interfaces
{
    public interface IPatientAsyncService
    {
        /// <summary>
        /// Возвращает список всех пациентов, отсортированных по фамилии и имени
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PatientView>> GetPatientsAsync();
        /// <summary>
        /// Возвращает список пациентов, отсортированных по указнному полю. После сортировки записи будут возвращены с from по to
        /// </summary>
        /// <param name="from">Номер записи от которой возвращать пациентов, включительно</param>
        /// <param name="to">Номер записи по которую возвращать пациентов, включительно</param>
        /// <param name="sortedProperty">Направление сортировки</param>
        /// <param name="sortDirection">Имя поля, по которому должна проводиться сортировка</param>
        /// <returns>Коллекция сущностей</returns>
        Task<IEnumerable<PatientView>> GetFilteredPatientsAsync(int from, int to, string sortedProperty, SortDirection sortDirection);
        /// <summary>
        /// Сохраняет нового пациента в источнике данных
        /// </summary>
        /// <param name="patientView">Объект, содержащий данные пациента</param>
        /// <returns></returns>
        Task<bool> SaveNewPatientAsync(PatientView patientView);
    }
}
