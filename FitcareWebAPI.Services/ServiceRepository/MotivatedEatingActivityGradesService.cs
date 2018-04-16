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
    /// This class have interface methods implementation of IMotivatedEatingActivityGradesService
    /// for Get, Get by ID, Create, Update and Delete MotivatedEatingActivityGrade.
    /// </summary>

    public class MotivatedEatingActivityGradesService : IMotivatedEatingActivityGradesService
    {
        private readonly FitCareDbContext context;

        public MotivatedEatingActivityGradesService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<MotivatedEatingActivityGrade> Insert(MotivatedEatingActivityGrade tblMotivatedEatingActivityGrade)
        {
            try
            {
                tblMotivatedEatingActivityGrade.CreatedDate = DateTime.Now;
                context.Add(tblMotivatedEatingActivityGrade);
                await context.SaveChangesAsync();
                return tblMotivatedEatingActivityGrade;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<MotivatedEatingActivityGrade> GetAll()
        {
            try
            {
                return context.TblMotivatedEatingActivityGrade.Where(m => m.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MotivatedEatingActivityGrade> GetByID(int PlayerId)
        {
            try
            {
                return await context.TblMotivatedEatingActivityGrade.FirstOrDefaultAsync(m => m.MotivatedEatingActivityGradeId == PlayerId && m.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<MotivatedEatingActivityGrade> Delete(int MotivatedEatingActivityGradeId)
        {
            try
            { 
                var objMotivatedEatingActivityGrade = await context.TblMotivatedEatingActivityGrade.SingleOrDefaultAsync(c => c.MotivatedEatingActivityGradeId == MotivatedEatingActivityGradeId);
                objMotivatedEatingActivityGrade.IsDeleted = true;
                objMotivatedEatingActivityGrade.DeletedBy = MotivatedEatingActivityGradeId;
                objMotivatedEatingActivityGrade.DeletedDate = DateTime.Now;
                if (objMotivatedEatingActivityGrade == null)
                    throw new InvalidOperationException();

                context.TblMotivatedEatingActivityGrade.Update(objMotivatedEatingActivityGrade);
                await context.SaveChangesAsync();
                return objMotivatedEatingActivityGrade;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, MotivatedEatingActivityGrade tblMotivatedEatingActivityGrade)
        {
            try
            {
                if (tblMotivatedEatingActivityGrade == null)
                    throw new ArgumentNullException(nameof(tblMotivatedEatingActivityGrade));
                if (Id != tblMotivatedEatingActivityGrade.MotivatedEatingActivityGradeId)
                {
                    throw new NotImplementedException();
                }
                tblMotivatedEatingActivityGrade.ModifiedDate = DateTime.Now;
                context.TblMotivatedEatingActivityGrade.Update(tblMotivatedEatingActivityGrade);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
         
    }
}
