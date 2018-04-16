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
    /// This class have interface methods implementation of ICriterionPeriodsService
    /// for Get, Get by ID, Create, Update and Delete CriterionPeriods.
    /// </summary>

    public class CriterionPeriodsService : ICriterionPeriodsService
    {
        private readonly FitCareDbContext context;

        public CriterionPeriodsService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<CriterionPeriods> Insert(CriterionPeriods tblCriterionPeriods)
        {
            try
            {
                tblCriterionPeriods.CreatedDate = DateTime.Now;
                context.Add(tblCriterionPeriods);
                await context.SaveChangesAsync();
                return tblCriterionPeriods;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<CriterionPeriods> GetAll()
        {
            try
            {
                return context.TblCriterionPeriod.Where(a => a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CriterionPeriods> GetByID(int id)
        {
            try
            {
                return await context.TblCriterionPeriod.FirstOrDefaultAsync(a => a.CriterionPeriodId == id && a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<CriterionPeriods> Delete(int id)
        {
            try
            { 
                var objCriterionPeriods = await context.TblCriterionPeriod.SingleOrDefaultAsync(a => a.CriterionPeriodId == id);
                objCriterionPeriods.IsDeleted = true;
                objCriterionPeriods.DeletedBy = id;
                objCriterionPeriods.DeletedDate = DateTime.Now;
                if (objCriterionPeriods == null)
                    throw new InvalidOperationException();

                context.TblCriterionPeriod.Update(objCriterionPeriods);
                await context.SaveChangesAsync();
                return objCriterionPeriods;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, CriterionPeriods tblCriterionPeriods)
        {
            try
            {
                if (tblCriterionPeriods == null)
                    throw new ArgumentNullException(nameof(tblCriterionPeriods));
                if (Id != tblCriterionPeriods.CriterionPeriodId)
                {
                    throw new NotImplementedException();
                }

                context.TblCriterionPeriod.Update(tblCriterionPeriods);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

      
    }
}
