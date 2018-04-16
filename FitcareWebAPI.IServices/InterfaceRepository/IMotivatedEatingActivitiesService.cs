using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the MotivatedEatingActivitiesService service class.
    /// </summary>
    public interface IMotivatedEatingActivitiesService
    {
        Task<MotivatedEatingActivity> Insert(MotivatedEatingActivity tblMotivatedEatingActivity);
        IEnumerable<MotivatedEatingActivity> GetAll();
        Task<MotivatedEatingActivity> GetByID(int PlayerId);
        Task<MotivatedEatingActivity> Delete(int MotivatedEatingActivityId);
        Task Update(int Id, MotivatedEatingActivity tblMotivatedEatingActivity);
    }

}
