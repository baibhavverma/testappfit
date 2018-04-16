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
    /// This class have interface methods implementation of IBehavioralTypesService
    /// for Get, Get by ID, Create, Update and Delete BehavioralTypes.
    /// </summary>

    public class BehavioralTypesService : IBehavioralTypesService
    {
        private readonly FitCareDbContext context;

        public BehavioralTypesService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<BehavioralType> Insert(BehavioralType tblBehavioralType)
        {
            try
            { 
                context.Add(tblBehavioralType);
                await context.SaveChangesAsync();
                return tblBehavioralType;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<BehavioralType> GetAll()
        {
            try
            {
                return context.TblType;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BehavioralType> GetByID(int id)
        {
            try
            {
                return await context.TblType.FirstOrDefaultAsync(a => a.TypeId == id);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<BehavioralType> Delete(int id)
        {
            try
            {
                BehavioralType objBehavioralType = new BehavioralType();
                objBehavioralType = await context.TblType.SingleOrDefaultAsync(a => a.TypeId == id);
                //objBehavioralType.IsDeleted = true;
                //objBehavioralType.DeletedBy = id;
                //objBehavioralType.DeletedDate = DateTime.Now;
                if (objBehavioralType == null)
                    throw new InvalidOperationException();

                context.TblType.Update(objBehavioralType);
                await context.SaveChangesAsync();
                return objBehavioralType;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, BehavioralType tblBehavioralType)
        {
            try
            {
                if (tblBehavioralType == null)
                    throw new ArgumentNullException(nameof(tblBehavioralType));
                if (Id != tblBehavioralType.TypeId)
                {
                    throw new NotImplementedException();
                }

                context.TblType.Update(tblBehavioralType);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

      
    }
}
