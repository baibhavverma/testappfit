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

    public interface IRpegradeService
    {
        Task<Rpegrade> Insert(Rpegrade tblRpegrade);
        IEnumerable<Rpegrade> GetAll();
        Task<Rpegrade> GetByID(int RpegradeId);
        Task<Rpegrade> Delete(int RpegradeId);
        Task Update(int Id, Rpegrade tblRpegrade);
    }

}
