using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitcareWebAPI.Model.Model.DB;
using Microsoft.AspNetCore.Authorization;
using FitcareWebAPI.IServices.InterfaceRepository;

namespace FitcareWebAPI.Controllers
{
    /// <summary>
    /// This class contains methods to get Settings details, delete and insert Settings,
    /// and change Settings details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/Settings")]
    public class SettingsController : Controller
    {
        
        private readonly ISettingsService settingsService;
        public SettingsController(ISettingsService repository)
        {
            this.settingsService = repository;
        }

        /// <summary>
        /// This action method can be used to get all Settings details.
        /// </summary> 
        // GET: api/Settings
        [HttpGet]
        public IEnumerable<Settings> GetAllSettings()
        {
            return settingsService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get Settings details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/Settings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSettingsByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await settingsService.GetByID(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the Settings details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblSettings"></param>
        /// <returns></returns> 
        // PUT: api/Settings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSettings([FromRoute] int id, [FromBody] Settings tblSettings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblSettings.SettingsId)
            {
                return BadRequest();
            }

            try
            {
                await settingsService.Update(id, tblSettings);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblSettingsExists(id))
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
        /// This action method can be used to insert new Settings
        /// </summary>
        /// <param name="tblSettings"></param>
        /// <returns></returns>
        // POST: api/Settings
        [HttpPost]
        public async Task<IActionResult> InsertSettings([FromBody] Settings tblSettings)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            var entity = await settingsService.Insert(tblSettings);
            if (entity == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetSettingsByID", new { id = tblSettings.SettingsId }, tblSettings);
        }

        /// <summary>
        /// This action method used to soft deletes the Settings Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/Settings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteSettings([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await settingsService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblSettingsExists(int id)
        {
            return settingsService.GetAll().Any(e => e.SettingsId == id);
        }
    }
}