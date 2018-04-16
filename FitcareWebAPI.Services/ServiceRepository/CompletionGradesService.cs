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
    /// This class have interface methods implementation of ICompletionGradesService
    /// for Get, Get by ID, Create, Update and Delete CompletionGrade.
    /// </summary>

    public class CompletionGradesService : ICompletionGradesService
    {
        private readonly FitCareDbContext context;

        public CompletionGradesService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<CompletionGrade> Insert(CompletionGrade tblCompletionGrade)
        {
            try
            {
                tblCompletionGrade.CreatedDate = DateTime.Now;
                context.Add(tblCompletionGrade);
                await context.SaveChangesAsync();
                return tblCompletionGrade;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<CompletionGrade> GetAll()
        {
            try
            {
                return context.TblCompletionGrade.Where(a => a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CompletionGrade> GetByID(int id)
        {
            try
            {
                return await context.TblCompletionGrade.FirstOrDefaultAsync(a => a.CompletionGradeId == id && a.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<CompletionGrade> Delete(int id)
        {
            try
            { 
                var objCompletionGrade = await context.TblCompletionGrade.SingleOrDefaultAsync(a => a.CompletionGradeId == id);
                objCompletionGrade.IsDeleted = true;
                objCompletionGrade.DeletedBy = id;
                objCompletionGrade.DeletedDate = DateTime.Now;
                if (objCompletionGrade == null)
                    throw new InvalidOperationException();

                context.TblCompletionGrade.Update(objCompletionGrade);
                await context.SaveChangesAsync();
                return objCompletionGrade;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, CompletionGrade tblCompletionGrade)
        {
            try
            {
                if (tblCompletionGrade == null)
                    throw new ArgumentNullException(nameof(tblCompletionGrade));
                if (Id != tblCompletionGrade.CompletionGradeId)
                {
                    throw new NotImplementedException();
                }
                tblCompletionGrade.ModifiedDate = DateTime.Now;
                context.TblCompletionGrade.Update(tblCompletionGrade);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

      
    }
}
