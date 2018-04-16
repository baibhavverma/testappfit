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
    /// This class have interface methods implementation of IPlayerAchievementInfoesService
    /// for Get, Get by ID, Create, Update and Delete PlayerAchievementInfo.
    /// </summary>

    public class PlayerAchievementInfoesService : IPlayerAchievementInfoesService
    {
        private readonly FitCareDbContext context;

        public PlayerAchievementInfoesService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<PlayerAchievementInfo> Insert(PlayerAchievementInfo tblPlayerAchievementInfo)
        {
            try
            {
                context.Add(tblPlayerAchievementInfo);
                await context.SaveChangesAsync();
                return tblPlayerAchievementInfo;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<PlayerAchievementInfo> GetAll()
        {
            try
            {
                return context.TblPlayerAchievementInfo.Where(a => a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PlayerAchievementInfo> GetByID(int PlayerId)
        {
            try
            {
                return await context.TblPlayerAchievementInfo.FirstOrDefaultAsync(a => a.AchievementInfoId == PlayerId && a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<PlayerAchievementInfo> Delete(int AchievementInfoId)
        {
            try
            { 
                var objPlayerAchievementInfo = await context.TblPlayerAchievementInfo.SingleOrDefaultAsync(a => a.AchievementInfoId == AchievementInfoId);
                objPlayerAchievementInfo.IsDeleted = true;
                objPlayerAchievementInfo.DeletedBy = AchievementInfoId;
                objPlayerAchievementInfo.DeletedDate = DateTime.Now;
                if (objPlayerAchievementInfo == null)
                    throw new InvalidOperationException();

                context.TblPlayerAchievementInfo.Update(objPlayerAchievementInfo);
                await context.SaveChangesAsync();
                return objPlayerAchievementInfo;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, PlayerAchievementInfo tblPlayerAchievementInfo)
        {
            try
            {
                if (tblPlayerAchievementInfo == null)
                    throw new ArgumentNullException(nameof(tblPlayerAchievementInfo));
                if (Id != tblPlayerAchievementInfo.AchievementInfoId)
                {
                    throw new NotImplementedException();
                }

                context.TblPlayerAchievementInfo.Update(tblPlayerAchievementInfo);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

         
    }
}
