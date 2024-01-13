using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using SalesNet.DataEntities;
using SalesNet.Model;
using SalesNet.Models.Request;
using SalesNet.Models.Response;
using SalesNet.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
#pragma warning disable CS8602 // Possible null reference assignment.
namespace SalesNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HrManualController : ControllerBase
    {
        private AdventureContext _DBContext;
        private readonly ILogger<HrManualController> _logger;
        private IHrmanualService _HrManual;

        public HrManualController(ILogger<HrManualController> logger, AdventureContext dbcontext, IHrmanualService HrManual)
        {
            _DBContext = dbcontext;
            _logger = logger;
            _HrManual = HrManual;
        }

        #region ManualList

        [Authorize]
        [HttpPost ("ManualList")]

        public async Task<IActionResult> HrManuals(HrManualRequestModel request)
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
                var response = await _HrManual.hrmanual(request);
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
                return StatusCode(500, new CommonResponse
                {
                    resCode = 501,
                    resMessage = errorMsg
                });
            }

        }

        #endregion

        #region Pdf Download

        //[Authorize]
        [HttpGet ("ManualDownload")]

        public async Task<IActionResult> ManualDownload(string DocumentType)
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
                var response = await _HrManual.DownloadFile(DocumentType);
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

        #region hrManual Information

        [Authorize]
        [HttpGet("ManualInfo")]

        public async Task<IActionResult> ManualInfo(string DocumentType)
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
                var response = await _HrManual.ManualInfo(DocumentType);
                return Ok(response);
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

        #region HrEmpList

        [Authorize]
        [HttpPost("HrEmpList")]

        public async Task<IActionResult> HrEmpList(HrEmpListReqModel request)
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
                var response = await _HrManual.hremployeelist(request);
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
                return StatusCode(500, new CommonResponse
                {
                    resCode = 501,
                    resMessage = errorMsg
                });
            }

        }

        #endregion

        #region ReportingList


        [Authorize]
        [HttpPost("ReportingListbyHId")]

        public async Task<IActionResult> ReportingList(int HierarchyId)
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
                var response = await _HrManual.ReportingListbyHierarchy(HierarchyId);
                if (response == null)
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

        [Authorize]
        [HttpPost("ReportingListbyName")]

        public async Task<IActionResult> ReportingListbyname(int EmpID)
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
                var response = await _HrManual.ReportingListbyreporting(EmpID);
                if (response == null)
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


        [Authorize]
        [HttpPost("SubverticalList")]

        public async Task<IActionResult> SubverticalList(int VerticalId)
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
                var response = await _HrManual.SubverticalList(VerticalId);
                if (response == null)
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

        #region Add and Update employee

        [Authorize]
        [HttpPost("AddEmployee")]

        public async Task<IActionResult> AddEmployees([FromForm]  AddEmpReqModel request)
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
                var response = await _HrManual.AddEmployee(request , LoginId);
                if (response == false)
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
                return StatusCode(500, new CommonResponse
                {
                    resCode = 501,
                    resMessage = errorMsg
                });
            }

        }

        #endregion

        #region View Employee

        [Authorize]
        [HttpGet("empdata")]

        public async Task<IActionResult> EmpData(string EmpId)
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
                var response = await _HrManual.ViewEmpDetail(LoginId , EmpId);
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
                return StatusCode(500, new CommonResponse
                {
                    resCode = 501,
                    resMessage = errorMsg
                });
            }

        }

        #endregion

        #region Delete Employee

        [Authorize]
        [HttpGet("delEmp")]

        public async Task<IActionResult> DelEmp(int EmpId)
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
                var response = await _HrManual.DeleteEmployee(EmpId);

                return StatusCode(response.resCode,response);

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

        #region EmpHistory

        [Authorize]
        [HttpGet("EmpHistory")]

        public async Task<IActionResult> EmpHistory(int EmpId)
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
                var response = await _HrManual.EmpHistory(EmpId);

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

        #region Employee Product List

        [Authorize]
        [HttpGet("EmpProduct")]

        public async Task<IActionResult> EmpProduct(int EmpId)
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
                var response = await _HrManual.EmpProductList(EmpId);
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

        #region AddEmpProduct

        [Authorize]
        [HttpPost("AddEmpProduct")]

        public async Task<IActionResult> AddEmpProduct(AddEmpProdModel request)
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
                var response = await _HrManual.AddEmpProduct(request);
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

        #region Employee Product Delete

        [Authorize]
        [HttpGet("ProdDel")]

        public async Task<IActionResult> ProdDel(int verticalId)
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
                var response = await _HrManual.DelEmpProduct(verticalId);
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

        #region HrEmpDesignationList

        [Authorize]
        [HttpPost("EmpDesignationList")]

        public async Task<IActionResult> EmpDesignationList(HrEmpDesigReqModel request)
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
                var response = await _HrManual.EmpDesignationList(request);
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

        #region DeleteDesignation

        [Authorize]
        [HttpGet("DeleteDesignation")]

        public async Task<IActionResult> DeleteDesignation(int DesignationId)
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
                var response = await _HrManual.DelDesignation(DesignationId);
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

        #region AddDesignation

        [Authorize]
        [HttpPost("AddDesignation")]

        public async Task<IActionResult> AddDesignation(AddDesigReqModel request)
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
                var response = await _HrManual.AddDesignation(request);
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

        #region EditDesignation

        [Authorize]
        [HttpPost("EditDesignation")]

        public async Task<IActionResult> EditDesignation(AddDesigReqModel request)
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
                var response = await _HrManual.EditDesignation(request);
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

        #region ViewDesignation

        [Authorize]
        [HttpGet("ViewDesignation")]

        public async Task<IActionResult> ViewDesignation(int DesignationId)
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
                var response = await _HrManual.ViewDesignation(DesignationId);
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

        #region HrHolidayList

        [Authorize]
        [HttpPost("HrHolidayList")]

        public async Task<IActionResult> HrHolidayList(HrHolidayReqModel request)
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
                var response = await _HrManual.HrHolidayList(request);
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

        #region DeleteHoliday

        [Authorize]
        [HttpGet("DeleteHoliday")]

        public async Task<IActionResult> DeleteHoliday(int HoidayId)
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
                var response = await _HrManual.DeleteHoliday(HoidayId);
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

        #region AddHoliday

        [Authorize]
        [HttpPost("AddHoliday")]

        public async Task<IActionResult> AddHoliday(AddHoliday request)
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
                var response = await _HrManual.AddHoliday(request , LoginId);
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

        #region ViewHoliday

        [Authorize]
        [HttpGet("ViewHoliday")]

        public async Task<IActionResult> ViewHoliday(int HolidayId)
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
                var response = await _HrManual.ViewHoliday(HolidayId);
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

        #region HrDeaprtment

        #region DeptList

        [Authorize]
        [HttpGet("DeptList")]

        public async Task<IActionResult> DeptList(string DeptName)
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
                var response = await _HrManual.DeptList(DeptName);
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

        #region DeleteDept

        [Authorize]
        [HttpGet("DeleteDept")]

        public async Task<IActionResult> DeleteDept(int Deptid)
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
                var response = await _HrManual.DeleteDept(Deptid);
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

        #region DeleteDept

        [Authorize]
        [HttpPost("AddDepartment")]

        public async Task<IActionResult> AddDepartment(DeptEditReqModel request)
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
                var response = await _HrManual.AddDepartment(request);
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

        #region ViewDept

        [Authorize]
        [HttpGet("ViewDept")]

        public async Task<IActionResult> ViewDept(int DeptId)
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
                var response = await _HrManual.ViewDept(DeptId);
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

        #endregion

        #region HrEmpTarget

        #region HrEmpTargetList

        [Authorize]
        [HttpPost("HrEmpTargetList")]

        public async Task<IActionResult> HrEmpTargetList(TargetListReqModel request)
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
                var response = await _HrManual.HrEmpTargetList(request);
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

        public async Task<IActionResult> HrEmpTargPrincipalListetList()
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
                var response = await _HrManual.PrincipalList();
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

        #region AddTarget

        [Authorize]
        [HttpPost("AddTarget")]

        public async Task<IActionResult> AddTarget(AddTargetReqModel request)
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
                var response = await _HrManual.AddTarget(LoginId, request);
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

        #region AddTarget

        [Authorize]
        [HttpGet("DelTarget")]

        public async Task<IActionResult> DelTarget(int TargetDetailId)
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
                var response = await _HrManual.DelTarget(TargetDetailId);
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

        #region TargetDetail

        [Authorize]
        [HttpGet("TargetDetail")]

        public async Task<IActionResult> TargetDetail(int TargetDetailId)
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
                var response = await _HrManual.TargetDetail(TargetDetailId);
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

        #endregion

    }
}

#pragma warning restore CS8602 // Possible null reference assignment.
