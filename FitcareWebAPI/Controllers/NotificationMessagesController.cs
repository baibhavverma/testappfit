using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitcareWebAPI.Model.Model.DB;
using Microsoft.AspNetCore.Authorization;
using FitcareWebAPI.IServices.InterfaceRepository;

namespace FitcareWebAPI.Controllers
{
    /// <summary>
    /// This class contains methods to get NotificationMessages details, delete and insert NotificationMessages,
    /// and change NotificationMessages details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/NotificationMessages")]
    public class NotificationMessagesController : Controller
    {
        
        private readonly INotificationMessagesService notificationMessagesService;

        public NotificationMessagesController(INotificationMessagesService repository)
        {
            this.notificationMessagesService = repository;
        }

        /// <summary>
        /// This action method can be used to get all NotificationMessages details.
        /// </summary> 
        // GET: api/NotificationMessages
        [HttpGet]
        public IEnumerable<NotificationMessages> GetAllNotificationMessage()
        {
            return notificationMessagesService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get NotificationMessages details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/NotificationMessages/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotificationMessageByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await notificationMessagesService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the NotificationMessages details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblNotificationMessage"></param>
        /// <returns></returns> 
        // PUT: api/NotificationMessages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotificationMessage([FromRoute] int id, [FromBody] NotificationMessages tblNotificationMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblNotificationMessage.NotificationMessageId)
            {
                return BadRequest();
            }

            try
            {
                await notificationMessagesService.Update(id, tblNotificationMessage);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblNotificationMessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// This action method can be used to insert new NotificationMessages
        /// </summary>
        /// <param name="tblNotificationMessage"></param>
        /// <returns></returns>
        // POST: api/NotificationMessages
        [HttpPost]
        public async Task<IActionResult> InsertNotificationMessage([FromBody] NotificationMessages tblNotificationMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            var entity = await notificationMessagesService.Insert(tblNotificationMessage);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetNotificationMessageByID", new { id = tblNotificationMessage.NotificationMessageId }, tblNotificationMessage);
        }

        /// <summary>
        /// This action method used to soft deletes the NotificationMessages Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/NotificationMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteNotificationMessage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await notificationMessagesService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblNotificationMessageExists(int id)
        {
            return notificationMessagesService.GetAll().Any(e => e.NotificationMessageId == id);
        }
    }
}