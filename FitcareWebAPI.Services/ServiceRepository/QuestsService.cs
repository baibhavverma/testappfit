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
    /// This class have interface methods implementation of IQuestsService
    /// for Get, Get by ID, Create, Update and Delete Quests.
    /// </summary>

    public class QuestsService : IQuestsService
    {
        private readonly FitCareDbContext context;

        public QuestsService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<Quests> Insert(Quests tblQuests)
        {
            try
            {
                tblQuests.CreatedDate = DateTime.Now;
                context.Add(tblQuests);
                await context.SaveChangesAsync();
                return tblQuests;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<Quests> GetAll()
        {
            try
            {
                return context.TblQuests.Where(q => q.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Quests> GetByID(int questId)
        {
            try
            {
                return await context.TblQuests.FirstOrDefaultAsync(q => q.QuestId == questId && q.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<Quests> Delete(int questId)
        {
            try
            { 
                var objQuests = await context.TblQuests.SingleOrDefaultAsync(q => q.QuestId == questId);
                objQuests.IsDeleted = true;
                objQuests.DeletedBy = questId;
                objQuests.DeletedDate = DateTime.Now;
                if (objQuests == null)
                    throw new InvalidOperationException();

                context.TblQuests.Update(objQuests);
                await context.SaveChangesAsync();
                return objQuests;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, Quests tblQuests)
        {
            try
            {
                if (tblQuests == null)
                    throw new ArgumentNullException(nameof(tblQuests));
                if (Id != tblQuests.QuestId)
                {
                    throw new NotImplementedException();
                }
                tblQuests.ModifiedDate = DateTime.Now;
                context.TblQuests.Update(tblQuests);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

         
    }
}
