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

    public interface IMotivatedEatingActivityOptionsService
    {
        Task<MotivatedEatingActivityOptions> Insert(MotivatedEatingActivityOptions tblMotivatedEatingActivityOptions);
        IEnumerable<MotivatedEatingActivityOptions> GetAll();
        Task<MotivatedEatingActivityOptions> GetByID(int MotivatedEatingActivityId);
        Task<MotivatedEatingActivityOptions> Delete(int MotivatedEatingActivityOptionsId);
        Task Update(int Id, MotivatedEatingActivityOptions tblMotivatedEatingActivityOptions);
    }

}
