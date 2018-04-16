using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the CustomizationAvatarsService service class.
    /// </summary>
    public interface ICustomizationAvatarsService
    {
        Task<CustomizationAvatar> Insert(CustomizationAvatar tblCustomizationAvatar);
        IEnumerable<CustomizationAvatar> GetAll();
        Task<CustomizationAvatar> GetByID(int PlayerId);
        Task<CustomizationAvatar> Delete(int CustomizationAvatarId);
        Task Update(int Id, CustomizationAvatar tblCustomizationAvatar);
    }

}
