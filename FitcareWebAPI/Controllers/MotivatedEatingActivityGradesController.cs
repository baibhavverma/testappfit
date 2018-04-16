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
    /// This class contains methods to get MotivatedEatingActivityGrades details, delete and insert MotivatedEatingActivityGrades,
    /// and change MotivatedEatingActivityGrades details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/MotivatedEatingActivityGrades")]
    public class MotivatedEatingActivityGradesController : Controller
    {
        private readonly IMotivatedEatingActivityGradesService motivatedEatingActivityGradesService;

        public MotivatedEatingActivityGradesController(IMotivatedEatingActivityGradesService repository)
        {
            this.motivatedEatingActivityGradesService = repository;
        }

        /// <summary>
        /// This action method can be used to get all MotivatedEatingActivityGrades details.
        /// </summary> 
        // GET: api/MotivatedEatingActivityGrades
        [HttpGet]
        public IEnumerable<MotivatedEatingActivityGrade> GetAllMotivatedEatingActivityGrade()
        {
            return motivatedEatingActivityGradesService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get MotivatedEatingActivityGrades details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/MotivatedEatingActivityGrades/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMotivatedEatingActivityGradeByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await motivatedEatingActivityGradesService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the MotivatedEatingActivityGrades details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblMotivatedEatingActivityGrade"></param>
        /// <returns></returns> 
        // PUT: api/MotivatedEatingActivityGrades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMotivatedEatingActivityGrade([FromRoute] int id, [FromBody] MotivatedEatingActivityGrade tblMotivatedEatingActivityGrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblMotivatedEatingActivityGrade.MotivatedEatingActivityGradeId)
            {
                return BadRequest();
            }

            try
            {
                await motivatedEatingActivityGradesService.Update(id, tblMotivatedEatingActivityGrade);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMotivatedEatingActivityGradeExists(id))
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
        /// This action method can be used to insert new MotivatedEatingActivityGrades
        /// </summary>
        /// <param name="tblMotivatedEatingActivityGrade"></param>
        /// <returns></returns>
        // POST: api/MotivatedEatingActivityGrades
        [HttpPost]
        public async Task<IActionResult> InsertMotivatedEatingActivityGrade([FromBody] MotivatedEatingActivityGrade tblMotivatedEatingActivityGrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            
            var entity = await motivatedEatingActivityGradesService.Insert(tblMotivatedEatingActivityGrade);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetMotivatedEatingActivityGradeByID", new { id = tblMotivatedEatingActivityGrade.MotivatedEatingActivityGradeId }, tblMotivatedEatingActivityGrade);
        }

        /// <summary>
        /// This action method used to soft deletes the MotivatedEatingActivityGrades Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/MotivatedEatingActivityGrades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteMotivatedEatingActivityGrade([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await motivatedEatingActivityGradesService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblMotivatedEatingActivityGradeExists(int id)
        {
            return motivatedEatingActivityGradesService.GetAll().Any(e => e.MotivatedEatingActivityGradeId == id);
        }
    }
}