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
    /// This class contains methods to get CustomizationAvatars details, delete and insert CustomizationAvatars,
    /// and change CustomizationAvatars details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/CustomizationAvatars")]
    public class CustomizationAvatarsController : Controller
    {
        
        private readonly ICustomizationAvatarsService customizationAvatarsService;

        public CustomizationAvatarsController(ICustomizationAvatarsService repository)
        {
            this.customizationAvatarsService = repository;
        }

        /// <summary>
        /// This action method can be used to get all CustomizationAvatars details.
        /// </summary> 
        // GET: api/CustomizationAvatars
        [HttpGet]
        public IEnumerable<CustomizationAvatar> GetAllCustomizationAvatar()
        {
            return customizationAvatarsService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get CustomizationAvatars details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/CustomizationAvatars/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomizationAvatarByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await customizationAvatarsService.GetByID(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the CustomizationAvatars details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblCustomizationAvatar"></param>
        /// <returns></returns> 
        // PUT: api/CustomizationAvatars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomizationAvatar([FromRoute] int id, [FromBody] CustomizationAvatar tblCustomizationAvatar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblCustomizationAvatar.CustomizationId)
            {
                return BadRequest();
            }

            try
            {
                await customizationAvatarsService.Update(id, tblCustomizationAvatar);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCustomizationAvatarExists(id))
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
        /// This action method can be used to insert new CustomizationAvatars
        /// </summary>
        /// <param name="tblCustomizationAvatar"></param>
        /// <returns></returns>
        // POST: api/CustomizationAvatars
        [HttpPost]
        public async Task<IActionResult> InsertCustomizationAvatar([FromBody] CustomizationAvatar tblCustomizationAvatar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            var entity = await customizationAvatarsService.Insert(tblCustomizationAvatar);
            if (entity == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("GetCustomizationAvatarByID", new { id = tblCustomizationAvatar.CustomizationId }, tblCustomizationAvatar);
        }

        /// <summary>
        /// This action method used to soft deletes the CustomizationAvatars Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> [Authorize]
        // DELETE: api/CustomizationAvatars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteCustomizationAvatar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await customizationAvatarsService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblCustomizationAvatarExists(int id)
        {
            return customizationAvatarsService.GetAll().Any(e => e.CustomizationId == id);
        }
    }
}