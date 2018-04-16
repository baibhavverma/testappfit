using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the CurrentEatingActivityGradesService service class.
    /// </summary>

    public interface ICurrentEatingActivityGradesService
    {
        Task<CurrentEatingActivityGrade> Insert(CurrentEatingActivityGrade tblCurrentEatingActivityGrade);
        IEnumerable<CurrentEatingActivityGrade> GetAll();
        Task<CurrentEatingActivityGrade> GetByID(int PlayerId);
        Task<CurrentEatingActivityGrade> Delete(int CurrentEatingActivityGradeId);
        Task Update(int Id, CurrentEatingActivityGrade tblCurrentEatingActivityGrade);
    }

}
