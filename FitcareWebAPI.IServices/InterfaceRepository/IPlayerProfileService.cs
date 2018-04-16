using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the PlayerProfileService service class.
    /// </summary>
    public interface IPlayerProfileService
    {
        Task<PlayerProfile> Insert(PlayerProfile tblPlayerProfile);
        IEnumerable<PlayerProfile> GetAll();
        Task<PlayerProfile> GetByID(int PlayerId);
        Task<PlayerProfile> Delete(int PlayerId);
        Task Update(int Id, PlayerProfile tblPlayerProfile);
    }

}
