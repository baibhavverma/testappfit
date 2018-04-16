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

    public interface IEncouragementMsgsService
    {
        Task<EncouragementMsgs> Insert(EncouragementMsgs tblEncouragementMsgs);
        IEnumerable<EncouragementMsgs> GetAll();
        Task<EncouragementMsgs> GetByID(int EncouragementMsgsId);
        Task<EncouragementMsgs> Delete(int EncouragementMsgsId);
        Task Update(int Id, EncouragementMsgs tblEncouragementMsgs);
    }

}
