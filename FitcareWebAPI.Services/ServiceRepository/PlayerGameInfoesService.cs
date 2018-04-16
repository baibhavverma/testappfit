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
    /// This class have interface methods implementation of IPlayerGameInfoesService
    /// for Get, Get by ID, Create, Update and Delete PlayerGameInfo.
    /// </summary>

    public class PlayerGameInfoesService : IPlayerGameInfoesService
    {
        private readonly FitCareDbContext context;

        public PlayerGameInfoesService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<PlayerGameInfo> Insert(PlayerGameInfo tblPlayerGameInfo)
        {
            try
            {
                context.Add(tblPlayerGameInfo);
                await context.SaveChangesAsync();
                return tblPlayerGameInfo;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<PlayerGameInfo> GetAll()
        {
            try
            {
                return context.TblPlayerGameInfo.Where(g => g.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PlayerGameInfo> GetByID(int playerId)
        {
            try
            {
                return await context.TblPlayerGameInfo.FirstOrDefaultAsync(g => g.PlayerId == playerId && g.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<PlayerGameInfo> Delete(int playerGameInfoId)
        {
            try
            { 
                var objPlayerGameInfo = await context.TblPlayerGameInfo.SingleOrDefaultAsync(g => g.PlayerGameInfoId == playerGameInfoId);
                objPlayerGameInfo.IsDeleted = true;
                objPlayerGameInfo.DeletedBy = playerGameInfoId;
                objPlayerGameInfo.DeletedDate = DateTime.Now;
                if (objPlayerGameInfo == null)
                    throw new InvalidOperationException();

                context.TblPlayerGameInfo.Update(objPlayerGameInfo);
                await context.SaveChangesAsync();
                return objPlayerGameInfo;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, PlayerGameInfo tblPlayerGameInfo)
        {
            try
            {
                if (tblPlayerGameInfo == null)
                    throw new ArgumentNullException(nameof(tblPlayerGameInfo));
                if (Id != tblPlayerGameInfo.PlayerGameInfoId)
                {
                    throw new NotImplementedException();
                }

                context.TblPlayerGameInfo.Update(tblPlayerGameInfo);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

         
    }
}
