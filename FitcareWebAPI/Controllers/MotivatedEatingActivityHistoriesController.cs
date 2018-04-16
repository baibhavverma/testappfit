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
    /// This class contains methods to get MotivatedEatingActivityHistories details, delete and insert MotivatedEatingActivityHistories,
    /// and change MotivatedEatingActivityHistories details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/MotivatedEatingActivityHistories")]
    public class MotivatedEatingActivityHistoriesController : Controller
    {
        private readonly IMotivatedEatingActivityHistoriesService motivatedEatingActivityHistoriesService;

        public MotivatedEatingActivityHistoriesController(IMotivatedEatingActivityHistoriesService repository)
        {
            this.motivatedEatingActivityHistoriesService = repository;
        }

        /// <summary>
        /// This action method can be used to get all MotivatedEatingActivityHistories details.
        /// </summary> 
        // GET: api/MotivatedEatingActivityHistories
        [HttpGet]
        public IEnumerable<MotivatedEatingActivityHistory> GetAllMotivatedEatingActivityHistory()
        {
            return motivatedEatingActivityHistoriesService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get MotivatedEatingActivityHistories details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/MotivatedEatingActivityHistories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMotivatedEatingActivityHistoryByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await motivatedEatingActivityHistoriesService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the MotivatedEatingActivityHistories details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblMotivatedEatingActivityHistory"></param>
        /// <returns></returns> 
        // PUT: api/MotivatedEatingActivityHistories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMotivatedEatingActivityHistory([FromRoute] int id, [FromBody] MotivatedEatingActivityHistory tblMotivatedEatingActivityHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblMotivatedEatingActivityHistory.MotivatedEatingActivityHistoryId)
            {
                return BadRequest();
            }

            try
            {
                await motivatedEatingActivityHistoriesService.Update(id, tblMotivatedEatingActivityHistory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMotivatedEatingActivityHistoryExists(id))
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
        /// This action method can be used to insert new MotivatedEatingActivityHistories
        /// </summary>
        /// <param name="tblMotivatedEatingActivityHistory"></param>
        /// <returns></returns>
        // POST: api/MotivatedEatingActivityHistories
        [HttpPost]
        public async Task<IActionResult> InsertMotivatedEatingActivityHistory([FromBody] MotivatedEatingActivityHistory tblMotivatedEatingActivityHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            var entity = await motivatedEatingActivityHistoriesService.Insert(tblMotivatedEatingActivityHistory);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetMotivatedEatingActivityHistoryByID", new { id = tblMotivatedEatingActivityHistory.MotivatedEatingActivityHistoryId }, tblMotivatedEatingActivityHistory);
        }

        /// <summary>
        /// This action method used to soft deletes the MotivatedEatingActivityHistories Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/MotivatedEatingActivityHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteMotivatedEatingActivityHistory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await motivatedEatingActivityHistoriesService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblMotivatedEatingActivityHistoryExists(int id)
        {
            return motivatedEatingActivityHistoriesService.GetAll().Any(e => e.MotivatedEatingActivityHistoryId == id);
        }
    }
}