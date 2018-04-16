using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the ShopsService service class.
    /// </summary>
    public interface IShopsService
    {
        Task<Shop> Insert(Shop tblShop);
        IEnumerable<Shop> GetAll();
        Task<Shop> GetByID(int PlayerId);
        Task<Shop> Delete(int ShopId);
        Task Update(int Id, Shop tblShop);
    }

}
