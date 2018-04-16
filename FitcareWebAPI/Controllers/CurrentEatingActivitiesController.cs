using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitcareWebAPI.Model.Model.DB;
using FitcareWebAPI.IServices.InterfaceRepository;
using Microsoft.AspNetCore.Authorization;

namespace FitcareWebAPI.Controllers
{
    /// <summary>
    /// This class contains methods to get CurrentEatingActivities details, delete and insert CurrentEatingActivities,
    /// and change CurrentEatingActivities details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/CurrentEatingActivities")]
    public class CurrentEatingActivitiesController : Controller
    {
        private readonly ICurrentEatingActivitiesService currentEatingActivitiesService;

        public CurrentEatingActivitiesController(ICurrentEatingActivitiesService repository)
        {
            this.currentEatingActivitiesService = repository;
        }

        /// <summary>
        /// This action method can be used to get all CurrentEatingActivities details.
        /// </summary> 
        // GET: api/CurrentEatingActivities
        [HttpGet]
        public IEnumerable<CurrentEatingActivity> GetAllCurrentEatingActivity()
        {
            return currentEatingActivitiesService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get CurrentEatingActivities details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/CurrentEatingActivities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrentEatingActivityByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await currentEatingActivitiesService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the CurrentEatingActivities details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblCurrentEatingActivity"></param>
        /// <returns></returns> 
        // PUT: api/CurrentEatingActivities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurrentEatingActivity([FromRoute] int id, [FromBody] CurrentEatingActivity tblCurrentEatingActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblCurrentEatingActivity.CurrentEatingActivityId)
            {
                return BadRequest();
            }

            try
            {
                await currentEatingActivitiesService.Update(id, tblCurrentEatingActivity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCurrentEatingActivityExists(id))
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
        /// This action method can be used to insert new CurrentEatingActivities
        /// </summary>
        /// <param name="tblCurrentEatingActivity"></param>
        /// <returns></returns>
        // POST: api/CurrentEatingActivities
        [HttpPost]
        public async Task<IActionResult> InsertCurrentEatingActivity([FromBody] CurrentEatingActivity tblCurrentEatingActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            
            var entity = await currentEatingActivitiesService.Insert(tblCurrentEatingActivity);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetCurrentEatingActivityByID", new { id = tblCurrentEatingActivity.CurrentEatingActivityId }, tblCurrentEatingActivity);
        }

        /// <summary>
        /// This action method used to soft deletes the CurrentEatingActivities Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/CurrentEatingActivities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteCurrentEatingActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await currentEatingActivitiesService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblCurrentEatingActivityExists(int id)
        {
            return currentEatingActivitiesService.GetAll().Any(e => e.CurrentEatingActivityId == id);
        }
    }
}