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
    /// This class contains methods to get ReinforcementMsgs details, delete and insert ReinforcementMsgs,
    /// and change ReinforcementMsgs details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/ReinforcementMsgs")]
    public class ReinforcementMsgsController : Controller
    {
        private readonly IReinforcementMsgsService reinforcementMsgsService;

        public ReinforcementMsgsController(IReinforcementMsgsService repository)
        {
            this.reinforcementMsgsService = repository;
        }

        /// <summary>
        /// This action method can be used to get all ReinforcementMsgs details.
        /// </summary> 
        // GET: api/ReinforcementMsgs
        [HttpGet]
        public IEnumerable<ReinforcementMsgs> GetAllReinforcementMsgs()
        {
            return reinforcementMsgsService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get ReinforcementMsgs details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/ReinforcementMsgs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReinforcementMsgsByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await reinforcementMsgsService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the ReinforcementMsgs details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reinforcementMsgs"></param>
        /// <returns></returns> 
        // PUT: api/ReinforcementMsgs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReinforcementMsgs([FromRoute] int id, [FromBody] ReinforcementMsgs reinforcementMsgs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reinforcementMsgs.ReinforcementMsgid)
            {
                return BadRequest();
            }

            try
            {
                await reinforcementMsgsService.Update(id, reinforcementMsgs);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReinforcementMsgsExists(id))
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
        /// This action method can be used to insert new ReinforcementMsgs
        /// </summary>
        /// <param name="reinforcementMsgs"></param>
        /// <returns></returns>  
        // POST: api/ReinforcementMsgs
        [HttpPost]
        public async Task<IActionResult> PostReinforcementMsgs([FromBody] ReinforcementMsgs reinforcementMsgs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await reinforcementMsgsService.Insert(reinforcementMsgs);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetReinforcementMsgsByID", new { id = reinforcementMsgs.ReinforcementMsgid }, reinforcementMsgs);
        }

        /// <summary>
        /// This action method used to soft deletes the ReinforcementMsgs Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/ReinforcementMsgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReinforcementMsgs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await reinforcementMsgsService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool ReinforcementMsgsExists(int id)
        {
            return reinforcementMsgsService.GetAll().Any(e => e.ReinforcementMsgid == id);
        }
    }
}