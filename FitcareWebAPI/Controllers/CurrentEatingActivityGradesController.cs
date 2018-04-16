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
    /// This class contains methods to get CurrentEatingActivityGrades details, delete and insert CurrentEatingActivityGrades,
    /// and change CurrentEatingActivityGrades details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/CurrentEatingActivityGrades")]
    public class CurrentEatingActivityGradesController : Controller
    {
        private readonly ICurrentEatingActivityGradesService currentEatingActivityGradesService;

        public CurrentEatingActivityGradesController(ICurrentEatingActivityGradesService repository)
        {
            this.currentEatingActivityGradesService = repository;
        }

        /// <summary>
        /// This action method can be used to get all CurrentEatingActivityGrades details.
        /// </summary> 
        // GET: api/CurrentEatingActivityGrades
        [HttpGet]
        public IEnumerable<CurrentEatingActivityGrade> GetAllCurrentEatingActivityGrade()
        {
            return currentEatingActivityGradesService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get CurrentEatingActivityGrades details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/CurrentEatingActivityGrades/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrentEatingActivityGradeByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await currentEatingActivityGradesService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the CurrentEatingActivityGrades details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblCurrentEatingActivityGrade"></param>
        /// <returns></returns> 
        // PUT: api/CurrentEatingActivityGrades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurrentEatingActivityGrade([FromRoute] int id, [FromBody] CurrentEatingActivityGrade tblCurrentEatingActivityGrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblCurrentEatingActivityGrade.CurrentEatingActivityGradeId)
            {
                return BadRequest();
            }

            try
            {
                await currentEatingActivityGradesService.Update(id, tblCurrentEatingActivityGrade);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCurrentEatingActivityGradeExists(id))
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
        /// This action method can be used to insert new CurrentEatingActivityGrades
        /// </summary>
        /// <param name="tblCurrentEatingActivityGrade"></param>
        /// <returns></returns>
        // POST: api/CurrentEatingActivityGrades
        [HttpPost]
        public async Task<IActionResult> InsertCurrentEatingActivityGrade([FromBody] CurrentEatingActivityGrade tblCurrentEatingActivityGrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            var entity = await currentEatingActivityGradesService.Insert(tblCurrentEatingActivityGrade);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetCurrentEatingActivityGradeByID", new { id = tblCurrentEatingActivityGrade.CurrentEatingActivityGradeId }, tblCurrentEatingActivityGrade);
        }

        /// <summary>
        /// This action method used to soft deletes the CurrentEatingActivityGrades Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/CurrentEatingActivityGrades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteCurrentEatingActivityGrade([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await currentEatingActivityGradesService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblCurrentEatingActivityGradeExists(int id)
        {
            return currentEatingActivityGradesService.GetAll().Any(e => e.CurrentEatingActivityGradeId == id);
        }
    }
}