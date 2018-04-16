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
    /// This class contains methods to get Rpegrades details, delete and insert Rpegrades,
    /// and change Rpegrades details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/Rpegrades")]
    public class RpegradesController : Controller
    {
        private readonly IRpegradeService rpegradeService;

        public RpegradesController(IRpegradeService repository)
        {
            this.rpegradeService = repository;
        }

        /// <summary>
        /// This action method can be used to get all Rpegrades details.
        /// </summary> 
        // GET: api/Rpegrades
        [HttpGet]
        public IEnumerable<Rpegrade> GetAllRpegrade()
        {
            return rpegradeService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get Rpegrades details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/Rpegrades/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRpegradeByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await rpegradeService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the Rpegrades details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rpegrade"></param>
        /// <returns></returns> 
        // PUT: api/Rpegrades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRpegrade([FromRoute] int id, [FromBody] Rpegrade rpegrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rpegrade.Rpeid)
            {
                return BadRequest();
            }

            try
            {
                await rpegradeService.Update(id, rpegrade);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RpegradeExists(id))
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
        /// This action method can be used to insert new Rpegrades
        /// </summary>
        /// <param name="rpegrade"></param>
        /// <returns></returns>   
        // POST: api/Rpegrades
        [HttpPost]
        public async Task<IActionResult> PostRpegrade([FromBody] Rpegrade rpegrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await rpegradeService.Insert(rpegrade);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetRpegradeByID", new { id = rpegrade.Rpeid }, rpegrade);
        }

        /// <summary>
        /// This action method used to soft deletes the Rpegrades Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Rpegrades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRpegrade([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await rpegradeService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool RpegradeExists(int id)
        {
            return rpegradeService.GetAll().Any(e => e.Rpeid == id);
        }
    }
}