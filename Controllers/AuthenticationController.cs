using Microsoft.AspNetCore.Mvc;
using SalesCustom.Services;
using SalesNet.DataEntities;
using SalesNet.Models.Request;
using SalesNet.Models.Response;
using System.IdentityModel.Tokens.Jwt;

namespace SalesNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {

        private AdventureContext _DBContext;
        private readonly ILogger<AuthenticationController> _logger;
        private IAuthenticationService _Login;

        public AuthenticationController(ILogger<AuthenticationController> logger, AdventureContext dbcontext , IAuthenticationService Login)
        {
            _DBContext = dbcontext;
            _logger = logger;
            _Login = Login;
        }

        #region LoginAuth

        [HttpPost ("Login")]
        public async Task<IActionResult> retrieve(LoginRequestModel requestModel)
        {
            var currentRequest = Request;
            int errorCode = 0;

            #region IP Address

            var ip = currentRequest.Headers["X-Forwarded-For"].FirstOrDefault();
            string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            ipAddress = ipAddress + " / " + ip;
            _logger.LogInformation($"[{currentRequest.Path}] => API Access From IP: [{ipAddress}]");

            #endregion

            try
            {
                var response = await _Login.LoginAuth(requestModel);
                if (response == null)
                {
                    return BadRequest(new CommonResponse { resCode = 400, resMessage = "Bad Request!!" });
                }
                else
                {
                    return Ok(new CommonResponse { resCode = 200, resData = response, resMessage = "Success!!" });
                }
            }
            catch (Exception ex)
            {
                string errorMsg = $"ERROR CODE [{errorCode}] | [{currentRequest.Path}] | IP ADDRESS [{ipAddress}] : Internel server error !";
                _logger.LogError(errorMsg + " | " + ex.Message + " | " + ex.InnerException);
                _logger.Log(LogLevel.Information, "ok ji");
                return StatusCode(500, new CommonResponse
                {
                    resCode = 501,
                    resMessage = errorMsg
                });
            }
        }

        #endregion

        #region ChangePassword

        [Authorize]
        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(PasswordChangeReqModel requestModel)
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

            try
            {
                var response = await _Login.UpdatePassword(requestModel , LoginId);
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

        #region ProfileData

        [Authorize]
        [HttpGet("ProfileData")]
        public async Task<IActionResult> ProfileData()
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

            try
            {
                var response = await _Login.ProfileData(LoginId);
                //var response = await _Login.CopyFilesRecursively();

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

        #region USerImage

        [Authorize]
        [HttpGet("USerImage")]
        public async Task<IActionResult> USerImage(int EmpId)
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

            try
            {
                var response = await _Login.UserImage(EmpId);
                return StatusCode(response.resCode, response);
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