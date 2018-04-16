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
    /// This class have interface methods implementation of ITargetPeakHrgradeService
    /// for Get, Get by ID, Create, Update and Delete TargetPeakHrgrade.
    /// </summary>

    public class TargetPeakHrgradeService : ITargetPeakHrgradeService
    {
        private readonly FitCareDbContext context;

        public TargetPeakHrgradeService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<TargetPeakHrgrade> Insert(TargetPeakHrgrade tblTargetPeakHrgrade)
        {
            try
            {
                tblTargetPeakHrgrade.CreatedDate = DateTime.Now;
                context.Add(tblTargetPeakHrgrade);
                await context.SaveChangesAsync();
                return tblTargetPeakHrgrade;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<TargetPeakHrgrade> GetAll()
        {
            try
            {
                return context.TblTargetPeakHrgrade.Where(a => a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TargetPeakHrgrade> GetByID(int id)
        {
            try
            {
                return await context.TblTargetPeakHrgrade.FirstOrDefaultAsync(a => a.TargetPeakHrgradeId == id && a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<TargetPeakHrgrade> Delete(int id)
        {
            try
            { 
                var objTargetPeakHrgrade = await context.TblTargetPeakHrgrade.SingleOrDefaultAsync(a => a.TargetPeakHrgradeId == id);
                objTargetPeakHrgrade.IsDeleted = true;
                objTargetPeakHrgrade.DeletedBy = id;
                objTargetPeakHrgrade.DeletedDate = DateTime.Now;
                if (objTargetPeakHrgrade == null)
                    throw new InvalidOperationException();

                context.TblTargetPeakHrgrade.Update(objTargetPeakHrgrade);
                await context.SaveChangesAsync();
                return objTargetPeakHrgrade;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, TargetPeakHrgrade tblTargetPeakHrgrade)
        {
            try
            {
                if (tblTargetPeakHrgrade == null)
                    throw new ArgumentNullException(nameof(tblTargetPeakHrgrade));
                if (Id != tblTargetPeakHrgrade.TargetPeakHrgradeId)
                {
                    throw new NotImplementedException();
                }

                context.TblTargetPeakHrgrade.Update(tblTargetPeakHrgrade);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

      
    }
}
