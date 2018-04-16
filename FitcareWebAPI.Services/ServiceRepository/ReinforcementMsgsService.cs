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
    /// This class have interface methods implementation of IReinforcementMsgsService
    /// for Get, Get by ID, Create, Update and Delete ReinforcementMsgs.
    /// </summary>

    public class ReinforcementMsgsService : IReinforcementMsgsService
    {
        private readonly FitCareDbContext context;

        public ReinforcementMsgsService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<ReinforcementMsgs> Insert(ReinforcementMsgs tblReinforcementMsgs)
        {
            try
            {
                tblReinforcementMsgs.CreatedDate = DateTime.Now;
                context.Add(tblReinforcementMsgs);
                await context.SaveChangesAsync();
                return tblReinforcementMsgs;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<ReinforcementMsgs> GetAll()
        {
            try
            {
                return context.TblReinforcementMsgs.Where(a => a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ReinforcementMsgs> GetByID(int id)
        {
            try
            {
                return await context.TblReinforcementMsgs.FirstOrDefaultAsync(a => a.ReinforcementMsgid == id && a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<ReinforcementMsgs> Delete(int id)
        {
            try
            { 
                var objReinforcementMsgs = await context.TblReinforcementMsgs.SingleOrDefaultAsync(a => a.ReinforcementMsgid == id);
                objReinforcementMsgs.IsDeleted = true;
                objReinforcementMsgs.DeletedBy = id;
                objReinforcementMsgs.DeletedDate = DateTime.Now;
                if (objReinforcementMsgs == null)
                    throw new InvalidOperationException();

                context.TblReinforcementMsgs.Update(objReinforcementMsgs);
                await context.SaveChangesAsync();
                return objReinforcementMsgs;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, ReinforcementMsgs tblReinforcementMsgs)
        {
            try
            {
                if (tblReinforcementMsgs == null)
                    throw new ArgumentNullException(nameof(tblReinforcementMsgs));
                if (Id != tblReinforcementMsgs.ReinforcementMsgid)
                {
                    throw new NotImplementedException();
                }
                tblReinforcementMsgs.ModifiedDate = DateTime.Now;
                context.TblReinforcementMsgs.Update(tblReinforcementMsgs);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

      
    }
}
