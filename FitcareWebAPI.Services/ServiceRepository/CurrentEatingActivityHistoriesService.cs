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
    /// This class have interface methods implementation of ICurrentEatingActivityHistoriesService
    /// for Get, Get by ID, Create, Update and Delete CurrentEatingActivityHistory.
    /// </summary>

    public class CurrentEatingActivityHistoriesService : ICurrentEatingActivityHistoriesService
    {
        private readonly FitCareDbContext context;

        public CurrentEatingActivityHistoriesService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<CurrentEatingActivityHistory> Insert(CurrentEatingActivityHistory tblCurrentEatingActivityHistory)
        {
            try
            {
                tblCurrentEatingActivityHistory.SubmitedDate = DateTime.Now;
                context.Add(tblCurrentEatingActivityHistory);
                await context.SaveChangesAsync();
                return tblCurrentEatingActivityHistory;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<CurrentEatingActivityHistory> GetAll()
        {
            try
            {
                return context.TblCurrentEatingActivityHistory.Where(c => c.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CurrentEatingActivityHistory> GetByID(int PlayerId)
        {
            try
            {
                return await context.TblCurrentEatingActivityHistory.FirstOrDefaultAsync(c => c.CurrentEatingActivityHistoryId == PlayerId && c.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<CurrentEatingActivityHistory> Delete(int CurrentEatingActivityHistoryId)
        {
            try
            { 
                var objCurrentEatingActivityHistory = await context.TblCurrentEatingActivityHistory.SingleOrDefaultAsync(c => c.CurrentEatingActivityHistoryId == CurrentEatingActivityHistoryId);
                objCurrentEatingActivityHistory.IsDeleted = true;
                objCurrentEatingActivityHistory.DeletedBy = CurrentEatingActivityHistoryId;
                objCurrentEatingActivityHistory.DeletedDate = DateTime.Now;
                if (objCurrentEatingActivityHistory == null)
                    throw new InvalidOperationException();

                context.TblCurrentEatingActivityHistory.Update(objCurrentEatingActivityHistory);
                await context.SaveChangesAsync();
                return objCurrentEatingActivityHistory;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, CurrentEatingActivityHistory tblCurrentEatingActivityHistory)
        {
            try
            {
                if (tblCurrentEatingActivityHistory == null)
                    throw new ArgumentNullException(nameof(tblCurrentEatingActivityHistory));
                if (Id != tblCurrentEatingActivityHistory.CurrentEatingActivityHistoryId)
                {
                    throw new NotImplementedException();
                }

                context.TblCurrentEatingActivityHistory.Update(tblCurrentEatingActivityHistory);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
 
    }
}
