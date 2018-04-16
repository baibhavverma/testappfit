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

    public interface ICompletionGradesService
    {
        Task<CompletionGrade> Insert(CompletionGrade tblCompletionGrade);
        IEnumerable<CompletionGrade> GetAll();
        Task<CompletionGrade> GetByID(int CompletionGradeId);
        Task<CompletionGrade> Delete(int CompletionGradeId);
        Task Update(int Id, CompletionGrade tblCompletionGrade);
    }

}
