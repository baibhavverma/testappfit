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

    public interface IMotivatedEatingActivityGradesService
    {
        Task<MotivatedEatingActivityGrade> Insert(MotivatedEatingActivityGrade tblMotivatedEatingActivityGrade);
        IEnumerable<MotivatedEatingActivityGrade> GetAll();
        Task<MotivatedEatingActivityGrade> GetByID(int MotivatedEatingActivityGradeId);
        Task<MotivatedEatingActivityGrade> Delete(int MotivatedEatingActivityGradeId);
        Task Update(int Id, MotivatedEatingActivityGrade tblMotivatedEatingActivityGrade);
    }

}
