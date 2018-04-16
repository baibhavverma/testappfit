using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitcareWebAPI.Model.Model.DB;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.ComponentModel;
using Newtonsoft.Json;
using FitcareWebAPI.IServices.InterfaceRepository;

namespace FitcareWebAPI.Controllers
{
    /// <summary>
    /// This class contains methods to get PlayerShopInfoes details, delete and insert PlayerShopInfoes,
    /// and change PlayerShopInfoes details.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/PlayerShopInfoes")]
    public class PlayerShopInfoesController : Controller
    {
        private readonly IPlayerShopInfoesService playerShopInfoesService;
        public PlayerShopInfoesController(IPlayerShopInfoesService repository)
        {
            this.playerShopInfoesService = repository;
        }

        /// <summary>
        /// This action method can be used to get all PlayerShopInfoes details.
        /// </summary> 
        // GET: api/PlayerShopInfoes
        [HttpGet]
        public IEnumerable<PlayerShopInfo> GetAllPlayerShopInfo()
        {
            return playerShopInfoesService.GetAll();   
        }

        /// <summary>
        /// This action method can be used to get PlayerShopInfoes details by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // GET: api/PlayerShopInfoes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerShopInfoByID([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await playerShopInfoesService.GetByID(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        /// <summary>
        /// This action method updates the PlayerShopInfoes details, if already inserted.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblPlayerShopInfo"></param>
        /// <returns></returns> 
        // PUT: api/PlayerShopInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayerShopInfo([FromRoute] int id, [FromBody] PlayerShopInfo tblPlayerShopInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblPlayerShopInfo.PlayerShopInfoId)
            {
                return BadRequest();
            }

            try
            {
                await playerShopInfoesService.Update(id, tblPlayerShopInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPlayerShopInfoExists(id))
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
        /// This action method can be used to insert new PlayerShopInfoes
        /// </summary>
        /// <param name="tblPlayerShopInfo"></param>
        /// <returns></returns>
        // POST: api/PlayerShopInfoes
        [HttpPost]
        public async Task<IActionResult> InsertPlayerShopInfo([FromBody] PlayerShopInfo tblPlayerShopInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             
            var entity = await playerShopInfoesService.Insert(tblPlayerShopInfo);
            if (entity == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetPlayerShopInfoByID", new { id = tblPlayerShopInfo.PlayerShopInfoId }, tblPlayerShopInfo);
        }

        /// <summary>
        /// This action method used to soft deletes the PlayerShopInfoes Record in the application.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns> 
        // DELETE: api/PlayerShopInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeletePlayerShopInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await playerShopInfoesService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool TblPlayerShopInfoExists(int id)
        {
            return playerShopInfoesService.GetAll().Any(e => e.PlayerShopInfoId == id);
        }
    }
}