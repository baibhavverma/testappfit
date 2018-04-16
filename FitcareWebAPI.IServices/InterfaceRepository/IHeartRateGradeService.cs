using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the Achievements service class.
    /// </summary>

    public interface IHeartRateGradeService
    {
        Task<HeartRateGrade> Insert(HeartRateGrade tblHeartRateGrade);
        IEnumerable<HeartRateGrade> GetAll();
        Task<HeartRateGrade> GetByID(int HeartRateGradeId);
        Task<HeartRateGrade> Delete(int HeartRateGradeId);
        Task Update(int Id, HeartRateGrade tblHeartRateGrade);
    }

}
