using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the PlayerShopInfoesService service class.
    /// </summary>
    public interface IPlayerShopInfoesService
    {
        Task<PlayerShopInfo> Insert(PlayerShopInfo tblPlayerShopInfo);
        IEnumerable<PlayerShopInfo> GetAll();
        Task<PlayerShopInfo> GetByID(int PlayerId);
        Task<PlayerShopInfo> Delete(int PlayerShopInfoId);
        Task Update(int Id, PlayerShopInfo tblPlayerShopInfo);
    }

}
