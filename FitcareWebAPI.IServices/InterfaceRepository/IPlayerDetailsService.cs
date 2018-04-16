using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the PlayerDetailsService service class.
    /// </summary>
    public interface IPlayerDetailsService
    {
        Task<PlayerDetails> Insert(PlayerDetails tblPlayerDetails);
        IEnumerable<PlayerDetails> GetAll();
        Task<PlayerDetails> GetByID(int PlayerId);
        Task<PlayerDetails> Delete(int PlayerDetailsId);
        Task Update(int Id, PlayerDetails tblPlayerDetails);
    }

}
