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
    /// This class have interface methods implementation of ISettingsService
    /// for Get, Get by ID, Create, Update and Delete Settings.
    /// </summary>

    public class SettingsService : ISettingsService
    {
        private readonly FitCareDbContext context;

        public SettingsService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<Settings> Insert(Settings tblSettings)
        {
            try
            {
                context.Add(tblSettings);
                await context.SaveChangesAsync();
                return tblSettings;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<Settings> GetAll()
        {
            try
            {
                return context.TblSettings.Where(s => s.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Settings> GetByID(int playerId)
        {
            try
            {
                return await context.TblSettings.FirstOrDefaultAsync(s => s.PlayerId == playerId && s.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<Settings> Delete(int settingsId)
        {
            try
            { 
                var objSettings = await context.TblSettings.SingleOrDefaultAsync(s => s.SettingsId == settingsId);
                objSettings.IsDeleted = true;
                objSettings.DeletedBy = settingsId;
                objSettings.DeletedDate = DateTime.Now;
                if (objSettings == null)
                    throw new InvalidOperationException();

                context.TblSettings.Update(objSettings);
                await context.SaveChangesAsync();
                return objSettings;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, Settings tblSettings)
        {
            try
            {
                if (tblSettings == null)
                    throw new ArgumentNullException(nameof(tblSettings));
                if (Id != tblSettings.SettingsId)
                {
                    throw new NotImplementedException();
                }
                tblSettings.ModifiedDate = DateTime.Now;
                context.TblSettings.Update(tblSettings);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

         
    }
}
