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
    /// This class contains methods to get CurrentEatingActivityOptions details, delete and insert CurrentEatingActivityOptions,
    /// and change CurrentEatingActivityOptions details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/CurrentEatingActivityOptions")]
    public class CurrentEatingActivityOptionsController : Controller
    {
        
        private readonly ICurrentEatingActivityOptionsService currentEatingActivityOptionsService;

        public CurrentEatingActivityOptionsController(ICurrentEatingActivityOptionsService repository)
        {
            this.currentEatingActivityOptionsService = repository;
        }

        /// <summary>
        /// This action method can be used to get all CurrentEatingActivityOptions details.
        /// </summary>
        // GET: api/CurrentEatingActivityOptions 
        [HttpGet]
        public IEnumerable<CurrentEatingActivityOptions> GetAllCurrentEatingActivityOptions()
        {
            return currentEatingActivityOptionsService.GetAll();

        }

        /// <summary>
        /// This action method can be used to get CurrentEatingActivityOptions details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/CurrentEatingActivityOptions/5 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrentEatingActivityOptionsByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await currentEatingActivityOptionsService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the CurrentEatingActivityOptions details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblCurrentEatingActivityOptions"></param>
        /// <returns></returns>
        // PUT: api/CurrentEatingActivityOptions/5 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurrentEatingActivityOptions([FromRoute] int id, [FromBody] CurrentEatingActivityOptions tblCurrentEatingActivityOptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblCurrentEatingActivityOptions.CurrentEatingAcivityOptionsId)
            {
                return BadRequest();
            }

            try
            {
                await currentEatingActivityOptionsService.Update(id, tblCurrentEatingActivityOptions);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCurrentEatingActivityOptionsExists(id))
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
        /// This action method can be used to insert new CurrentEatingActivityOptions
        /// </summary>
        /// <param name="tblCurrentEatingActivityOptions"></param>
        /// <returns></returns>
        // POST: api/CurrentEatingActivityOptions
        [HttpPost]
        public async Task<IActionResult> InsertCurrentEatingActivityOptions([FromBody] CurrentEatingActivityOptions tblCurrentEatingActivityOptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            var entity = await currentEatingActivityOptionsService.Insert(tblCurrentEatingActivityOptions);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetCurrentEatingActivityOptionsByID", new { id = tblCurrentEatingActivityOptions.CurrentEatingAcivityOptionsId }, tblCurrentEatingActivityOptions);
        }

        /// <summary>
        /// This action method used to soft deletes the CurrentEatingActivityOptions Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/CurrentEatingActivityOptions/5 
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteCurrentEatingActivityOptions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await currentEatingActivityOptionsService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblCurrentEatingActivityOptionsExists(int id)
        {
            return currentEatingActivityOptionsService.GetAll().Any(e => e.CurrentEatingAcivityOptionsId == id);
        }
    }
}