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
    /// This class have interface methods implementation of ICurrentEatingActivityOptionsService
    /// for Get, Get by ID, Create, Update and Delete CurrentEatingActivityOptions.
    /// </summary>

    public class CurrentEatingActivityOptionsService : ICurrentEatingActivityOptionsService
    {
        private readonly FitCareDbContext context;

        public CurrentEatingActivityOptionsService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<CurrentEatingActivityOptions> Insert(CurrentEatingActivityOptions tblCurrentEatingActivityOptions)
        {
            try
            {
                context.Add(tblCurrentEatingActivityOptions);
                await context.SaveChangesAsync();
                return tblCurrentEatingActivityOptions;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<CurrentEatingActivityOptions> GetAll()
        {
            try
            {
                return context.TblCurrentEatingActivityOptions.Where(c => c.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CurrentEatingActivityOptions> GetByID(int PlayerId)
        {
            try
            {
                return await context.TblCurrentEatingActivityOptions.FirstOrDefaultAsync(c => c.CurrentEatingAcivityOptionsId == PlayerId && c.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<CurrentEatingActivityOptions> Delete(int currentEatingActivityOptionsId)
        {
            try
            { 
                var objCurrentEatingActivityOptions = await context.TblCurrentEatingActivityOptions.SingleOrDefaultAsync(c => c.CurrentEatingAcivityOptionsId == currentEatingActivityOptionsId);
                objCurrentEatingActivityOptions.IsDeleted = true;
                objCurrentEatingActivityOptions.DeletedBy = currentEatingActivityOptionsId;
                objCurrentEatingActivityOptions.DeletedDate = DateTime.Now;
                if (objCurrentEatingActivityOptions == null)
                    throw new InvalidOperationException();

                context.TblCurrentEatingActivityOptions.Update(objCurrentEatingActivityOptions);
                await context.SaveChangesAsync();
                return objCurrentEatingActivityOptions;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, CurrentEatingActivityOptions tblCurrentEatingActivityOptions)
        {
            try
            {
                if (tblCurrentEatingActivityOptions == null)
                    throw new ArgumentNullException(nameof(tblCurrentEatingActivityOptions));
                if (Id != tblCurrentEatingActivityOptions.CurrentEatingAcivityOptionsId)
                {
                    throw new NotImplementedException();
                }

                context.TblCurrentEatingActivityOptions.Update(tblCurrentEatingActivityOptions);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

         
    }
}
