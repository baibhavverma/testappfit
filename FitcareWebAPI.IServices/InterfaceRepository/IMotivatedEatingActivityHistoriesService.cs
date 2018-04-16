using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the MotivatedEatingActivityHistoryService service class.
    /// </summary>

    public interface IMotivatedEatingActivityHistoriesService
    {
        Task<MotivatedEatingActivityHistory> Insert(MotivatedEatingActivityHistory tblMotivatedEatingActivityHistory);
        IEnumerable<MotivatedEatingActivityHistory> GetAll();
        Task<MotivatedEatingActivityHistory> GetByID(int PlayerId);
        Task<MotivatedEatingActivityHistory> Delete(int MotivatedEatingActivityHistoryId);
        Task Update(int Id, MotivatedEatingActivityHistory tblMotivatedEatingActivityHistory);
    }

}
