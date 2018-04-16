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
    /// This class contains methods to get PlayerGameInfoes details, delete and insert PlayerGameInfoes,
    /// and change PlayerGameInfoes details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/PlayerGameInfoes")]
    public class PlayerGameInfoesController : Controller
    {
        private readonly IPlayerGameInfoesService playerGameInfoesService;

        public PlayerGameInfoesController(IPlayerGameInfoesService repository)
        {
            this.playerGameInfoesService = repository;
        }

        /// <summary>
        /// This action method can be used to get all PlayerGameInfoes details.
        /// </summary> 
        // GET: api/PlayerGameInfoes
        [HttpGet]
        public IEnumerable<PlayerGameInfo> GetAllPlayerGameInfo()
        {
            return playerGameInfoesService.GetAll();

        }

        /// <summary>
        /// This action method can be used to get PlayerGameInfoes details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/PlayerGameInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerGameInfoByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await playerGameInfoesService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the PlayerGameInfoes details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblPlayerGameInfo"></param>
        /// <returns></returns> 
        // PUT: api/PlayerGameInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayerGameInfo([FromRoute] int id, [FromBody] PlayerGameInfo tblPlayerGameInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblPlayerGameInfo.PlayerGameInfoId)
            {
                return BadRequest();
            }

            try
            {
                await playerGameInfoesService.Update(id, tblPlayerGameInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPlayerGameInfoExists(id))
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
        /// This action method can be used to insert new PlayerGameInfoes
        /// </summary>
        /// <param name="tblPlayerGameInfo"></param>
        /// <returns></returns>
        // POST: api/PlayerGameInfoes
        [HttpPost]
        public async Task<IActionResult> InsertPlayerGameInfo([FromBody] PlayerGameInfo tblPlayerGameInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            var entity = await playerGameInfoesService.Insert(tblPlayerGameInfo);
            if (entity == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetPlayerGameInfoByID", new { id = tblPlayerGameInfo.PlayerGameInfoId }, tblPlayerGameInfo);
        }

        /// <summary>
        /// This action method used to soft deletes the PlayerGameInfoes Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/PlayerGameInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeletePlayerGameInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await playerGameInfoesService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblPlayerGameInfoExists(int id)
        {
            return playerGameInfoesService.GetAll().Any(e => e.PlayerGameInfoId == id);
        }
    }
}