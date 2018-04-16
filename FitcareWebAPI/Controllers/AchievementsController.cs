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
    /// This class contains methods to get Achievement details, delete and insert Achievement,
    /// and change Achievement details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/Achievements")]
    public class AchievementsController : Controller
    {
        private readonly IAchievementsService achievementsService;

        public AchievementsController(IAchievementsService repository)
        {
            this.achievementsService = repository;
        }

        /// <summary>
        /// This action method can be used to get all Achievement details.
        /// </summary> 
        // GET: api/Achievements
        [HttpGet]
        public IEnumerable<Achievement> GetAllAchievement()
        {
            return achievementsService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get Achievement details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/Achievements/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAchievementByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await achievementsService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the Achievement details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblAchievement"></param>
        /// <returns></returns> 
        // PUT: api/Achievements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAchievement([FromRoute] int id, [FromBody] Achievement tblAchievement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblAchievement.AchievementId)
            {
                return BadRequest();
            }

            try
            {
                await achievementsService.Update(id, tblAchievement);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAchievementExists(id))
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
        /// This action method can be used to insert new Achievements
        /// </summary>
        /// <param name="tblAchievement"></param>
        /// <returns></returns> 
        // POST: api/Achievements
        [HttpPost]
        public async Task<IActionResult> InsertAchievement([FromBody] Achievement tblAchievement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }  
            
            var entity = await achievementsService.Insert(tblAchievement);
            if (entity == null)
            {
                return BadRequest();
            } 
            return CreatedAtAction("GetAchievementByID", new { id = tblAchievement.AchievementId }, tblAchievement);
        }

        /// <summary>
        /// This action method used to soft deletes the Achievement Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/Achievements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteAchievement([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await achievementsService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
             
            return Ok(result);
        }

        private bool TblAchievementExists(int id)
        {
            return achievementsService.GetAll().Any(e => e.AchievementId == id);
        }
    }
}