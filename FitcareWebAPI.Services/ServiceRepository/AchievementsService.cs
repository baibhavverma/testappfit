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
    /// This class have interface methods implementation of IAchievementsService
    /// for Get, Get by ID, Create, Update and Delete Achievements.
    /// </summary>

    public class AchievementsService : IAchievementsService
    {
        private readonly FitCareDbContext context;

        public AchievementsService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<Achievement> Insert(Achievement tblAchievement)
        {
            try
            {
                tblAchievement.CreatedDate = DateTime.Now;
                context.Add(tblAchievement);
                await context.SaveChangesAsync();
                return tblAchievement;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<Achievement> GetAll()
        {
            try
            {
                return context.TblAchievement.Where(a => a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Achievement> GetByID(int id)
        {
            try
            {
                return await context.TblAchievement.FirstOrDefaultAsync(a => a.AchievementId == id && a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<Achievement> Delete(int id)
        {
            try
            { 
                var objAchievement = await context.TblAchievement.SingleOrDefaultAsync(a => a.AchievementId == id);
                objAchievement.IsDeleted = true;
                objAchievement.DeletedBy = id;
                objAchievement.DeletedDate = DateTime.Now;
                if (objAchievement == null)
                    throw new InvalidOperationException();

                context.TblAchievement.Update(objAchievement);
                await context.SaveChangesAsync();
                return objAchievement;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, Achievement tblAchievement)
        {
            try
            {
                if (tblAchievement == null)
                    throw new ArgumentNullException(nameof(tblAchievement));
                if (Id != tblAchievement.AchievementId)
                {
                    throw new NotImplementedException();
                }

                context.TblAchievement.Update(tblAchievement);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

      
    }
}
