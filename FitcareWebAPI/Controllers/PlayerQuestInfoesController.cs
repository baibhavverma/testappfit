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
    /// This class contains methods to get PlayerQuestInfoes details, delete and insert PlayerQuestInfoes,
    /// and change PlayerQuestInfoes details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/PlayerQuestInfoes")]
    public class PlayerQuestInfoesController : Controller
    {
        
        private readonly IPlayerQuestInfoesService playerQuestInfoesService;
        public PlayerQuestInfoesController(IPlayerQuestInfoesService repository)
        {
            this.playerQuestInfoesService = repository;
        }

        /// <summary>
        /// This action method can be used to get all PlayerQuestInfoes details.
        /// </summary> 
        // GET: api/PlayerQuestInfoes
        [HttpGet]
        public IEnumerable<PlayerQuestInfo> GetAllPlayerQuestInfo()
        {
            return playerQuestInfoesService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get PlayerQuestInfoes details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/PlayerQuestInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerQuestInfoByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await playerQuestInfoesService.GetByID(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the PlayerQuestInfoes details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblPlayerQuestInfo"></param>
        /// <returns></returns> 
        // PUT: api/PlayerQuestInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayerQuestInfo([FromRoute] int id, [FromBody] PlayerQuestInfo tblPlayerQuestInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblPlayerQuestInfo.PlayerQuestInfoId)
            {
                return BadRequest();
            }

            try
            {
                await playerQuestInfoesService.Update(id, tblPlayerQuestInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPlayerQuestInfoExists(id))
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
        /// This action method can be used to insert new PlayerQuestInfoes
        /// </summary>
        /// <param name="tblPlayerQuestInfo"></param>
        /// <returns></returns>
        // POST: api/PlayerQuestInfoes
        [HttpPost]
        public async Task<IActionResult> InsertPlayerQuestInfo([FromBody] PlayerQuestInfo tblPlayerQuestInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            var entity = await playerQuestInfoesService.Insert(tblPlayerQuestInfo);
            if (entity == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetPlayerQuestInfoByID", new { id = tblPlayerQuestInfo.PlayerQuestInfoId }, tblPlayerQuestInfo);
        }

        /// <summary>
        /// This action method used to soft deletes the PlayerQuestInfoes Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/PlayerQuestInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeletePlayerQuestInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await playerQuestInfoesService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblPlayerQuestInfoExists(int id)
        {
            return playerQuestInfoesService.GetAll().Any(e => e.PlayerQuestInfoId == id);
        }
    }
}