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
    /// This class have interface methods implementation of IMotivatedEatingActivityHistoriesService
    /// for Get, Get by ID, Create, Update and Delete MotivatedEatingActivityHistory.
    /// </summary>

    public class MotivatedEatingActivityHistoriesService : IMotivatedEatingActivityHistoriesService
    {
        private readonly FitCareDbContext context;

        public MotivatedEatingActivityHistoriesService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<MotivatedEatingActivityHistory> Insert(MotivatedEatingActivityHistory tblMotivatedEatingActivityHistory)
        {
            try
            {
                tblMotivatedEatingActivityHistory.SubmitedDate = DateTime.Now;
                context.Add(tblMotivatedEatingActivityHistory);
                await context.SaveChangesAsync();
                return tblMotivatedEatingActivityHistory;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<MotivatedEatingActivityHistory> GetAll()
        {
            try
            {
                return context.TblMotivatedEatingActivityHistory.Where(c => c.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MotivatedEatingActivityHistory> GetByID(int PlayerId)
        {
            try
            {
                return await context.TblMotivatedEatingActivityHistory.FirstOrDefaultAsync(c => c.MotivatedEatingActivityHistoryId == PlayerId && c.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<MotivatedEatingActivityHistory> Delete(int CurrentEatingActivityHistoryId)
        {
            try
            { 
                var objMotivatedEatingActivityHistory = await context.TblMotivatedEatingActivityHistory.SingleOrDefaultAsync(c => c.MotivatedEatingActivityHistoryId == CurrentEatingActivityHistoryId);
                objMotivatedEatingActivityHistory.IsDeleted = true;
                objMotivatedEatingActivityHistory.DeletedBy = CurrentEatingActivityHistoryId;
                objMotivatedEatingActivityHistory.DeletedDate = DateTime.Now;
                if (objMotivatedEatingActivityHistory == null)
                    throw new InvalidOperationException();

                context.TblMotivatedEatingActivityHistory.Update(objMotivatedEatingActivityHistory);
                await context.SaveChangesAsync();
                return objMotivatedEatingActivityHistory;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, MotivatedEatingActivityHistory tblMotivatedEatingActivityHistory)
        {
            try
            {
                if (tblMotivatedEatingActivityHistory == null)
                    throw new ArgumentNullException(nameof(tblMotivatedEatingActivityHistory));
                if (Id != tblMotivatedEatingActivityHistory.MotivatedEatingActivityHistoryId)
                {
                    throw new NotImplementedException();
                }

                context.TblMotivatedEatingActivityHistory.Update(tblMotivatedEatingActivityHistory);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
 
    }
}
