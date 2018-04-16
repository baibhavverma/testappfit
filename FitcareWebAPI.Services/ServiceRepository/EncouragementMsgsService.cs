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

    public class EncouragementMsgsService : IEncouragementMsgsService
    {
        private readonly FitCareDbContext context;

        public EncouragementMsgsService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<EncouragementMsgs> Insert(EncouragementMsgs tblEncouragementMsgs)
        {
            try
            {
                tblEncouragementMsgs.CreatedDate = DateTime.Now;
                context.Add(tblEncouragementMsgs);
                await context.SaveChangesAsync();
                return tblEncouragementMsgs;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<EncouragementMsgs> GetAll()
        {
            try
            {
                return context.TblEncouragementMsgs.Where(a => a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EncouragementMsgs> GetByID(int id)
        {
            try
            {
                return await context.TblEncouragementMsgs.FirstOrDefaultAsync(a => a.EncouragementMsgId == id && a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<EncouragementMsgs> Delete(int id)
        {
            try
            { 
                var objEncouragementMsgs = await context.TblEncouragementMsgs.SingleOrDefaultAsync(a => a.EncouragementMsgId == id);
                objEncouragementMsgs.IsDeleted = true;
                objEncouragementMsgs.DeletedBy = id;
                objEncouragementMsgs.DeletedDate = DateTime.Now;
                if (objEncouragementMsgs == null)
                    throw new InvalidOperationException();

                context.TblEncouragementMsgs.Update(objEncouragementMsgs);
                await context.SaveChangesAsync();
                return objEncouragementMsgs;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, EncouragementMsgs tblEncouragementMsgs)
        {
            try
            {
                if (tblEncouragementMsgs == null)
                    throw new ArgumentNullException(nameof(tblEncouragementMsgs));
                if (Id != tblEncouragementMsgs.EncouragementMsgId)
                {
                    throw new NotImplementedException();
                }

                context.TblEncouragementMsgs.Update(tblEncouragementMsgs);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

      
    }
}
