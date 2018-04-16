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
    /// This class have interface methods implementation of IPlayerDetailsService
    /// for Get, Get by ID, Create, Update and Delete PlayerDetails.
    /// </summary>

    public class PlayerDetailsService : IPlayerDetailsService
    {
        private readonly FitCareDbContext context;

        public PlayerDetailsService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<PlayerDetails> Insert(PlayerDetails tblPlayerDetails)
        {
            try
            {
                context.Add(tblPlayerDetails);
                await context.SaveChangesAsync();
                return tblPlayerDetails;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<PlayerDetails> GetAll()
        {
            try
            {
                return context.TblPlayerDetails.Where(d => d.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PlayerDetails> GetByID(int PlayerId)
        {
            try
            {
                return await context.TblPlayerDetails.FirstOrDefaultAsync(d => d.PlayerId == PlayerId && d.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<PlayerDetails> Delete(int playerDetailsId)
        {
            try
            { 
                var objPlayerDetails = await context.TblPlayerDetails.SingleOrDefaultAsync(d => d.PlayerDetailsId == playerDetailsId);
                objPlayerDetails.IsDeleted = true;
                objPlayerDetails.DeletedBy = playerDetailsId;
                objPlayerDetails.DeletedDate = DateTime.Now;
                if (objPlayerDetails == null)
                    throw new InvalidOperationException();

                context.TblPlayerDetails.Update(objPlayerDetails);
                await context.SaveChangesAsync();
                return objPlayerDetails;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, PlayerDetails tblPlayerDetails)
        {
            try
            {
                if (tblPlayerDetails == null)
                    throw new ArgumentNullException(nameof(tblPlayerDetails));
                if (Id != tblPlayerDetails.PlayerDetailsId)
                {
                    throw new NotImplementedException();
                }

                context.TblPlayerDetails.Update(tblPlayerDetails);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

         
    }
}
