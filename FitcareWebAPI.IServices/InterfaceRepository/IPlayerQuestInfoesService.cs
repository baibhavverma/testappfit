using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the PlayerQuestInfoesService service class.
    /// </summary>
    public interface IPlayerQuestInfoesService
    {
        Task<PlayerQuestInfo> Insert(PlayerQuestInfo tblPlayerQuestInfo);
        IEnumerable<PlayerQuestInfo> GetAll();
        Task<PlayerQuestInfo> GetByID(int PlayerId);
        Task<PlayerQuestInfo> Delete(int PlayerQuestInfoId);
        Task Update(int Id, PlayerQuestInfo tblPlayerQuestInfo);
    }

}
