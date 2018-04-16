
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

    public interface ITargetPeakHrgradeService
    {
        Task<TargetPeakHrgrade> Insert(TargetPeakHrgrade tblTargetPeakHrgrade);
        IEnumerable<TargetPeakHrgrade> GetAll();
        Task<TargetPeakHrgrade> GetByID(int TargetPeakHrgradeId);
        Task<TargetPeakHrgrade> Delete(int TargetPeakHrgradeId);
        Task Update(int Id, TargetPeakHrgrade tblTargetPeakHrgrade);
    }

}
