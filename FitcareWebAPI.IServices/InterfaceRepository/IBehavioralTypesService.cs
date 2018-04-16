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

    public interface IBehavioralTypesService
    {
        Task<BehavioralType> Insert(BehavioralType tblBehavioralType);
        IEnumerable<BehavioralType> GetAll();
        Task<BehavioralType> GetByID(int BehavioralTypeId);
        Task<BehavioralType> Delete(int tblBehavioralTypeId);
        Task Update(int Id, BehavioralType tblBehavioralType);
    }

}
