using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the CurrentEatingActivitiesService service class.
    /// </summary>

    public interface ICurrentEatingActivitiesService
    {
        Task<CurrentEatingActivity> Insert(CurrentEatingActivity tblCurrentEatingActivity);
        IEnumerable<CurrentEatingActivity> GetAll();
        Task<CurrentEatingActivity> GetByID(int PlayerId);
        Task<CurrentEatingActivity> Delete(int CurrentEatingActivityId);
        Task Update(int Id, CurrentEatingActivity tblCurrentEatingActivity);
    }

}
