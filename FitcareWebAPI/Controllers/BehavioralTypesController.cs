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
    /// This class contains methods to get BehavioralTypes details, delete and insert BehavioralTypes,
    /// and change BehavioralTypes details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/BehavioralTypes")]
    public class BehavioralTypesController : Controller
    {
        private readonly IBehavioralTypesService behavioralTypesService;

        public BehavioralTypesController(IBehavioralTypesService repository)
        {
            this.behavioralTypesService = repository;
        }

        /// <summary>
        /// This action method can be used to get all BehavioralTypes details.
        /// </summary> 
        // GET: api/BehavioralTypes
        [HttpGet]
        public IEnumerable<BehavioralType> GetAllType()
        {
            return behavioralTypesService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get BehavioralTypes details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/BehavioralTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBehavioralTypeByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await behavioralTypesService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the BehavioralTypes details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="behavioralType"></param>
        /// <returns></returns> 
        // PUT: api/BehavioralTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBehavioralType([FromRoute] int id, [FromBody] BehavioralType behavioralType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != behavioralType.TypeId)
            {
                return BadRequest();
            }

            try
            {
                await behavioralTypesService.Update(id, behavioralType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BehavioralTypeExists(id))
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
        /// This action method can be used to insert new BehavioralTypes
        /// </summary>
        /// <param name="behavioralType"></param>
        /// <returns></returns>  
        // POST: api/BehavioralTypes
        [HttpPost]
        public async Task<IActionResult> PostBehavioralType([FromBody] BehavioralType behavioralType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await behavioralTypesService.Insert(behavioralType);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetBehavioralTypeByID", new { id = behavioralType.TypeId }, behavioralType);
        }

        /// <summary>
        /// This action method used to soft deletes the BehavioralTypes Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/BehavioralTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBehavioralType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await behavioralTypesService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool BehavioralTypeExists(int id)
        {
            return behavioralTypesService.GetAll().Any(e => e.TypeId == id);
        }
    }
}