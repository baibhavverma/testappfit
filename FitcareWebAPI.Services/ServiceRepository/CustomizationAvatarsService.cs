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
    /// This class have interface methods implementation of ICustomizationAvatarsService
    /// for Get, Get by ID, Create, Update and Delete CustomizationAvatar.
    /// </summary>

    public class CustomizationAvatarsService : ICustomizationAvatarsService
    {
        private readonly FitCareDbContext context;

        public CustomizationAvatarsService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<CustomizationAvatar> Insert(CustomizationAvatar tblCustomizationAvatar)
        {
            try
            {
                context.Add(tblCustomizationAvatar);
                await context.SaveChangesAsync();
                return tblCustomizationAvatar;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<CustomizationAvatar> GetAll()
        {
            try
            {
                return context.TblCustomizationAvatar.Where(c => c.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CustomizationAvatar> GetByID(int PlayerId)
        {
            try
            {
                return await context.TblCustomizationAvatar.FirstOrDefaultAsync(c => c.CustomizationId == PlayerId && c.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<CustomizationAvatar> Delete(int CustomizationAvatarId)
        {
            try
            { 
                var objCustomizationAvatar = await context.TblCustomizationAvatar.SingleOrDefaultAsync(c => c.CustomizationId == CustomizationAvatarId);
                objCustomizationAvatar.IsDeleted = true;
                objCustomizationAvatar.DeletedBy = CustomizationAvatarId;
                objCustomizationAvatar.DeletedDate = DateTime.Now;
                if (objCustomizationAvatar == null)
                    throw new InvalidOperationException();

                context.TblCustomizationAvatar.Update(objCustomizationAvatar);
                await context.SaveChangesAsync();
                return objCustomizationAvatar;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, CustomizationAvatar tblCustomizationAvatar)
        {
            try
            {
                if (tblCustomizationAvatar == null)
                    throw new ArgumentNullException(nameof(tblCustomizationAvatar));
                if (Id != tblCustomizationAvatar.CustomizationId)
                {
                    throw new NotImplementedException();
                }

                context.TblCustomizationAvatar.Update(tblCustomizationAvatar);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

         
    }
}
