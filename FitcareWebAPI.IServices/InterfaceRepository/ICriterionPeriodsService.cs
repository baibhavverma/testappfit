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

    public interface ICriterionPeriodsService
    {
        Task<CriterionPeriods> Insert(CriterionPeriods tblCriterionPeriods);
        IEnumerable<CriterionPeriods> GetAll();
        Task<CriterionPeriods> GetByID(int CriterionPeriodsId);
        Task<CriterionPeriods> Delete(int CriterionPeriodsId);
        Task Update(int Id, CriterionPeriods tblCriterionPeriods);
    }

}
