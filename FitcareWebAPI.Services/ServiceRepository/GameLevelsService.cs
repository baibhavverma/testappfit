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
    /// This class have interface methods implementation of IGameLevelsService
    /// for Get, Get by ID, Create, Update and Delete GameLevel.
    /// </summary>

    public class GameLevelsService : IGameLevelsService
    {
        private readonly FitCareDbContext context;

        public GameLevelsService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<GameLevel> Insert(GameLevel tblGameLevel)
        {
            try
            {
                tblGameLevel.CreatedDate = DateTime.Now;
                context.Add(tblGameLevel);
                await context.SaveChangesAsync();
                return tblGameLevel;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<GameLevel> GetAll()
        {
            try
            {
                return context.TblGameLevel.Where(g => g.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<GameLevel> GetByID(int gameLevelId)
        {
            try
            {
                return await context.TblGameLevel.FirstOrDefaultAsync(g => g.GameLevelId == gameLevelId && g.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<GameLevel> Delete(int gameLevelId)
        {
            try
            { 
                var objGameLevel = await context.TblGameLevel.SingleOrDefaultAsync(g => g.GameLevelId == gameLevelId);
                objGameLevel.IsDeleted = true;
                objGameLevel.DeletedBy = gameLevelId;
                objGameLevel.DeletedDate = DateTime.Now;
                if (objGameLevel == null)
                    throw new InvalidOperationException();

                context.TblGameLevel.Update(objGameLevel);
                await context.SaveChangesAsync();
                return objGameLevel;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, GameLevel tblGameLevel)
        {
            try
            {
                if (tblGameLevel == null)
                    throw new ArgumentNullException(nameof(tblGameLevel));
                if (Id != tblGameLevel.GameLevelId)
                {
                    throw new NotImplementedException();
                }

                context.TblGameLevel.Update(tblGameLevel);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

      
    }
}
