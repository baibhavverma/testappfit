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
    /// This class have interface methods implementation of IPlayerQuestInfoesService
    /// for Get, Get by ID, Create, Update and Delete PlayerQuestInfo.
    /// </summary>

    public class PlayerQuestInfoesService : IPlayerQuestInfoesService
    {
        private readonly FitCareDbContext context;

        public PlayerQuestInfoesService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<PlayerQuestInfo> Insert(PlayerQuestInfo tblPlayerQuestInfo)
        {
            try
            {
                context.Add(tblPlayerQuestInfo);
                await context.SaveChangesAsync();
                return tblPlayerQuestInfo;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<PlayerQuestInfo> GetAll()
        {
            try
            {
                return context.TblPlayerQuestInfo.Where(q => q.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PlayerQuestInfo> GetByID(int playerId)
        {
            try
            {
                return await context.TblPlayerQuestInfo.FirstOrDefaultAsync(q => q.PlayerId == playerId && q.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<PlayerQuestInfo> Delete(int playerQuestInfoId)
        {
            try
            { 
                var objPlayerQuestInfo = await context.TblPlayerQuestInfo.SingleOrDefaultAsync(q => q.PlayerQuestInfoId == playerQuestInfoId);
                objPlayerQuestInfo.IsDeleted = true;
                objPlayerQuestInfo.DeletedBy = playerQuestInfoId;
                objPlayerQuestInfo.DeletedDate = DateTime.Now;
                if (objPlayerQuestInfo == null)
                    throw new InvalidOperationException();

                context.TblPlayerQuestInfo.Update(objPlayerQuestInfo);
                await context.SaveChangesAsync();
                return objPlayerQuestInfo;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, PlayerQuestInfo tblPlayerQuestInfo)
        {
            try
            {
                if (tblPlayerQuestInfo == null)
                    throw new ArgumentNullException(nameof(tblPlayerQuestInfo));
                if (Id != tblPlayerQuestInfo.PlayerQuestInfoId)
                {
                    throw new NotImplementedException();
                }

                context.TblPlayerQuestInfo.Update(tblPlayerQuestInfo);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

         
    }
}
