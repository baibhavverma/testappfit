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
    /// This class contains methods to get Shops details, delete and insert Shops,
    /// and change Shops details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/Shops")]
    public class ShopsController : Controller
    {
        
        private readonly IShopsService shopsService;
        public ShopsController(IShopsService repository)
        {
            this.shopsService = repository;
        }

        /// <summary>
        /// This action method can be used to get all Shops details.
        /// </summary> 
        // GET: api/Shops
        [HttpGet]
        public IEnumerable<Shop> GetAllShop()
        {
            return shopsService.GetAll();
        }

        /// <summary>
        /// This action method can be used to get Shops details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/Shops/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShopByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await shopsService.GetByID(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the Shops details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblShop"></param>
        /// <returns></returns> 
        // PUT: api/Shops/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShop([FromRoute] int id, [FromBody] Shop tblShop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblShop.ShopId)
            {
                return BadRequest();
            }

            try
            {
                await shopsService.Update(id, tblShop);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblShopExists(id))
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
        /// This action method can be used to insert new Shops
        /// </summary>
        /// <param name="tblShop"></param>
        /// <returns></returns>
        // POST: api/Shops
        [HttpPost]
        public async Task<IActionResult> InsertShop([FromBody] Shop tblShop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            var entity = await shopsService.Insert(tblShop);
            if (entity == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetShopByID", new { id = tblShop.ShopId }, tblShop);
        }

        /// <summary>
        /// This action method used to soft deletes the Shops Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/Shops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteShop([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await shopsService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblShopExists(int id)
        {
            return shopsService.GetAll().Any(e => e.ShopId == id);
        }
    }
}