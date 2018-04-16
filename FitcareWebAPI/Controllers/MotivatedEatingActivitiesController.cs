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
    /// This class contains methods to get MotivatedEatingActivities details, delete and insert MotivatedEatingActivities,
    /// and change MotivatedEatingActivities details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/MotivatedEatingActivities")]
    public class MotivatedEatingActivitiesController : Controller
    {
        
        private readonly IMotivatedEatingActivitiesService motivatedEatingActivitiesService;

        public MotivatedEatingActivitiesController(IMotivatedEatingActivitiesService repository)
        {
            this.motivatedEatingActivitiesService = repository;
        }

        /// <summary>
        /// This action method can be used to get all MotivatedEatingActivities details.
        /// </summary> 
        // GET: api/MotivatedEatingActivities
        [HttpGet]
        public IEnumerable<MotivatedEatingActivity> GetAllMotivatedEatingActivity()
        {
            return motivatedEatingActivitiesService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get MotivatedEatingActivities details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/MotivatedEatingActivities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetlMotivatedEatingActivityByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await motivatedEatingActivitiesService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the MotivatedEatingActivities details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblMotivatedEatingActivity"></param>
        /// <returns></returns> 
        // PUT: api/MotivatedEatingActivities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblMotivatedEatingActivity([FromRoute] int id, [FromBody] MotivatedEatingActivity tblMotivatedEatingActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblMotivatedEatingActivity.MotivatedEatingActivityId)
            {
                return BadRequest();
            }

            try
            {
                await motivatedEatingActivitiesService.Update(id, tblMotivatedEatingActivity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMotivatedEatingActivityExists(id))
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
        /// This action method can be used to insert new MotivatedEatingActivities
        /// </summary>
        /// <param name="tblMotivatedEatingActivity"></param>
        /// <returns></returns>
        // POST: api/MotivatedEatingActivities
        [HttpPost]
        public async Task<IActionResult> PostTblMotivatedEatingActivity([FromBody] MotivatedEatingActivity tblMotivatedEatingActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            var entity = await motivatedEatingActivitiesService.Insert(tblMotivatedEatingActivity);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetlMotivatedEatingActivityByID", new { id = tblMotivatedEatingActivity.MotivatedEatingActivityId }, tblMotivatedEatingActivity);
        }

        /// <summary>
        /// This action method used to soft deletes the MotivatedEatingActivities Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/MotivatedEatingActivities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblMotivatedEatingActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await motivatedEatingActivitiesService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblMotivatedEatingActivityExists(int id)
        {
            return motivatedEatingActivitiesService.GetAll().Any(e => e.MotivatedEatingActivityId == id);
        }
    }
}