using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitcareWebAPI.IServices.InterfaceRepository;
using FitcareWebAPI.Model.Model.DB;
using Microsoft.EntityFrameworkCore;

namespace FitcareWebAPI.Services.ServiceRepository
{
    /// <summary>
    /// This class have interface methods implementation of IShopsService
    /// for Get, Get by ID, Create, Update and Delete Shop.
    /// </summary>

    public class ShopsService : IShopsService
    {
        private readonly FitCareDbContext context;

        public ShopsService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<Shop> Insert(Shop tblShop)
        {
            try
            {
                tblShop.CreatedDate = DateTime.Now;
                context.Add(tblShop);
                await context.SaveChangesAsync();
                return tblShop;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<Shop> GetAll()
        {
            try
            {
                return context.TblShop.Where(s => s.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Shop> GetByID(int shopId)
        {
            try
            {
                return await context.TblShop.FirstOrDefaultAsync(s => s.ShopId == shopId && s.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<Shop> Delete(int shopId)
        {
            try
            { 
                var objShop = await context.TblShop.SingleOrDefaultAsync(s => s.ShopId == shopId);
                objShop.IsDeleted = true;
                objShop.DeletedBy = shopId;
                objShop.DeletedDate = DateTime.Now;
                if (objShop == null)
                    throw new InvalidOperationException();

                context.TblShop.Update(objShop);
                await context.SaveChangesAsync();
                return objShop;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, Shop tblShop)
        {
            try
            {
                if (tblShop == null)
                    throw new ArgumentNullException(nameof(tblShop));
                if (Id != tblShop.ShopId)
                {
                    throw new NotImplementedException();
                }

                context.TblShop.Update(tblShop);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

         
    }
}
