using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the CurrentEatingActivityHistoriesService service class.
    /// </summary>

    public interface ICurrentEatingActivityHistoriesService
    {
        Task<CurrentEatingActivityHistory> Insert(CurrentEatingActivityHistory tblCurrentEatingActivityHistory);
        IEnumerable<CurrentEatingActivityHistory> GetAll();
        Task<CurrentEatingActivityHistory> GetByID(int PlayerId);
        Task<CurrentEatingActivityHistory> Delete(int CurrentEatingActivityHistoryId);
        Task Update(int Id, CurrentEatingActivityHistory tblCurrentEatingActivityHistory);
    }

}
