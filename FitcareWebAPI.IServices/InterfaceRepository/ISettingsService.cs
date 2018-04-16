using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the SettingsService service class.
    /// </summary>
    public interface ISettingsService
    {
        Task<Settings> Insert(Settings tblSettings);
        IEnumerable<Settings> GetAll();
        Task<Settings> GetByID(int PlayerId);
        Task<Settings> Delete(int SettingsId);
        Task Update(int Id, Settings tblSettings);
    }

}
