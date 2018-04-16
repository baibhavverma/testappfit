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
    /// This class have interface methods implementation of IHeartRateGradeService
    /// for Get, Get by ID, Create, Update and Delete HeartRateGrade.
    /// </summary>

    public class HeartRateGradeService : IHeartRateGradeService
    {
        private readonly FitCareDbContext context;

        public HeartRateGradeService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<HeartRateGrade> Insert(HeartRateGrade tblHeartRateGrade)
        {
            try
            {
                tblHeartRateGrade.CreatedDate = DateTime.Now;
                context.Add(tblHeartRateGrade);
                await context.SaveChangesAsync();
                return tblHeartRateGrade;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<HeartRateGrade> GetAll()
        {
            try
            {
                return context.TblHeartRateGrade.Where(a => a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<HeartRateGrade> GetByID(int id)
        {
            try
            {
                return await context.TblHeartRateGrade.FirstOrDefaultAsync(a => a.HeartRateScaleId == id && a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<HeartRateGrade> Delete(int id)
        {
            try
            { 
                var objHeartRateGrade = await context.TblHeartRateGrade.SingleOrDefaultAsync(a => a.HeartRateScaleId == id);
                objHeartRateGrade.IsDeleted = true;
                objHeartRateGrade.DeletedBy = id;
                objHeartRateGrade.DeletedDate = DateTime.Now;
                if (objHeartRateGrade == null)
                    throw new InvalidOperationException();

                context.TblHeartRateGrade.Update(objHeartRateGrade);
                await context.SaveChangesAsync();
                return objHeartRateGrade;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, HeartRateGrade tblHeartRateGrade)
        {
            try
            {
                if (tblHeartRateGrade == null)
                    throw new ArgumentNullException(nameof(tblHeartRateGrade));
                if (Id != tblHeartRateGrade.HeartRateScaleId)
                {
                    throw new NotImplementedException();
                }

                context.TblHeartRateGrade.Update(tblHeartRateGrade);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

      
    }
}
