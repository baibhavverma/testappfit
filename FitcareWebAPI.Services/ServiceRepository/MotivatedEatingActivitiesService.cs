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
    /// This class have interface methods implementation of IMotivatedEatingActivitiesService
    /// for Get, Get by ID, Create, Update and Delete MotivatedEatingActivity.
    /// </summary>

    public class MotivatedEatingActivitiesService : IMotivatedEatingActivitiesService
    {
        private readonly FitCareDbContext context;

        public MotivatedEatingActivitiesService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<MotivatedEatingActivity> Insert(MotivatedEatingActivity tblMotivatedEatingActivity)
        {
            try
            {
                tblMotivatedEatingActivity.CreatedDate = DateTime.Now;
                context.Add(tblMotivatedEatingActivity);
                await context.SaveChangesAsync();
                return tblMotivatedEatingActivity;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<MotivatedEatingActivity> GetAll()
        {
            try
            {
                return context.TblMotivatedEatingActivity.Where(m => m.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MotivatedEatingActivity> GetByID(int PlayerId)
        {
            try
            {
                return await context.TblMotivatedEatingActivity.FirstOrDefaultAsync(m => m.MotivatedEatingActivityId == PlayerId && m.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<MotivatedEatingActivity> Delete(int MotivatedEatingActivityId)
        {
            try
            { 
                var objMotivatedEatingActivity = await context.TblMotivatedEatingActivity.SingleOrDefaultAsync(m => m.MotivatedEatingActivityId == MotivatedEatingActivityId);
                objMotivatedEatingActivity.IsDeleted = true;
                objMotivatedEatingActivity.DeletedBy = MotivatedEatingActivityId;
                objMotivatedEatingActivity.DeletedDate = DateTime.Now;
                if (objMotivatedEatingActivity == null)
                    throw new InvalidOperationException();

                context.TblMotivatedEatingActivity.Update(objMotivatedEatingActivity);
                await context.SaveChangesAsync();
                return objMotivatedEatingActivity;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, MotivatedEatingActivity tblMotivatedEatingActivity)
        {
            try
            {
                if (tblMotivatedEatingActivity == null)
                    throw new ArgumentNullException(nameof(tblMotivatedEatingActivity));
                if (Id != tblMotivatedEatingActivity.MotivatedEatingActivityId)
                {
                    throw new NotImplementedException();
                }
                tblMotivatedEatingActivity.ModifiedDate = DateTime.Now;
                context.TblMotivatedEatingActivity.Update(tblMotivatedEatingActivity);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

         
    }
}
