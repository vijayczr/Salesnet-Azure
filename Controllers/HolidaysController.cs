using Microsoft.AspNetCore.Mvc;
using SalesNet.DataEntities;
using SalesNet.Models.Request;
using SalesNet.Models.Response;
using SalesNet.Services;
using System.IdentityModel.Tokens.Jwt;

namespace SalesNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HolidaysController :ControllerBase
    {
        private AdventureContext _DBContext;
        private readonly ILogger<HrManualController> _logger;
        private IHolidaysService _holidayList;

        public HolidaysController(ILogger<HrManualController> logger, AdventureContext dbcontext, IHolidaysService holidayList)
        {
            _DBContext = dbcontext;
            _logger = logger;
            _holidayList = holidayList;
        }

        #region HolidayList

        [Authorize]
        [HttpPost("HolidayList")]
        public async Task<IActionResult> HolidayList(HolidayListreqModel request)
        {
            var currentRequest = Request;
            int errorCode = 0;

            #region IP Address

            var ip = currentRequest.Headers["X-Forwarded-For"].FirstOrDefault();
            string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            ipAddress = ipAddress + " / " + ip;
            _logger.LogInformation($"[{currentRequest.Path}] => API Access From IP: [{ipAddress}]");

            #endregion

            var token = Request.Headers["Authorization"].FirstOrDefault();
            var tokenArray = token.Split(" ");
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(tokenArray[1]);
            var LoginId = (jwtToken.Claims.First(x => x.Type == "LoginId").Value);
            var BranchId = (jwtToken.Claims.First(u => u.Type == "BranchId").Value);
            if (BranchId == "")
                BranchId = "All";
            try
            {
                var response = await _holidayList.HolidayList(request);
                if (response.resCode != 200)
                {
                    return BadRequest(response);
                }
                else
                {
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                string errorMsg = $"ERROR CODE [{errorCode}] | [{currentRequest.Path}] | IP ADDRESS [{ipAddress}] : Internel server error !";
                _logger.LogError(errorMsg + " | " + ex.Message + " | " + ex.InnerException);
                return StatusCode(500, new CommonResponse
                {
                    resCode = 501,
                    resMessage = errorMsg
                });
            }
        }

        #endregion


    }
}
