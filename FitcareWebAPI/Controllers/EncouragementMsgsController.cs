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
    /// This class contains methods to get EncouragementMsgs details, delete and insert EncouragementMsgs,
    /// and change EncouragementMsgs details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/EncouragementMsgs")]
    public class EncouragementMsgsController : Controller
    {
        private readonly IEncouragementMsgsService encouragementMsgsService;

        public EncouragementMsgsController(IEncouragementMsgsService repository)
        {
            this.encouragementMsgsService = repository;
        }

        /// <summary>
        /// This action method can be used to get all EncouragementMsgs details.
        /// </summary> 
        // GET: api/EncouragementMsgs
        [HttpGet]
        public IEnumerable<EncouragementMsgs> GetAllEncouragementMsgs()
        {
            return encouragementMsgsService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get EncouragementMsgs details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/EncouragementMsgs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEncouragementMsgsByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await encouragementMsgsService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the EncouragementMsgs details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="encouragementMsgs"></param>
        /// <returns></returns> 
        // PUT: api/EncouragementMsgs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEncouragementMsgs([FromRoute] int id, [FromBody] EncouragementMsgs encouragementMsgs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != encouragementMsgs.EncouragementMsgId)
            {
                return BadRequest();
            }

            try
            {
                await encouragementMsgsService.Update(id, encouragementMsgs);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncouragementMsgsExists(id))
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
        /// This action method can be used to insert new EncouragementMsgs
        /// </summary>
        /// <param name="encouragementMsgs"></param>
        /// <returns></returns> 
        // POST: api/EncouragementMsgs
        [HttpPost]
        public async Task<IActionResult> PostEncouragementMsgs([FromBody] EncouragementMsgs encouragementMsgs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await encouragementMsgsService.Insert(encouragementMsgs);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetEncouragementMsgsByID", new { id = encouragementMsgs.EncouragementMsgId }, encouragementMsgs);
        }

        /// <summary>
        /// This action method used to soft deletes the EncouragementMsgs Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/EncouragementMsgs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncouragementMsgs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await encouragementMsgsService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool EncouragementMsgsExists(int id)
        {
            return encouragementMsgsService.GetAll().Any(e => e.EncouragementMsgId == id);
        }
    }
}