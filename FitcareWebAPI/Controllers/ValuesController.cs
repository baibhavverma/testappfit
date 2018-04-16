using FitcareWebAPI.Model.Model.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitcareWebAPIModel.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly FitCareDbContext _context;
        public ValuesController(FitCareDbContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<PlayerProfile> lstTblPlayerProfile = new List<PlayerProfile>();
            lstTblPlayerProfile = _context.TblPlayerProfile.ToList(); 
            return Json(await _context.TblPlayerProfile.ToListAsync());
        }
        // GET api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
