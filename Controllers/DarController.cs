using Microsoft.AspNetCore.Mvc;
using SalesNet.DapperContext;
using SalesNet.DataEntities;
using SalesNet.Model;
using SalesNet.Models.Request;
using SalesNet.Models.Response;
using SalesNet.Services;
using System.IdentityModel.Tokens.Jwt;

namespace SalesNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DarController :ControllerBase
    {
        private AdventureContext _DBContext;
        private readonly ILogger<HrManualController> _logger;
        private IDarService _DarService;

        public DarController(ILogger<HrManualController> logger, AdventureContext dbcontext, IDarService DarService)
        {
            _DBContext = dbcontext;
            _logger = logger;
            _DarService = DarService;
        }

        #region DarList

        [Authorize]
        [HttpPost("DarList")]

        public async Task<IActionResult> DarList(DarListReQModel request)
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
                var response = await _DarService.DarList(LoginId, request);
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

        #region CustomerNames

        [Authorize]
        [HttpGet("CustomerNames")]

        public async Task<IActionResult> CustomerNames(string Search)
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
                var response = await _DarService.CustomerNames(Search);
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

        #region DarQuarterTarget

        [Authorize]
        [HttpGet("darquartertarget")]

        public async Task<IActionResult> darquartertarget()
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
                var response = await _DarService.darquartertarget(LoginId);
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

        #region customerList

        [Authorize]
        [HttpGet("customerList")]

        public async Task<IActionResult> customerList()
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
                var response = await _DarService.customerList();
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

        #region AppEngineer

        [Authorize]
        [HttpGet("AppEngineer")]

        public async Task<IActionResult> AppEngineer()
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
                var response = await _DarService.AppEngineer();
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

        #region CustpersonList

        [Authorize]
        [HttpGet("CustpersonList")]

        public async Task<IActionResult> CustpersonList(int CustId)
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
                var response = await _DarService.CustpersonList(CustId);
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

        #region CustDetail

        [Authorize]
        [HttpGet("CustDetail")]

        public async Task<IActionResult> CustDetail(int CustId)
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
                var response = await _DarService.CustDetail(CustId);
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

        #region PrincipalList

        [Authorize]
        [HttpGet("PrincipalList")]

        public async Task<IActionResult> PrincipalList()
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
                var response = await _DarService.PrincipalList();
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

        #region ProductListByPrincipalId

        [Authorize]
        [HttpGet("ProductListByPrincipalId")]

        public async Task<IActionResult> ProductListByPrincipalId(int PrincipalId)
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
                var response = await _DarService.ProductListByPrincipalId(PrincipalId);
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

        #region DarEntry

        [Authorize]
        [HttpPost("DarEntry")]

        public async Task<IActionResult> DarEntry(AddDarRqModel request)
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
                var response = await _DarService.DarEntry(request,LoginId);
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

        #region DarFileUpload

        [Authorize]
        [HttpPost("DarFileUpload")]

        public async Task<IActionResult> DarFileUpload([FromForm] DarDocReqModel request)
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
                var response = await _DarService.DarFileUpload(request);
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

        #region ViewDar

        [Authorize]
        [HttpGet("ViewDar")]

        public async Task<IActionResult> ViewDar(int DarId)
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
                var response = await _DarService.ViewDar(DarId);
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
