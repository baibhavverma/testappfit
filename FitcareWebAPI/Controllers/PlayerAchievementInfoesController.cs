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
    /// This class contains methods to get PlayerAchievementInfoes details, delete and insert PlayerAchievementInfoes,
    /// and change PlayerAchievementInfoes details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/PlayerAchievementInfoes")]
    public class PlayerAchievementInfoesController : Controller
    {
        
        private readonly IPlayerAchievementInfoesService playerAchievementInfoesService;

        public PlayerAchievementInfoesController(IPlayerAchievementInfoesService repository)
        {
            this.playerAchievementInfoesService = repository;
        }

        /// <summary>
        /// This action method can be used to get all PlayerAchievementInfoes details.
        /// </summary> 
        // GET: api/PlayerAchievementInfoes
        [HttpGet]
        public IEnumerable<PlayerAchievementInfo> GetAllPlayerAchievementInfo()
        {
            return playerAchievementInfoesService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get PlayerAchievementInfoes details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/PlayerAchievementInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerAchievementInfoByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await playerAchievementInfoesService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the PlayerAchievementInfoes details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblPlayerAchievementInfo"></param>
        /// <returns></returns> 
        // PUT: api/PlayerAchievementInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayerAchievementInfo([FromRoute] int id, [FromBody] PlayerAchievementInfo tblPlayerAchievementInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblPlayerAchievementInfo.AchievementInfoId)
            {
                return BadRequest();
            }

            try
            {
                await playerAchievementInfoesService.Update(id, tblPlayerAchievementInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPlayerAchievementInfoExists(id))
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
        /// This action method can be used to insert new PlayerAchievementInfoes
        /// </summary>
        /// <param name="tblPlayerAchievementInfo"></param>
        /// <returns></returns>
        // POST: api/PlayerAchievementInfoes
        [HttpPost]
        public async Task<IActionResult> InsertPlayerAchievementInfo([FromBody] PlayerAchievementInfo tblPlayerAchievementInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // tblCurrentEatingActivityHistory.CreatedDate = DateTime.Now;
            var entity = await playerAchievementInfoesService.Insert(tblPlayerAchievementInfo);
            if (entity == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetPlayerAchievementInfoByID", new { id = tblPlayerAchievementInfo.AchievementInfoId }, tblPlayerAchievementInfo);
        }

        /// <summary>
        /// This action method used to soft deletes the PlayerAchievementInfoes Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/PlayerAchievementInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeletePlayerAchievementInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await playerAchievementInfoesService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblPlayerAchievementInfoExists(int id)
        {
            return playerAchievementInfoesService.GetAll().Any(e => e.AchievementInfoId == id);
        }
    }
}