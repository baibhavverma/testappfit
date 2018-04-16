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
    /// This class have interface methods implementation of INotificationMessagesService
    /// for Get, Get by ID, Create, Update and Delete NotificationMessages.
    /// </summary>

    public class NotificationMessagesService : INotificationMessagesService
    {
        private readonly FitCareDbContext context;

        public NotificationMessagesService(FitCareDbContext context)
        {
            this.context = context;
        }

        public async Task<NotificationMessages> Insert(NotificationMessages tblNotificationMessage)
        {
            try
            {
                tblNotificationMessage.CreatedDate = DateTime.Now;
                context.Add(tblNotificationMessage);
                await context.SaveChangesAsync();
                return tblNotificationMessage;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<NotificationMessages> GetAll()
        {
            try
            {
                return context.TblNotificationMessage.Where(n => n.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<NotificationMessages> GetByID(int PlayerId)
        {
            try
            {
                return await context.TblNotificationMessage.FirstOrDefaultAsync(n => n.NotificationMessageId == PlayerId && n.IsDeleted == false);

            }
            catch (Exception)
            {

                throw;
            }
        }
         
        public async Task<NotificationMessages> Delete(int NotificationMessageId)
        {
            try
            { 
                var objNotificationMessage = await context.TblNotificationMessage.SingleOrDefaultAsync(n => n.NotificationMessageId == NotificationMessageId);
                objNotificationMessage.IsDeleted = true;
                objNotificationMessage.DeletedBy = NotificationMessageId;
                objNotificationMessage.DeletedDate = DateTime.Now;
                if (objNotificationMessage == null)
                    throw new InvalidOperationException();

                context.TblNotificationMessage.Update(objNotificationMessage);
                await context.SaveChangesAsync();
                return objNotificationMessage;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task Update(int Id, NotificationMessages tblNotificationMessage)
        {
            try
            {
                if (tblNotificationMessage == null)
                    throw new ArgumentNullException(nameof(tblNotificationMessage));
                if (Id != tblNotificationMessage.NotificationMessageId)
                {
                    throw new NotImplementedException();
                }
                tblNotificationMessage.ModifiedDate = DateTime.Now;
                context.TblNotificationMessage.Update(tblNotificationMessage);
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

         
    }
}
