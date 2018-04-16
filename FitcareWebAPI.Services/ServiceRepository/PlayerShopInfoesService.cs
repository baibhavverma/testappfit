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
    /// This class have interface methods implementation of IPlayerShopInfoesService
    /// for Get, Get by ID, Create, Update and Delete PlayerShopInfo.
    /// </summary>

    public class PlayerShopInfoesService : IPlayerShopInfoesService
    {
        private readonly FitCareDbContext context;

        public PlayerShopInfoesService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<PlayerShopInfo> Insert(PlayerShopInfo tblPlayerShopInfo)
        {
            try
            {
                context.Add(tblPlayerShopInfo);
                await context.SaveChangesAsync();
                return tblPlayerShopInfo;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<PlayerShopInfo> GetAll()
        {
            try
            {
                return context.TblPlayerShopInfo.Where(s => s.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PlayerShopInfo> GetByID(int playerId)
        {
            try
            {
                return await context.TblPlayerShopInfo.FirstOrDefaultAsync(s => s.PlayerId == playerId && s.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<PlayerShopInfo> Delete(int playerShopInfoIdId)
        {
            try
            { 
                var objPlayerShopInfo = await context.TblPlayerShopInfo.SingleOrDefaultAsync(s => s.PlayerShopInfoId == playerShopInfoIdId);
                objPlayerShopInfo.IsDeleted = true;
                objPlayerShopInfo.DeletedBy = playerShopInfoIdId;
                objPlayerShopInfo.DeletedDate = DateTime.Now;
                if (objPlayerShopInfo == null)
                    throw new InvalidOperationException();

                context.TblPlayerShopInfo.Update(objPlayerShopInfo);
                await context.SaveChangesAsync();
                return objPlayerShopInfo;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, PlayerShopInfo tblPlayerShopInfo)
        {
            try
            {
                if (tblPlayerShopInfo == null)
                    throw new ArgumentNullException(nameof(tblPlayerShopInfo));
                if (Id != tblPlayerShopInfo.PlayerShopInfoId)
                {
                    throw new NotImplementedException();
                }

                context.TblPlayerShopInfo.Update(tblPlayerShopInfo);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

         
    }
}
