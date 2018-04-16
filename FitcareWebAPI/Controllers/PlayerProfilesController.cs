using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FitcareWebAPI.Model.Model.DB;
using Microsoft.AspNetCore.Authorization;
using FitcareWebAPI.IServices.InterfaceRepository;
//using FitcareWebAPI.InterfaceRepository;

namespace FitcareWebAPI.Controllers
{
    /// <summary>
    /// This class contains methods to get PlayerProfiles details, delete and insert PlayerProfiles.
    /// and change PlayerProfiles details.
    /// </summary>
    [Produces("application/json")]
    [Route("api/PlayerProfiles")]
    public class PlayerProfilesController : Controller
    {

        private readonly IPlayerProfileService playerProfileService;
        public PlayerProfilesController(IPlayerProfileService repository)
        {
            this.playerProfileService = repository;
        }

        /// <summary>
        /// This action method can be used to get all PlayerProfiles details.
        /// </summary>
        [Authorize]
        // GET: api/PlayerProfiles
        [HttpGet]
        public IEnumerable<PlayerProfile> GetAllPlayerProfile()
        {
            return playerProfileService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get PlayerProfiles details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        // GET: api/PlayerProfiles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerProfileByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await playerProfileService.GetByID(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the PlayerProfiles details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblPlayerProfile"></param>
        /// <returns></returns>
        [Authorize]
        // PUT: api/PlayerProfiles/
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayerProfile([FromRoute] int id, [FromBody] PlayerProfile tblPlayerProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (tblPlayerProfile == null)
            {
                return NotFound();
            }

            await playerProfileService.Update(id, tblPlayerProfile);
            return new NoContentResult();
        }

        /// <summary>
        /// This action method can be used to insert new PlayerProfiles
        /// </summary>
        /// <param name="tblPlayerProfile"></param>
        /// <returns></returns>
        // POST: api/PlayerProfiles
        [HttpPost]
        public async Task<IActionResult> InsertPlayerProfile([FromBody] PlayerProfile tblPlayerProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var entity = await playerProfileService.Insert(tblPlayerProfile);
            if (entity == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetPlayerProfileByID", new { id = tblPlayerProfile.PlayerId }, tblPlayerProfile);
        }

        /// <summary>
        /// This action method used to soft deletes the PlayerProfiles Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        // DELETE: api/PlayerProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeletePlayerProfile([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await playerProfileService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblPlayerProfileExists(int id)
        {
            return playerProfileService.GetAll().Any(e => e.PlayerId == id);
        }
    }
}