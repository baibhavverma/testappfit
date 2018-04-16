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
    /// This class contains methods to get TargetPeakHrgrades details, delete and insert TargetPeakHrgrades,
    /// and change TargetPeakHrgrades details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/TargetPeakHrgrades")]
    public class TargetPeakHrgradesController : Controller
    {
        private readonly ITargetPeakHrgradeService targetPeakHrgradeService;

        public TargetPeakHrgradesController(ITargetPeakHrgradeService repository)
        {
            this.targetPeakHrgradeService = repository;
        }

        /// <summary>
        /// This action method can be used to get all TargetPeakHrgrades details.
        /// </summary> 
        // GET: api/TargetPeakHrgrades
        [HttpGet]
        public IEnumerable<TargetPeakHrgrade> GetAllTargetPeakHrgrade()
        {
            return targetPeakHrgradeService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get TargetPeakHrgrades details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/TargetPeakHrgrades/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTargetPeakHrgradeByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await targetPeakHrgradeService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the TargetPeakHrgrades details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="targetPeakHrgrade"></param>
        /// <returns></returns> 
        // PUT: api/TargetPeakHrgrades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTargetPeakHrgrade([FromRoute] int id, [FromBody] TargetPeakHrgrade targetPeakHrgrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != targetPeakHrgrade.TargetPeakHrgradeId)
            {
                return BadRequest();
            }

            try
            {
                await targetPeakHrgradeService.Update(id, targetPeakHrgrade);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TargetPeakHrgradeExists(id))
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
        /// This action method can be used to insert new TargetPeakHrgrades
        /// </summary>
        /// <param name="targetPeakHrgrade"></param>
        /// <returns></returns> 
        // POST: api/TargetPeakHrgrades
        [HttpPost]
        public async Task<IActionResult> PostTargetPeakHrgrade([FromBody] TargetPeakHrgrade targetPeakHrgrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await targetPeakHrgradeService.Insert(targetPeakHrgrade);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetTargetPeakHrgradeByID", new { id = targetPeakHrgrade.TargetPeakHrgradeId }, targetPeakHrgrade);
        }

        /// <summary>
        /// This action method used to soft deletes the TargetPeakHrgrades Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/TargetPeakHrgrades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTargetPeakHrgrade([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await targetPeakHrgradeService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TargetPeakHrgradeExists(int id)
        {
            return targetPeakHrgradeService.GetAll().Any(e => e.TargetPeakHrgradeId == id);
        }
    }
}