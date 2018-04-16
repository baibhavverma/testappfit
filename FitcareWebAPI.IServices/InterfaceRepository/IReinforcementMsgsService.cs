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

    public interface IReinforcementMsgsService
    {
        Task<ReinforcementMsgs> Insert(ReinforcementMsgs tblReinforcementMsgs);
        IEnumerable<ReinforcementMsgs> GetAll();
        Task<ReinforcementMsgs> GetByID(int ReinforcementMsgsId);
        Task<ReinforcementMsgs> Delete(int ReinforcementMsgsId);
        Task Update(int Id, ReinforcementMsgs tblReinforcementMsgs);
    }

}
