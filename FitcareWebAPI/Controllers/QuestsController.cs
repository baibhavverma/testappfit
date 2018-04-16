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
    /// This class contains methods to get Quests details, delete and insert Quests,
    /// and change Quests details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/Quests")]
    public class QuestsController : Controller
    {
        
        private readonly IQuestsService questsService;
        public QuestsController(IQuestsService repository)
        {
            this.questsService = repository;
        }

        /// <summary>
        /// This action method can be used to get all Quests details.
        /// </summary> 
        // GET: api/Quests
        [HttpGet]
        public IEnumerable<Quests> GetAllQuests()
        {
            return questsService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get Quests details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/Quests/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestsByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await questsService.GetByID(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the Quests details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblQuests"></param>
        /// <returns></returns> 
        // PUT: api/Quests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuests([FromRoute] int id, [FromBody] Quests tblQuests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblQuests.QuestId)
            {
                return BadRequest();
            }

            try
            {
                await questsService.Update(id, tblQuests);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblQuestsExists(id))
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
        /// This action method can be used to insert new Quests
        /// </summary>
        /// <param name="tblQuests"></param>
        /// <returns></returns>
        // POST: api/Quests
        [HttpPost]
        public async Task<IActionResult> InsertQuests([FromBody] Quests tblQuests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var entity = await questsService.Insert(tblQuests);
            if (entity == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetQuestsByID", new { id = tblQuests.QuestId }, tblQuests);
        }

        /// <summary>
        /// This action method used to soft deletes the Quests Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/Quests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteQuests([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await questsService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblQuestsExists(int id)
        {
            return questsService.GetAll().Any(e => e.QuestId == id);
        }
    }
}