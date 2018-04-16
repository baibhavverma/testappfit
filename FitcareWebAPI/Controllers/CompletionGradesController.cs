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
    /// This class contains methods to get CompletionGrades details, delete and insert CompletionGrades,
    /// and change CompletionGrades details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/CompletionGrades")]
    public class CompletionGradesController : Controller
    {
        private readonly ICompletionGradesService completionGradesService;

        public CompletionGradesController(ICompletionGradesService repository)
        {
            this.completionGradesService = repository;
        }

        /// <summary>
        /// This action method can be used to get all CompletionGrades details.
        /// </summary> 
        // GET: api/CompletionGrades
        [HttpGet]
        public IEnumerable<CompletionGrade> GetAllCompletionGrade()
        {
            return completionGradesService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get CompletionGrades details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/CompletionGrades/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompletionGradeByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await completionGradesService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the CompletionGrades details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="completionGrade"></param>
        /// <returns></returns> 
        // PUT: api/CompletionGrades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompletionGrade([FromRoute] int id, [FromBody] CompletionGrade completionGrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != completionGrade.CompletionGradeId)
            {
                return BadRequest();
            }

            try
            {
                await completionGradesService.Update(id, completionGrade);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompletionGradeExists(id))
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
        /// This action method can be used to insert new CompletionGrades
        /// </summary>
        /// <param name="completionGrade"></param>
        /// <returns></returns>  
        // POST: api/CompletionGrades
        [HttpPost]
        public async Task<IActionResult> InsertCompletionGrade([FromBody] CompletionGrade completionGrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await completionGradesService.Insert(completionGrade);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetCompletionGradeByID", new { id = completionGrade.CompletionGradeId }, completionGrade);
        }

        /// <summary>
        /// This action method used to soft deletes the CompletionGrades Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/CompletionGrades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteCompletionGrade([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await completionGradesService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool CompletionGradeExists(int id)
        {
            return completionGradesService.GetAll().Any(e => e.CompletionGradeId == id);
        }
    }
}