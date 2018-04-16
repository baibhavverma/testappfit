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
    /// This class have interface methods implementation of IPowerUpsService
    /// for Get, Get by ID, Create, Update and Delete PowerUps.
    /// </summary>

    public class PowerUpsService : IPowerUpsService
    {
        private readonly FitCareDbContext context;

        public PowerUpsService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<PowerUps> Insert(PowerUps tblPowerUps)
        {
            try
            { 
                context.Add(tblPowerUps);
                await context.SaveChangesAsync();
                return tblPowerUps;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<PowerUps> GetAll()
        {
            try
            {
                return context.TblPowerUps.Where(p => p.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PowerUps> GetByID(int powerUpId)
        {
            try
            {
                return await context.TblPowerUps.FirstOrDefaultAsync(p => p.PowerUpId == powerUpId && p.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<PowerUps> Delete(int powerUpsId)
        {
            try
            { 
                var objPowerUps = await context.TblPowerUps.SingleOrDefaultAsync(p => p.PowerUpId == powerUpsId);
                objPowerUps.IsDeleted = true;
                objPowerUps.DeletedBy = powerUpsId;
                objPowerUps.DeletedDate = DateTime.Now;
                if (objPowerUps == null)
                    throw new InvalidOperationException();

                context.TblPowerUps.Update(objPowerUps);
                await context.SaveChangesAsync();
                return objPowerUps;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, PowerUps tblPowerUps)
        {
            try
            {
                if (tblPowerUps == null)
                    throw new ArgumentNullException(nameof(tblPowerUps));
                if (Id != tblPowerUps.PowerUpId)
                {
                    throw new NotImplementedException();
                }

                context.TblPowerUps.Update(tblPowerUps);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

         
    }
}
