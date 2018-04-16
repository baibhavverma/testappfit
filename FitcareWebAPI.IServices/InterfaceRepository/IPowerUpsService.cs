using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the PowerUpsService service class.
    /// </summary>
    public interface IPowerUpsService
    {
        Task<PowerUps> Insert(PowerUps tblPowerUps);
        IEnumerable<PowerUps> GetAll();
        Task<PowerUps> GetByID(int PlayerId);
        Task<PowerUps> Delete(int PowerUpsId);
        Task Update(int Id, PowerUps tblPowerUps);
    }

}
