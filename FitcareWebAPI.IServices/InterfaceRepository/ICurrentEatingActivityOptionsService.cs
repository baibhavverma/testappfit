using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the CurrentEatingActivityOptionsService service class.
    /// </summary>
    public interface ICurrentEatingActivityOptionsService
    {
        Task<CurrentEatingActivityOptions> Insert(CurrentEatingActivityOptions tblCurrentEatingActivityOptions);
        IEnumerable<CurrentEatingActivityOptions> GetAll();
        Task<CurrentEatingActivityOptions> GetByID(int PlayerId);
        Task<CurrentEatingActivityOptions> Delete(int CurrentEatingActivityOptionsId);
        Task Update(int Id, CurrentEatingActivityOptions tblCurrentEatingActivityOptions);
    }

}
