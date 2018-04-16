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
    /// This class have interface methods implementation of ICurrentEatingActivitiesService
    /// for Get, Get by ID, Create, Update and Delete CurrentEatingActivity.
    /// </summary>

    public class CurrentEatingActivitiesService : ICurrentEatingActivitiesService
    {
        private readonly FitCareDbContext context;

        public CurrentEatingActivitiesService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<CurrentEatingActivity> Insert(CurrentEatingActivity tblCurrentEatingActivity)
        {
            try
            {
                tblCurrentEatingActivity.CreatedDate = DateTime.Now;
                context.Add(tblCurrentEatingActivity);
                await context.SaveChangesAsync();
                return tblCurrentEatingActivity;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<CurrentEatingActivity> GetAll()
        {
            try
            {
                return context.TblCurrentEatingActivity.Where(c => c.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CurrentEatingActivity> GetByID(int id)
        {
            try
            {
                return await context.TblCurrentEatingActivity.FirstOrDefaultAsync(p => p.CurrentEatingActivityId == id && p.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<CurrentEatingActivity> Delete(int id)
        {
            try
            { 
                var objCurrentEatingActivity = await context.TblCurrentEatingActivity.SingleOrDefaultAsync(c => c.CurrentEatingActivityId == id);
                objCurrentEatingActivity.IsDeleted = true;
                objCurrentEatingActivity.DeletedBy = id;
                objCurrentEatingActivity.DeletedDate = DateTime.Now;
                if (objCurrentEatingActivity == null)
                    throw new InvalidOperationException();

                context.TblCurrentEatingActivity.Update(objCurrentEatingActivity);
                await context.SaveChangesAsync();
                return objCurrentEatingActivity;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, CurrentEatingActivity tblCurrentEatingActivity)
        {
            try
            {
                if (tblCurrentEatingActivity == null)
                    throw new ArgumentNullException(nameof(tblCurrentEatingActivity));
                if (Id != tblCurrentEatingActivity.CurrentEatingActivityId)
                {
                    throw new NotImplementedException();
                }
                tblCurrentEatingActivity.ModifiedDate = DateTime.Now;
                context.TblCurrentEatingActivity.Update(tblCurrentEatingActivity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
         
    }
}
