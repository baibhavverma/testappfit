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
    /// This class contains methods to get MotivatedEatingActivityOptions details, delete and insert MotivatedEatingActivityOptions,
    /// and change MotivatedEatingActivityOptions details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/MotivatedEatingActivityOptions")]
    public class MotivatedEatingActivityOptionsController : Controller
    {
        private readonly IMotivatedEatingActivityOptionsService motivatedEatingActivityOptionsService;

        public MotivatedEatingActivityOptionsController(IMotivatedEatingActivityOptionsService repository)
        {
            this.motivatedEatingActivityOptionsService = repository;
        }

        /// <summary>
        /// This action method can be used to get all MotivatedEatingActivityOptions details.
        /// </summary> 
        // GET: api/MotivatedEatingActivityOptions
        [HttpGet]
        public IEnumerable<MotivatedEatingActivityOptions> GetAllMotivatedEatingActivityOptions()
        {
            return motivatedEatingActivityOptionsService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get MotivatedEatingActivityOptions details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/MotivatedEatingActivityOptions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMotivatedEatingActivityOptionsByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await motivatedEatingActivityOptionsService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the MotivatedEatingActivityOptions details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblMotivatedEatingActivityOptions"></param>
        /// <returns></returns> 
        // PUT: api/MotivatedEatingActivityOptions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMotivatedEatingActivityOptions([FromRoute] int id, [FromBody] MotivatedEatingActivityOptions tblMotivatedEatingActivityOptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblMotivatedEatingActivityOptions.MotivatedEatingActivityOptionsId)
            {
                return BadRequest();
            }

            try
            {
                await motivatedEatingActivityOptionsService.Update(id, tblMotivatedEatingActivityOptions);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMotivatedEatingActivityOptionsExists(id))
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
        /// This action method can be used to insert new MotivatedEatingActivityOptions
        /// </summary>
        /// <param name="tblMotivatedEatingActivityOptions"></param>
        /// <returns></returns> 
        // POST: api/MotivatedEatingActivityOptions
        [HttpPost]
        public async Task<IActionResult> InsertMotivatedEatingActivityOptions([FromBody] MotivatedEatingActivityOptions tblMotivatedEatingActivityOptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await motivatedEatingActivityOptionsService.Insert(tblMotivatedEatingActivityOptions);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetMotivatedEatingActivityOptionsByID", new { id = tblMotivatedEatingActivityOptions.MotivatedEatingActivityOptionsId }, tblMotivatedEatingActivityOptions);
        }

        /// <summary>
        /// This action method used to soft deletes the MotivatedEatingActivityOptions Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/MotivatedEatingActivityOptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteMotivatedEatingActivityOptions([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await motivatedEatingActivityOptionsService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblMotivatedEatingActivityOptionsExists(int id)
        {
            return motivatedEatingActivityOptionsService.GetAll().Any(e => e.MotivatedEatingActivityOptionsId == id);
        }
    }
}