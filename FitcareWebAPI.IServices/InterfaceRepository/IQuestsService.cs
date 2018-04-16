using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the QuestsService service class.
    /// </summary>
    public interface IQuestsService
    {
        Task<Quests> Insert(Quests tblQuests);
        IEnumerable<Quests> GetAll();
        Task<Quests> GetByID(int PlayerId);
        Task<Quests> Delete(int QuestsId);
        Task Update(int Id, Quests tblQuests);
    }

}
