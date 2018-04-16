using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the Achievements service class.
    /// </summary>

    public interface IAchievementsService
    {
        Task<Achievement> Insert(Achievement tblAchievement);
        IEnumerable<Achievement> GetAll();
        Task<Achievement> GetByID(int PlayerId);
        Task<Achievement> Delete(int AchievementId);
        Task Update(int Id, Achievement tblAchievement);
    }

}
