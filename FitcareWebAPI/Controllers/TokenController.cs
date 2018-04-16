using FitcareWebAPI.Model;
using FitcareWebAPI.Model.Model;
using FitcareWebAPI.Model.Model.DB;
using FitcareWebAPIModel.Provider.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TokenAuthEmpty.Provider.JWT;

namespace NewWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    [AllowAnonymous]

    public class FitcareWebAPI : Controller
    {
        private readonly FitCareDbContext _context;

        public FitcareWebAPI(FitCareDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> CreateAsync([FromBody] LoginInputModel inputModel)
        {
            var tblPlayerProfile = await _context.TblPlayerProfile.SingleOrDefaultAsync(m => m.Email == inputModel.Username && m.Password == inputModel.Password && m.IsDeleted == false);

            if (tblPlayerProfile == null)
            {
                return Unauthorized();
            } 
            var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("Test-secret-key-1234"))
                                .AddSubject("Raj Kumar")
                                .AddIssuer("Test.Security.Bearer")
                                .AddAudience("Test.Security.Bearer")
                                .AddClaim("EmployeeNumber", "6109")
                                .AddExpiry(5)
                                .Build();  
            return Ok(token.Value);
        }
    }

}