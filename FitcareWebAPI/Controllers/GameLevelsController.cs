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
    /// This class contains methods to get GameLevels details, delete and insert GameLevels,
    /// and change GameLevels details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/GameLevels")]
    public class GameLevelsController : Controller
    {
        private readonly IGameLevelsService gameLevelsService;

        public GameLevelsController(IGameLevelsService repository)
        {
            this.gameLevelsService = repository;
        }

        /// <summary>
        /// This action method can be used to get all GameLevels details.
        /// </summary> 
        // GET: api/GameLevels
        [HttpGet]
        public IEnumerable<GameLevel> GetAllGameLevel()
        {
            return gameLevelsService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get GameLevels details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/GameLevels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameLevelByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await gameLevelsService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the GameLevels details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblGameLevel"></param>
        /// <returns></returns> 
        // PUT: api/GameLevels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGameLevel([FromRoute] int id, [FromBody] GameLevel tblGameLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblGameLevel.GameLevelId)
            {
                return BadRequest();
            }

            try
            {
                await gameLevelsService.Update(id, tblGameLevel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblGameLevelExists(id))
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
        /// This action method can be used to insert new GameLevels
        /// </summary>
        /// <param name="tblGameLevel"></param>
        /// <returns></returns>
        // POST: api/GameLevels
        [HttpPost]
        public async Task<IActionResult> InsertGameLevel([FromBody] GameLevel tblGameLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            var entity = await gameLevelsService.Insert(tblGameLevel);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetGameLevelByID", new { id = tblGameLevel.GameLevelId }, tblGameLevel);
        }

        /// <summary>
        /// This action method used to soft deletes the GameLevels Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/GameLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteGameLevel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await gameLevelsService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblGameLevelExists(int id)
        {
            return gameLevelsService.GetAll().Any(e => e.GameLevelId == id);
        }
    }
}