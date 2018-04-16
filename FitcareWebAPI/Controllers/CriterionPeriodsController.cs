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
    /// This class contains methods to get CriterionPeriods details, delete and insert CriterionPeriods,
    /// and change CriterionPeriods details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/CriterionPeriods")]
    public class CriterionPeriodsController : Controller
    {
        private readonly ICriterionPeriodsService criterionPeriodsService;

        public CriterionPeriodsController(ICriterionPeriodsService repository)
        {
            this.criterionPeriodsService = repository;
        }

        /// <summary>
        /// This action method can be used to get all CriterionPeriods details.
        /// </summary> 
        // GET: api/CriterionPeriods
        [HttpGet]
        public IEnumerable<CriterionPeriods> GetAllCriterionPeriod()
        {
            return criterionPeriodsService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get CriterionPeriods details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/CriterionPeriods/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCriterionPeriodsByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await criterionPeriodsService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the CriterionPeriods details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="criterionPeriods"></param>
        /// <returns></returns> 
        // PUT: api/CriterionPeriods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCriterionPeriods([FromRoute] int id, [FromBody] CriterionPeriods criterionPeriods)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != criterionPeriods.CriterionPeriodId)
            {
                return BadRequest();
            }

            try
            {
                await criterionPeriodsService.Update(id, criterionPeriods);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CriterionPeriodsExists(id))
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
        /// This action method can be used to insert new CriterionPeriods
        /// </summary>
        /// <param name="criterionPeriods"></param>
        /// <returns></returns>
        // POST: api/CriterionPeriods
        [HttpPost]
        public async Task<IActionResult> PostCriterionPeriods([FromBody] CriterionPeriods criterionPeriods)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await criterionPeriodsService.Insert(criterionPeriods);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetCriterionPeriodsByID", new { id = criterionPeriods.CriterionPeriodId }, criterionPeriods);
        }

        /// <summary>
        /// This action method used to soft deletes the CriterionPeriods Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/CriterionPeriods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCriterionPeriods([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await criterionPeriodsService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool CriterionPeriodsExists(int id)
        {
            return criterionPeriodsService.GetAll().Any(e => e.CriterionPeriodId == id);
        }
    }
}