using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the PlayerGameInfoesService service class.
    /// </summary>
    public interface IPlayerGameInfoesService
    {
        Task<PlayerGameInfo> Insert(PlayerGameInfo tblPlayerGameInfo);
        IEnumerable<PlayerGameInfo> GetAll();
        Task<PlayerGameInfo> GetByID(int PlayerId);
        Task<PlayerGameInfo> Delete(int PlayerGameInfoId);
        Task Update(int Id, PlayerGameInfo tblPlayerGameInfo);
    }

}
