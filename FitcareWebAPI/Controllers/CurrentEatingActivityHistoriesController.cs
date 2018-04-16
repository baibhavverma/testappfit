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
    /// This class contains methods to get CurrentEatingActivityHistories details, delete and insert CurrentEatingActivityHistories,
    /// and change CurrentEatingActivityHistories details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/CurrentEatingActivityHistories")]
    public class CurrentEatingActivityHistoriesController : Controller
    {
         
        private readonly ICurrentEatingActivityHistoriesService currentEatingActivityHistoriesService;

        public CurrentEatingActivityHistoriesController(ICurrentEatingActivityHistoriesService repository)
        {
            this.currentEatingActivityHistoriesService = repository;
        }

        /// <summary>
        /// This action method can be used to get all CurrentEatingActivityHistories details.
        /// </summary>
        // GET: api/CurrentEatingActivityHistories 
        [HttpGet]
        public IEnumerable<CurrentEatingActivityHistory> GetAllCurrentEatingActivityHistory()
        {
            return currentEatingActivityHistoriesService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get CurrentEatingActivityHistories details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/CurrentEatingActivityHistories/5 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrentEatingActivityHistoryByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await currentEatingActivityHistoriesService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the CurrentEatingActivityHistories details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblCurrentEatingActivityHistory"></param>
        /// <returns></returns>
        // PUT: api/CurrentEatingActivityHistories/5 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurrentEatingActivityHistory([FromRoute] int id, [FromBody] CurrentEatingActivityHistory tblCurrentEatingActivityHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblCurrentEatingActivityHistory.CurrentEatingActivityHistoryId)
            {
                return BadRequest();
            }

            try
            {
                await currentEatingActivityHistoriesService.Update(id, tblCurrentEatingActivityHistory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCurrentEatingActivityHistoryExists(id))
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
        /// This action method can be used to insert new CurrentEatingActivityHistories
        /// </summary>
        /// <param name="tblCurrentEatingActivityHistory"></param>
        /// <returns></returns>
        // POST: api/CurrentEatingActivityHistories
        [HttpPost]
        public async Task<IActionResult> InsertCurrentEatingActivityHistory([FromBody] CurrentEatingActivityHistory tblCurrentEatingActivityHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            
            var entity = await currentEatingActivityHistoriesService.Insert(tblCurrentEatingActivityHistory);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetCurrentEatingActivityHistoryByID", new { id = tblCurrentEatingActivityHistory.CurrentEatingActivityHistoryId }, tblCurrentEatingActivityHistory);
        }

        /// <summary>
        /// This action method used to soft deletes the CurrentEatingActivityHistories Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/CurrentEatingActivityHistories/5 
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteCurrentEatingActivityHistory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await currentEatingActivityHistoriesService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblCurrentEatingActivityHistoryExists(int id)
        {
            return currentEatingActivityHistoriesService.GetAll().Any(e => e.CurrentEatingActivityHistoryId == id);
        }
    }
}