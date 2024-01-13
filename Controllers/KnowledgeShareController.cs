using Aspose.Slides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesNet.DataEntities;
using SalesNet.Model;
using SalesNet.Models.Request;
using SalesNet.Models.Response;
using SalesNet.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace SalesNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KnowledgeShareController : ControllerBase
    {
        private AdventureContext _DBContext;
        private readonly ILogger<KnowledgeShareController> _logger;
        private IKnowledgeShareService _knowledgeShare;

        public KnowledgeShareController(ILogger<KnowledgeShareController> logger, AdventureContext dbcontext, IKnowledgeShareService knowledgeShare)
        {
            _DBContext = dbcontext;
            _logger = logger;
            _knowledgeShare = knowledgeShare;
        }

        #region KnowledgeShare List

        [Authorize]
        [HttpPost("knowledge-list")]

        public async Task<IActionResult> KNowledgeShareList(KnowledgeReqModel request)
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
            string errorMsg = $"ERROR CODE [{errorCode}] | [{currentRequest.Path}] | IP ADDRESS [{ipAddress}] : Internel server error !";
            try
            {
                var response = await _knowledgeShare.KnowledgeShareList(request);
                if (response.resCode == 404)
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

                _logger.LogError(errorMsg + " | " + ex.Message + " | " + ex.InnerException);
                return StatusCode(500, new CommonResponse
                {
                    resCode = 501,
                    resMessage = errorMsg
                });
            }

        }

        #endregion

        #region Knowledge info

        [Authorize]
        [HttpGet("knowledge-info")]

        public async Task<IActionResult> KNowledgeShareInfo(string KnowledgeId)
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
            string errorMsg = $"ERROR CODE [{errorCode}] | [{currentRequest.Path}] | IP ADDRESS [{ipAddress}] : Internel server error !";
            try
            {
                var response = await _knowledgeShare.KnowledgeInfo(KnowledgeId);
                if (response.resCode == 400)
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

                _logger.LogError(errorMsg + " | " + ex.Message + " | " + ex.InnerException);
                return StatusCode(500, new CommonResponse
                {
                    resCode = 501,
                    resMessage = errorMsg
                });
            }

        }

        #endregion

        #region KnowledgeFileDownload

        //[Authorize]
        [HttpGet("KnowledgeDownload")]

        public async Task<IActionResult> ManualDownload(string KnowledgeId)
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
                var response = await _knowledgeShare.DownloadFile(KnowledgeId);
                return File(response.Item1, response.Item2, response.Item3);


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

        #region KnowledgeFIleUpload

        [Authorize]
        [HttpPost("KFUpload")]

        public async Task<IActionResult> KFUpload( [FromForm] KFUploadReqModel request)
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
                var response = await _knowledgeShare.knowledgeFileUpload(LoginId , request);
                if(response == true)
                {
                    return Ok(new CommonResponse() { resCode=200,resData = response ,resMessage = "Success"});
                }
                else
                {
                    return BadRequest(new CommonResponse() { resCode = 400 ,resData=response,resMessage = "Bad Request!"});
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
