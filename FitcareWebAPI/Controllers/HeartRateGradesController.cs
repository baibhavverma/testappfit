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
    /// This class contains methods to get HeartRateGrades details, delete and insert HeartRateGrades,
    /// and change HeartRateGrades details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/HeartRateGrades")]
    public class HeartRateGradesController : Controller
    {
        private readonly IHeartRateGradeService heartRateGradeService;

        public HeartRateGradesController(IHeartRateGradeService repository)
        {
            this.heartRateGradeService = repository;
        }

        /// <summary>
        /// This action method can be used to get all HeartRateGrades details.
        /// </summary> 
        // GET: api/HeartRateGrades
        [HttpGet]
        public IEnumerable<HeartRateGrade> GetAllHeartRateGrade()
        {
            return heartRateGradeService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get HeartRateGrades details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/HeartRateGrades/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHeartRateGradebyID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await heartRateGradeService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the HeartRateGrades details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="heartRateGrade"></param>
        /// <returns></returns> 
        // PUT: api/HeartRateGrades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeartRateGrade([FromRoute] int id, [FromBody] HeartRateGrade heartRateGrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != heartRateGrade.HeartRateScaleId)
            {
                return BadRequest();
            }

            try
            {
                await heartRateGradeService.Update(id, heartRateGrade);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeartRateGradeExists(id))
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
        /// This action method can be used to insert new HeartRateGrades
        /// </summary>
        /// <param name="heartRateGrade"></param>
        /// <returns></returns> 
        // POST: api/HeartRateGrades
        [HttpPost]
        public async Task<IActionResult> PostHeartRateGrade([FromBody] HeartRateGrade heartRateGrade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await heartRateGradeService.Insert(heartRateGrade);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetHeartRateGradebyID", new { id = heartRateGrade.HeartRateScaleId }, heartRateGrade);
        }

        /// <summary>
        /// This action method used to soft deletes the HeartRateGrades Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/HeartRateGrades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeartRateGrade([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await heartRateGradeService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool HeartRateGradeExists(int id)
        {
            return heartRateGradeService.GetAll().Any(e => e.HeartRateScaleId == id);
        }
    }
}