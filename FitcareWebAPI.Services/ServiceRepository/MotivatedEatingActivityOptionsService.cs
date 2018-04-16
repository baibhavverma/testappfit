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
    /// This class have interface methods implementation of IMotivatedEatingActivityOptionsService
    /// for Get, Get by ID, Create, Update and Delete MotivatedEatingActivityOptions.
    /// </summary>

    public class MotivatedEatingActivityOptionsService : IMotivatedEatingActivityOptionsService
    {
        private readonly FitCareDbContext context;

        public MotivatedEatingActivityOptionsService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<MotivatedEatingActivityOptions> Insert(MotivatedEatingActivityOptions tblMotivatedEatingActivityOptions)
        {
            try
            {
                //tblMotivatedEatingActivityOptions.SubmitedDate = DateTime.Now;
                context.Add(tblMotivatedEatingActivityOptions);
                await context.SaveChangesAsync();
                return tblMotivatedEatingActivityOptions;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<MotivatedEatingActivityOptions> GetAll()
        {
            try
            {
                return context.TblMotivatedEatingActivityOptions.Where(c => c.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MotivatedEatingActivityOptions> GetByID(int motivatedEatingActivityOptionsId)
        {
            try
            {
                return await context.TblMotivatedEatingActivityOptions.FirstOrDefaultAsync(c => c.MotivatedEatingActivityOptionsId == motivatedEatingActivityOptionsId && c.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<MotivatedEatingActivityOptions> Delete(int MotivatedEatingActivityOptionsId)
        {
            try
            { 
                var objMotivatedEatingActivityOptions = await context.TblMotivatedEatingActivityOptions.SingleOrDefaultAsync(c => c.MotivatedEatingActivityOptionsId == MotivatedEatingActivityOptionsId);
                objMotivatedEatingActivityOptions.IsDeleted = true;
                objMotivatedEatingActivityOptions.DeletedBy = MotivatedEatingActivityOptionsId;
                objMotivatedEatingActivityOptions.DeletedDate = DateTime.Now;
                if (objMotivatedEatingActivityOptions == null)
                    throw new InvalidOperationException();

                context.TblMotivatedEatingActivityOptions.Update(objMotivatedEatingActivityOptions);
                await context.SaveChangesAsync();
                return objMotivatedEatingActivityOptions;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, MotivatedEatingActivityOptions tblMotivatedEatingActivityOptions)
        {
            try
            {
                if (tblMotivatedEatingActivityOptions == null)
                    throw new ArgumentNullException(nameof(tblMotivatedEatingActivityOptions));
                if (Id != tblMotivatedEatingActivityOptions.MotivatedEatingActivityOptionsId)
                {
                    throw new NotImplementedException();
                }

                context.TblMotivatedEatingActivityOptions.Update(tblMotivatedEatingActivityOptions);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
 
    }
}
