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
    /// This class have interface methods implementation of ICurrentEatingActivityGradesService
    /// for Get, Get by ID, Create, Update and Delete CurrentEatingActivityGrade.
    /// </summary>

    public class CurrentEatingActivityGradesService : ICurrentEatingActivityGradesService
    {
        private readonly FitCareDbContext context;

        public CurrentEatingActivityGradesService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<CurrentEatingActivityGrade> Insert(CurrentEatingActivityGrade tblCurrentEatingActivityGrade)
        {
            try
            {
                tblCurrentEatingActivityGrade.CreatedDate = DateTime.Now;
                context.Add(tblCurrentEatingActivityGrade);
                await context.SaveChangesAsync();
                return tblCurrentEatingActivityGrade;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<CurrentEatingActivityGrade> GetAll()
        {
            try
            {
                return context.TblCurrentEatingActivityGrade.Where(c => c.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CurrentEatingActivityGrade> GetByID(int PlayerId)
        {
            try
            {
                return await context.TblCurrentEatingActivityGrade.FirstOrDefaultAsync(c => c.CurrentEatingActivityGradeId == PlayerId && c.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<CurrentEatingActivityGrade> Delete(int currentEatingActivityGradeId)
        {
            try
            { 
                var objCurrentEatingActivityGrade = await context.TblCurrentEatingActivityGrade.SingleOrDefaultAsync(c => c.CurrentEatingActivityGradeId == currentEatingActivityGradeId);
                objCurrentEatingActivityGrade.IsDeleted = true;
                objCurrentEatingActivityGrade.DeletedBy = currentEatingActivityGradeId;
                objCurrentEatingActivityGrade.DeletedDate = DateTime.Now;
                if (objCurrentEatingActivityGrade == null)
                    throw new InvalidOperationException();

                context.TblCurrentEatingActivityGrade.Update(objCurrentEatingActivityGrade);
                await context.SaveChangesAsync();
                return objCurrentEatingActivityGrade;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, CurrentEatingActivityGrade tblCurrentEatingActivityGrade)
        {
            try
            {
                if (tblCurrentEatingActivityGrade == null)
                    throw new ArgumentNullException(nameof(tblCurrentEatingActivityGrade));
                if (Id != tblCurrentEatingActivityGrade.CurrentEatingActivityGradeId)
                {
                    throw new NotImplementedException();
                }
                tblCurrentEatingActivityGrade.ModifiedDate = DateTime.Now;
                context.TblCurrentEatingActivityGrade.Update(tblCurrentEatingActivityGrade);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
         
    }
}
