using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the PlayerAchievementInfoesService service class.
    /// </summary>
    public interface IPlayerAchievementInfoesService
    {
        Task<PlayerAchievementInfo> Insert(PlayerAchievementInfo tblPlayerAchievementInfo);
        IEnumerable<PlayerAchievementInfo> GetAll();
        Task<PlayerAchievementInfo> GetByID(int PlayerId);
        Task<PlayerAchievementInfo> Delete(int PlayerAchievementInfoId);
        Task Update(int Id, PlayerAchievementInfo tblPlayerAchievementInfo);
    }

}
