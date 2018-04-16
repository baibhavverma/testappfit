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
    /// This class contains methods to get PlayerDetails details, delete and insert PlayerDetails,
    /// and change PlayerDetails details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/PlayerDetails")]
    public class PlayerDetailsController : Controller
    {
        private readonly IPlayerDetailsService playerDetailsService;

        public PlayerDetailsController(IPlayerDetailsService repository)
        {
            this.playerDetailsService = repository;
        }

        /// <summary>
        /// This action method can be used to get all PlayerDetails details.
        /// </summary> 
        // GET: api/PlayerDetails
        [HttpGet]
        public IEnumerable<PlayerDetails> GetAllPlayerDetails()
        {
            return playerDetailsService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get PlayerDetails details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/PlayerDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerDetailsByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await playerDetailsService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the PlayerDetails details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblPlayerDetails"></param>
        /// <returns></returns> 
        // PUT: api/PlayerDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayerDetails([FromRoute] int id, [FromBody] PlayerDetails tblPlayerDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblPlayerDetails.PlayerDetailsId)
            {
                return BadRequest();
            }

            try
            {
                await playerDetailsService.Update(id, tblPlayerDetails);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPlayerDetailsExists(id))
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
        /// This action method can be used to insert new PlayerDetails
        /// </summary>
        /// <param name="tblPlayerDetails"></param>
        /// <returns></returns>
        // POST: api/PlayerDetails
        [HttpPost]
        public async Task<IActionResult> InsertPlayerDetails([FromBody] PlayerDetails tblPlayerDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            var entity = await playerDetailsService.Insert(tblPlayerDetails);
            if (entity == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetPlayerDetailsByID", new { id = tblPlayerDetails.PlayerDetailsId }, tblPlayerDetails);
        }

        /// <summary>
        /// This action method used to soft deletes the PlayerDetails Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/PlayerDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeletePlayerDetails([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await playerDetailsService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblPlayerDetailsExists(int id)
        {
            return playerDetailsService.GetAll().Any(e => e.PlayerDetailsId == id);
        }
    }
}