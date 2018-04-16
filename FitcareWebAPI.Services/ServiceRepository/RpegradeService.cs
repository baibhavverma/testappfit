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
    /// This class have interface methods implementation of IRpegradeService
    /// for Get, Get by ID, Create, Update and Delete Rpegrade.
    /// </summary>

    public class RpegradeService : IRpegradeService
    {
        private readonly FitCareDbContext context;

        public RpegradeService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<Rpegrade> Insert(Rpegrade tblRpegrade)
        {
            try
            {
                tblRpegrade.CreatedDate = DateTime.Now;
                context.Add(tblRpegrade);
                await context.SaveChangesAsync();
                return tblRpegrade;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<Rpegrade> GetAll()
        {
            try
            {
                return context.TblRpegrade.Where(a => a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Rpegrade> GetByID(int id)
        {
            try
            {
                return await context.TblRpegrade.FirstOrDefaultAsync(a => a.Rpeid == id && a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<Rpegrade> Delete(int id)
        {
            try
            { 
                var objRpegrade = await context.TblRpegrade.SingleOrDefaultAsync(a => a.Rpeid == id);
                objRpegrade.IsDeleted = true;
                objRpegrade.DeletedBy = id;
                objRpegrade.DeletedDate = DateTime.Now;
                if (objRpegrade == null)
                    throw new InvalidOperationException();

                context.TblRpegrade.Update(objRpegrade);
                await context.SaveChangesAsync();
                return objRpegrade;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, Rpegrade tblRpegrade)
        {
            try
            {
                if (tblRpegrade == null)
                    throw new ArgumentNullException(nameof(tblRpegrade));
                if (Id != tblRpegrade.Rpeid)
                {
                    throw new NotImplementedException();
                }
                tblRpegrade.ModifiedDate = DateTime.Now;
                context.TblRpegrade.Update(tblRpegrade);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

      
    }
}
