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
    /// This class contains methods to get PowerUps details, delete and insert PowerUps,
    /// and change PowerUps details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/PowerUps")]
    public class PowerUpsController : Controller
    {
        
        private readonly IPowerUpsService powerUpsService;
        public PowerUpsController(IPowerUpsService repository)
        {
            this.powerUpsService = repository;
        }

        /// <summary>
        /// This action method can be used to get all PowerUps details.
        /// </summary> 
        // GET: api/PowerUps
        [HttpGet]
        public IEnumerable<PowerUps> GetAllPowerUps()
        {
            return powerUpsService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get PowerUps details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/PowerUps/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPowerUpsByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await powerUpsService.GetByID(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the PowerUps details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblPowerUps"></param>
        /// <returns></returns> 
        // PUT: api/PowerUps/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePowerUps([FromRoute] int id, [FromBody] PowerUps tblPowerUps)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblPowerUps.PowerUpId)
            {
                return BadRequest();
            }

            try
            {
                await powerUpsService.Update(id, tblPowerUps);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPowerUpsExists(id))
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
        /// This action method can be used to insert new PowerUps
        /// </summary>
        /// <param name="tblPowerUps"></param>
        /// <returns></returns>
        // POST: api/PowerUps
        [HttpPost]
        public async Task<IActionResult> InsertPowerUps([FromBody] PowerUps tblPowerUps)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            var entity = await powerUpsService.Insert(tblPowerUps);
            if (entity == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetPowerUpsByID", new { id = tblPowerUps.PowerUpId }, tblPowerUps);
        }

        /// <summary>
        /// This action method used to soft deletes the PowerUps Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/PowerUps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeletePowerUps([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await powerUpsService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblPowerUpsExists(int id)
        {
            return powerUpsService.GetAll().Any(e => e.PowerUpId == id);
        }
    }
}