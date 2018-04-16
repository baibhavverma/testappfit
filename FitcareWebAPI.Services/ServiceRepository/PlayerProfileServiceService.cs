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
    /// This class have interface methods implementation of IPlayerProfileService
    /// for Get, Get by ID, Create, Update and Delete PlayerProfile.
    /// </summary>
    public class PlayerProfileServiceService : IPlayerProfileService
    {
        private readonly FitCareDbContext context;

        public PlayerProfileServiceService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<PlayerProfile> Insert(PlayerProfile tblPlayerProfile)
        {
            try
            {
                tblPlayerProfile.CreatedDate = DateTime.Now;
                context.Add(tblPlayerProfile);
                await context.SaveChangesAsync();
                return tblPlayerProfile;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<PlayerProfile> GetAll()
        {
            try
            {
                return context.TblPlayerProfile.Where(p => p.IsDeleted == false);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<PlayerProfile> GetByID(int id)
        {
            try
            {
                return await context.TblPlayerProfile.FirstOrDefaultAsync(p => p.PlayerId == id && p.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<PlayerProfile> Delete(int id)
        {
            try
            { 
                var objPlayerProfile = await context.TblPlayerProfile.SingleOrDefaultAsync(p => p.PlayerId == id);
                objPlayerProfile.IsDeleted = true;
                objPlayerProfile.DeletedBy = id;
                objPlayerProfile.DeletedDate = DateTime.Now;
                if (objPlayerProfile == null)
                    throw new InvalidOperationException();

                context.TblPlayerProfile.Update(objPlayerProfile);
                await context.SaveChangesAsync();
                return objPlayerProfile;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, PlayerProfile tblPlayerProfile)
        {
            try
            {
                if (tblPlayerProfile == null)
                    throw new ArgumentNullException(nameof(tblPlayerProfile));
                if (Id != tblPlayerProfile.PlayerId)
                {
                    throw new NotImplementedException();
                }
                tblPlayerProfile.ModifiedDate = DateTime.Now;
                context.TblPlayerProfile.Update(tblPlayerProfile);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
          
        }  
    }
}
