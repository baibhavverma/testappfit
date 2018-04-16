using FitcareWebAPI.Model.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPI.IServices.InterfaceRepository
{
    /// <summary>
    /// Interface for the NotificationMessagesService service class.
    /// </summary>
    public interface INotificationMessagesService
    {
        Task<NotificationMessages> Insert(NotificationMessages tblNotificationMessage);
        IEnumerable<NotificationMessages> GetAll();
        Task<NotificationMessages> GetByID(int PlayerId);
        Task<NotificationMessages> Delete(int NotificationMessageId);
        Task Update(int Id, NotificationMessages tblNotificationMessage);
    }

}
