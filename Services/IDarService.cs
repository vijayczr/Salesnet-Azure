using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SalesNet.Controllers;
using SalesNet.DapperContext;
using SalesNet.DataEntities;
using SalesNet.Helpers;
using SalesNet.Models.Request;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using SalesNet.Models.Response;
using SalesNet.Model;
using System.Drawing;
using System.Text;
using Microsoft.CodeAnalysis;
using System.DirectoryServices.AccountManagement;
using Microsoft.AspNetCore.Mvc;
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
namespace SalesNet.Services
{
    public interface IDarService
    {
        public  Task<CommonResponse> DarList(string LoginId, DarListReQModel request);
        public Task<CommonResponse> CustomerNames(string Search);
        public Task<CommonResponse> darquartertarget(string LoginId);
        public Task<CommonResponse> customerList();
        public Task<CommonResponse> AppEngineer();
        public Task<CommonResponse> CustpersonList(int CustId);
        public Task<CommonResponse> CustDetail(int CustId);
        public Task<CommonResponse> PrincipalList();
        public Task<CommonResponse> ProductListByPrincipalId(int PrincipalId);
        public Task<CommonResponse> DarEntry(AddDarRqModel request, string EmpId);
        public Task<CommonResponse> DarFileUpload([FromForm] DarDocReqModel request);
        public Task<CommonResponse> ViewDar(int DarId);

    }

    public class Dar : IDarService
    {
        private AdventureContext _DBContext;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly AppSettings _appsettings;

        public Dar(ILogger<AuthenticationController> logger, AdventureContext dbcontext, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _DBContext = dbcontext;
            _appsettings = appSettings.Value;
        }

        #region DarList

        public async Task<CommonResponse> DarList(string LoginId, DarListReQModel request)
        {
            try
            {
                var employeename = await _DBContext.SnEmployees
                                                        .Where(u => u.EmployeeId == int.Parse(LoginId))
                                                        .Select(u => u.EmpName)
                                                        .FirstOrDefaultAsync();

                var data = await _DBContext.SnDars.Where(u => u.EmpId == int.Parse(LoginId)
                                                && u.IsDeleted == false
                                                && (request.Search == null || _DBContext.SnCustomers
                                                            .Where(m => m.CustomerId == u.CustId)
                                                            .Select(m => m.CustomerName)
                                                            .FirstOrDefault().ToLower().Contains(request.Search.ToLower()))
                                                )
                                        .Select(u => new DarListResModel()
                                        {
                                            DarId = u.DarId,
                                            Employee = employeename,
                                            Leadid = u.LeadId,
                                            Customer = _DBContext.SnCustomers
                                                            .Where(m => m.CustomerId == u.CustId)
                                                            .Select(m => m.CustomerName)
                                                            .FirstOrDefault(),
                                            ContactPerson = _DBContext.SnCustomerContacts
                                                                .Where(m => m.CustContactId == u.ContactPersonId)
                                                                .Select(m => m.ContactPerson)
                                                                .FirstOrDefault(),
                                            VisitDate = u.VisitDate.ToString().Substring(0, 11),
                                            Products = (from p in _DBContext.SnProducts
                                                        join A in _DBContext.SnDarProducts on p.ProductId equals A.ProductId
                                                        where A.DarId == u.DarId && A.IsDeleted == false
                                                        select p.ProductName).FirstOrDefault()

                                        }).ToListAsync();

                if (data == null)
                {
                    return new CommonResponse() { resCode = 400, resMessage = "Bad Request!" };
                }
                data.Reverse();
                var Data = data.AsQueryable().DistinctBy(u => u.Leadid);
                var count = Data.Count();

                var response = new DarListModel()
                {
                    Data = Data.Skip((request.pageNumber - 1) * request.pageSize)
                            .Take(request.pageSize).ToList(),
                    Totalcount = count
                };
                return new CommonResponse() { resCode = 200, resData = response, resMessage = "Success" };

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "internal Server Error!" };
            }
        }

        #endregion

        #region CustomerNamesSearch

        public async Task<CommonResponse> CustomerNames(string Search)
        {
            try
            {
                var data = await _DBContext.SnCustomers
                                        .Where(u => u.CustomerName.ToLower().Contains(Search.ToLower()))
                                        .Select(u => u.CustomerName).ToListAsync();
                if (data == null)
                {
                    return new CommonResponse() { resCode = 400, resMessage = "Bad Request" };
                }
                var response = new List<CustNameResModel>();
                foreach (var u in data)
                {
                    var entry = new CustNameResModel()
                    {
                        label = u,
                        value = u
                    };
                    response.Add(entry);
                }
                return new CommonResponse() { resCode = 200, resData = response, resMessage = "Success!" };

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Internal Server error" };
            }
        }

        #endregion

        #region DarQuarterTarget
        public async Task<CommonResponse> darquartertarget(string LoginId)
        {
            var response = new List<double?>();

            var QuarterData = new QuarterResModel();

            for (int QId = 1; QId <= 4; QId++)
            {
                var months = await _DBContext.SnQuarterMasters.Where(u => u.Qid == QId)
                                    .Select(u => new Quartermonth()
                                    {
                                        StartMonth = u.QstartMonthId,
                                        EndMonth = u.QendMonthId
                                    }).FirstOrDefaultAsync();

                var Year = DateTime.Now.Year;
                var startDate = new DateTime();
                var endDate = new DateTime();
                if (QId != 4)
                {

                    if (months.EndMonth < 10)
                    {
                        startDate = DateTime.Parse($"01-0{months.StartMonth}-{Year}");
                        endDate = DateTime.Parse($"{DateTime.DaysInMonth(Year, (int)months.EndMonth)}-0{months.EndMonth}-{Year}");
                    }
                    else
                    {
                        startDate = DateTime.Parse($"01-{months.StartMonth}-{Year}");
                        endDate = DateTime.Parse($"{DateTime.DaysInMonth(Year, (int)months.EndMonth)}-{months.EndMonth}-{Year}");
                    }
                }
                else
                {
                    if (months.EndMonth < 10)
                    {
                        startDate = DateTime.Parse($"01-0{months.StartMonth}-{Year + 1}");
                        endDate = DateTime.Parse($"{DateTime.DaysInMonth(Year, (int)months.EndMonth)}-0{months.EndMonth}-{Year + 1}");
                    }
                    else
                    {
                        startDate = DateTime.Parse($"01-{months.StartMonth}-{Year + 1}");
                        endDate = DateTime.Parse($"{DateTime.DaysInMonth(Year, (int)months.EndMonth)}-{months.EndMonth}-{Year + 1}");
                    }
                }

                var data = await (from d in _DBContext.SnDars
                                  join op in _DBContext.SnOrderProcessings on d.DarId equals op.DarId
                                  where d.EmpId == int.Parse(LoginId) && d.VerticalId == 1 && d.IsDeleted == false
                                  && op.OrderDate >= startDate && op.OrderDate < endDate
                                  select op.OrderId
                                   ).ToListAsync();
                if (data.Count() == 0)
                {
                    response.Add(0);
                }
                foreach (var item in data)
                {
                    var achValue = await (from opL in _DBContext.SnOrderPrincipals
                                          join opS in _DBContext.SnOrderProducts on opL.OrderPrincipalId equals opS.OrderPrincipalId
                                          where opL.OrderId == item
                                          select opS.AchPrice).SumAsync();
                    response.Add(achValue);
                }
            }

            int? startYear = DateTime.Now.Year;
            int? endYear = startYear + 1;
            if (DateTime.Now.Month >= 1 && DateTime.Now.Month < 4)
            {
                startYear = startYear - 1;
                endYear = endYear - 1;
            }



            var EmpTargetId = await _DBContext.SnEmployeeTargetMasters
                                                .Where(u => u.EmployeeId == int.Parse(LoginId)
                                                        && u.StartYear == startYear
                                                        && u.EndYear == endYear)
                                                .Select(u => u.EmployeeTargetId)
                                                .FirstOrDefaultAsync();


            //var EmpTargetId = await _DBContext.Database.SqlQuery<int>($"""select EmployeeTargetId from SN_EmployeeTargetMaster where EmployeeId = {int.Parse(LoginId)} and StartYear = {startYear} and EndYear = {endYear}""").FirstOrDefaultAsync();

            #region ASG

            var ASGRvenuePerc = await _DBContext.SnRevenuePercentages
                                .Where(u => u.StartYear == startYear && u.EndYear == endYear && u.VerticalId == 1)
                                .Select(u => u.ProductPercentage)
                                .FirstOrDefaultAsync();

            var AsgQ1 = await _DBContext.SnEmployeeTargetDetails
                                                     .Where(u => u.EmployeeTargetId == EmpTargetId
                                                              && u.VerticalId == 1 && u.Qid == 1)
                                                     .Select(u => u.TargetAmount).SumAsync();
            var AsgQ2 = await _DBContext.SnEmployeeTargetDetails
                                         .Where(u => u.EmployeeTargetId == EmpTargetId
                                                  && u.VerticalId == 1 && u.Qid == 2)
                                         .Select(u => u.TargetAmount).SumAsync();
            var AsgQ3 = await _DBContext.SnEmployeeTargetDetails
                             .Where(u => u.EmployeeTargetId == EmpTargetId
                                      && u.VerticalId == 1 && u.Qid == 3)
                             .Select(u => u.TargetAmount).SumAsync();
            var AsgQ4 = await _DBContext.SnEmployeeTargetDetails
                             .Where(u => u.EmployeeTargetId == EmpTargetId
                                      && u.VerticalId == 1 && u.Qid == 4)
                             .Select(u => u.TargetAmount).SumAsync();
            QuarterData.RevenueAsgQ1 = CommaSeparatedAmt((Double.Parse((ASGRvenuePerc / 100).ToString()) * AsgQ1).ToString());
            QuarterData.TargetAsgQ1 = CommaSeparatedAmt(AsgQ1.ToString());
            QuarterData.RevenueAsgQ2 = CommaSeparatedAmt((Double.Parse((ASGRvenuePerc / 100).ToString()) * AsgQ2).ToString());
            QuarterData.TargetAsgQ2 = CommaSeparatedAmt(AsgQ2.ToString());
            QuarterData.RevenueAsgQ3 = CommaSeparatedAmt((Double.Parse((ASGRvenuePerc / 100).ToString()) * AsgQ3).ToString());
            QuarterData.TargetAsgQ3 = CommaSeparatedAmt(AsgQ3.ToString());
            QuarterData.RevenueAsgQ4 = CommaSeparatedAmt((Double.Parse((ASGRvenuePerc / 100).ToString()) * AsgQ4).ToString());
            QuarterData.TargetAsgQ4 = CommaSeparatedAmt(AsgQ4.ToString());

            var totalASG = AsgQ1 + AsgQ2 + AsgQ3 + AsgQ4;

            QuarterData.TotalAsgTarget = CommaSeparatedAmt(totalASG.ToString());
            QuarterData.TotalAsgRevenueTarget = CommaSeparatedAmt((Double.Parse((ASGRvenuePerc / 100).ToString()) * totalASG).ToString());

            #endregion

            #region ISG

            if (_DBContext.SnEmployeeTargetDetails
                                         .Where(u => u.EmployeeTargetId == EmpTargetId
                                                  && u.VerticalId == 2 && u.Qid == 1)
                                         .Select(u => u.TargetAmount).FirstOrDefault() != null)
            {
                var IsgRevenuePerc = await _DBContext.SnRevenuePercentages
                                .Where(u => u.StartYear == startYear && u.EndYear == endYear && u.VerticalId == 2)
                                .Select(u => u.ProductPercentage)
                                .FirstOrDefaultAsync();

                var IsgQ1 = await _DBContext.SnEmployeeTargetDetails
                             .Where(u => u.EmployeeTargetId == EmpTargetId
                                      && u.VerticalId == 2 && u.Qid == 1)
                             .Select(u => u.TargetAmount).SumAsync();
                var IsgQ2 = await _DBContext.SnEmployeeTargetDetails
                             .Where(u => u.EmployeeTargetId == EmpTargetId
                                      && u.VerticalId == 2 && u.Qid == 2)
                             .Select(u => u.TargetAmount).SumAsync();
                var IsgQ3 = await _DBContext.SnEmployeeTargetDetails
                             .Where(u => u.EmployeeTargetId == EmpTargetId
                                      && u.VerticalId == 2 && u.Qid == 3)
                             .Select(u => u.TargetAmount).SumAsync();
                var IsgQ4 = await _DBContext.SnEmployeeTargetDetails
                             .Where(u => u.EmployeeTargetId == EmpTargetId
                                      && u.VerticalId == 2 && u.Qid == 4)
                             .Select(u => u.TargetAmount).SumAsync();
                QuarterData.TargetIsgQ1 = CommaSeparatedAmt(IsgQ1.ToString());
                QuarterData.TargetIsgQ2 = CommaSeparatedAmt(IsgQ2.ToString());
                QuarterData.TargetIsgQ3 = CommaSeparatedAmt(IsgQ3.ToString());
                QuarterData.TargetIsgQ4 = CommaSeparatedAmt(IsgQ4.ToString());
                QuarterData.RevenueIsgQ1 = CommaSeparatedAmt((Double.Parse((IsgRevenuePerc / 100).ToString()) * IsgQ1).ToString());
                QuarterData.RevenueIsgQ2 = CommaSeparatedAmt((Double.Parse((IsgRevenuePerc / 100).ToString()) * IsgQ2).ToString());
                QuarterData.RevenueIsgQ3 = CommaSeparatedAmt((Double.Parse((IsgRevenuePerc / 100).ToString()) * IsgQ3).ToString());
                QuarterData.RevenueIsgQ4 = CommaSeparatedAmt((Double.Parse((IsgRevenuePerc / 100).ToString()) * IsgQ4).ToString());

                var totalISG = IsgQ1 + IsgQ2 + IsgQ3 + IsgQ4;

                QuarterData.TotalAsgTarget = CommaSeparatedAmt(totalISG.ToString());
                QuarterData.TotalAsgRevenueTarget = CommaSeparatedAmt((Double.Parse((IsgRevenuePerc / 100).ToString()) * totalISG).ToString());
            }

            #endregion


            QuarterData.Achivement = response;

            return new CommonResponse() { resCode = 200, resData = QuarterData, resMessage = "Success!" };
        }

        #endregion

        #region AmountToLac

        private string CommaSeparatedAmt(string strAmtount)
        {
            if (string.IsNullOrEmpty(strAmtount))
                return "0.00 lac";
            string str1 = strAmtount;
            if (Convert.ToDouble(str1) < 0.0)
                strAmtount = strAmtount.ToString().Substring(1, strAmtount.Length - 1);
            string[] strArray = strAmtount.Split('.');
            string str2 = Convert.ToString(Math.Round(Convert.ToDouble(strArray[0]) / 100000.0, 2));
            if (strArray.Length == 1)
            {
                if (Convert.ToDouble(str1) < 0.0)
                    return "-" + str2 + " lac";
                if (Convert.ToDouble(str1) == 0.0)
                    return str2 + ".00 lac";
                return str2 + " lac";
            }
            if (Convert.ToDouble(str1) < 0.0)
                return "-" + str2 + " lac";
            if (Convert.ToDouble(str1) == 0.0)
                return str2 + ".00 lac";
            return str2 + " lac";
        }

        #endregion

        #region customerList

        public async Task<CommonResponse> customerList()
        {
                var data = await _DBContext.SnCustomers
                                            .Where(u =>  u.IsDeleted == false
                                                    && u.CustomerStatus == true)
                                            .Select(u => new CustListResModel()
                                            {
                                                Label = u.CustomerName,
                                                Value = u.CustomerId
                                            }).ToListAsync();
            return new CommonResponse() { resCode = 200, resData = data, resMessage = "Success!" };
        }

        #endregion

        #region AppEngineer

        public async Task<CommonResponse> AppEngineer()
        {
            try
            {
                var data = await _DBContext.SnEmployees
                                                .Where(u => u.HierarchyId == 10
                                                        && u.EmpStatus == true
                                                        && u.IsDeleted == false)
                                                .Select(u => new AppEnggResModel()
                                                {
                                                    EmpName = u.EmpName,
                                                    EmpId = u.EmployeeId
                                                }).ToListAsync();
                if(data == null)
                {
                    return new CommonResponse() { resCode = 400, resMessage = "Bad Request" };
                }
                return new CommonResponse() { resCode = 200, resData = data, resMessage = "Success!" };
                                
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Internal server error" };
            }
        }

        #endregion

        #region LeadList

        public async Task<CommonResponse> LeadList(string LoginId)
        {
            try
            {
                var heirarchyId = await _DBContext.SnEmployees
                                            .Where(u => u.EmployeeId == int.Parse(LoginId))
                                            .Select(u => u.HierarchyId)
                                            .FirstOrDefaultAsync();
                return new CommonResponse();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                throw;
            }
        }

        #endregion

        #region CustPersonList

        public async Task<CommonResponse> CustpersonList(int CustId)
        {
            var data = await _DBContext.SnCustomerContacts
                                .Where(u => u.CustomerId == CustId
                                        && u.IsDeleted == false)
                                .Select(u => new CustContactListResModel()
                                {
                                    CustId = u.CustContactId,
                                    ContactPerson = u.ContactPerson
                                }).ToListAsync();
            if (data == null)
            {
                return new CommonResponse() { resCode = 400, resMessage = "Bad Request!" };
            }
            return new CommonResponse() { resCode = 200, resData = data, resMessage = "Success!" };
        }

        #endregion

        #region CustDetail

        public async Task<CommonResponse> CustDetail(int CustId)
        {
            var data = await _DBContext.SnCustomerContacts
                                            .Where(u => u.CustContactId == CustId
                                                    && u.IsDeleted == false)
                                            .Select(u => new CustDetailResModel()
                                            {
                                                CustId = u.CustContactId,
                                                ContactPerson = u.ContactPerson,
                                                PhoneNo = u.ContactPhone,
                                                MobileNo = u.ContactMobile,
                                                CustDepartment = u.CustDepartment,
                                                CustDesgn = u.CustDesignation,
                                                Email = u.ContactEmail
                                            }).FirstOrDefaultAsync();
            if(data == null)
            {
                return new CommonResponse() { resCode = 400, resMessage = "Bad Request!" };
            }
            return new CommonResponse() { resCode = 200, resData = data, resMessage = "Success!" };
        }

        #endregion

        #region PrincipalList

        public async Task<CommonResponse> PrincipalList()
        {
            var data = await _DBContext.SnPrincipalMasters
                                .Where(u => u.IsDeleted == false)
                                .OrderByDescending(u=>u.CreatedOn)
                                .Select(u => new PrincipalListResModel()
                                {
                                    PrincipalId = u.PrincipalId,
                                    PrincipalName = u.PrincipalName
                                }).ToListAsync();
            if(data == null)
            {
                return new CommonResponse() { resCode = 400, resMessage = "Success!" };
            }
            return new CommonResponse() { resCode = 200, resData = data, resMessage = "Success!" };
        }

        #endregion

        #region ProductListByPrincipalId

        public async Task<CommonResponse> ProductListByPrincipalId(int PrincipalId)
        {
            try
            {
                //StringBuilder myString = new StringBuilder();
                //myString.Append("select * from SN_Employees where EmployeeId = 1");
                //var x = ("select * from SN_Employees where EmployeeId = 1");
                //var m = new productList();

                //var x = @"select max(p.ProductId) as ProductId , max(p.ProductName) as ProductName from SN_Products p
                //          left outer join SN_PrincipalMaster pm on p.PrincipalId = pm.PrincipalId
                //          where p.PrincipalId = 30 and p.IsDeleted = 0 and p.ProductStatus = 1
                //          group by PrincipalName";
                //var data = _DBContext.Database.SqlQuery<productList>($"{x}");

                //var data = await (from p in _DBContext.SnProducts
                //                  join pm in _DBContext.SnPrincipalMasters on p.PrincipalId equals pm.PrincipalId
                //                  where p.PrincipalId == PrincipalId && p.IsDeleted == false && p.PrincipalId == 1
                //                  select new productList()
                //                  {
                //                      ProductId = p.ProductId,
                //                      ProductName = p.ProductName,
                //                  }
                //                  ).ToListAsync();

                var data = await _DBContext.SnProducts
                                    .Where(u => u.PrincipalId == PrincipalId && u.Price != null)
                                    .Select(u=> new productList()
                                    {
                                        ProductId = u.ProductId,
                                        ProductName = u.ProductName,
                                        ProductValue = u.Price,
                                        QuotedPrice = u.Price,
                                        TechlabPrice = u.Price,
                                        Description  = u.ProductDescription
                                    }).ToListAsync();


                //var data = _DBContext.SnEmployees.Where(u => u.EmployeeId == 1).Select(u => u.EmpName).FirstOrDefault();
                return new CommonResponse() { resCode = 200, resData = data, resMessage = "Success!" };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                throw;
            }
        }

        #endregion

        #region DarEntry

        public async Task<CommonResponse> DarEntry(AddDarRqModel request, string EmpId)
        {
            if(request.CustomerId == 0)
            {
                return new CommonResponse() { resCode = 400, resMessage = "Bad Request!!" };
            }
            int? leadId = await _DBContext.SnDars.Select(u => u.LeadId).OrderByDescending(u => u).FirstOrDefaultAsync();
            try
            {
                var newDar = new SnDar()
                {
                    EmpId = int.Parse(EmpId),   
                    LeadId = leadId + 1,
                    CustId = request.CustomerId,
                    ContactPersonId = request.ContactPersonId,
                    CallTypeId = request.CallTypeId,
                    CallStatusId = request.CallStatusId,
                    DarStatusId = request.DarStatusId,
                    DarStageId = request.OpportunityStatus,
                    Price = request.Price,
                    CreatedBy = int.Parse(EmpId),
                    CreatedOn = DateTime.Now,
                    DarRemark = request.DarRemark,
                    VisitDate = request.VisitDate,
                    VisitTime = request.VisitTime,
                    LeadTypeId = request.LeadTypeId,
                    NextActionDate = (request.NextActionDate == null)? null : DateTime.Parse(request.NextActionDate),
                    DarClosingDate = (request.DarClosingDate == null) ? null : DateTime.Parse(request.DarClosingDate),
                    LostReasonId  = request.LostReasonId,
                    IsFundAvailable = request.IsFundAvailable,
                    IsDeleted = false,
                    AdvancePay = request.AdvancePay,
                    DeliveryPay = request.DeliveryPay,
                    TrainingPay = request.TrainingPay,
                    Gst = request.GST,
                    TotalOrderValue = request.OrderValue,
                    ActualValue = request.ActualValue,
                    AppEnggId = request.AppEngId,
                    MonthOfOrder = (request.MonthOfOrder == null) ? null : DateTime.Parse(request.MonthOfOrder),
                    VerticalId = request.VerticalId
                };
                await _DBContext.SnDars.AddAsync(newDar);
                await _DBContext.SaveChangesAsync();
                var DarProductData = new SnDarProduct()
                {
                    DarId = newDar.DarId,
                    ProductId = request.ProductId,
                    DarProductPrice = request.DarProductPrice,
                    QuotedPrice = request.QuotedPrice,
                    ProductValue = request.ProductValue,
                    IsDeleted = false
                };
                await _DBContext.SnDarProducts.AddAsync(DarProductData);
                await _DBContext.SaveChangesAsync();
                return new CommonResponse() { resCode = 200, resData = newDar.DarId, resMessage = "Success" };
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                throw;
            }
           
        }

        #endregion

        #region DarFileUpload

        public async Task<CommonResponse> DarFileUpload([FromForm] DarDocReqModel request)
        {
            var res = false;
            try
            {
                var darData = await _DBContext.SnDars.Where(u => u.DarId == int.Parse(request.DarId)).FirstOrDefaultAsync();
                string currentDir = System.IO.Directory.GetCurrentDirectory();
                var path = currentDir + "//Uploads//DARDocuments";
                using (var stream = new FileStream(Path.Combine(path, request.DarDoc.FileName), FileMode.Create))
                {
                    request.DarDoc.CopyTo(stream);
                }
                darData.DocumentPath = "~//Uploads//HRDocuments//" + request.DarDoc.FileName;
                await _DBContext.SaveChangesAsync();
                res = true;
                return new CommonResponse() { resCode = 200, resData = res, resMessage = "Success!" };
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                throw;
            }
        }

        #endregion

        #region ViewDar

        public async Task<CommonResponse> ViewDar(int DarId)
        {
            try
            {
                var DarData = await _DBContext.SnDars.Where(u => u.DarId == DarId).FirstOrDefaultAsync();
                var DarProduct = await _DBContext.SnDarProducts.Where(u => u.DarId == DarId).FirstOrDefaultAsync();
                var CustDetail = await _DBContext.SnCustomerContacts.Where(u => u.CustContactId == DarData.ContactPersonId).FirstOrDefaultAsync();

                var percentval = (DarData.Gst / (DarData.TotalOrderValue / 100)).ToString();

                var Data = new ViewDarResModel();

                Data.LeadId = DarData.LeadId;
                Data.CustomerId = DarData.CustId;
                Data.ContactPersonId = DarData.ContactPersonId;
                Data.CallTypeId = DarData.CallTypeId;
                Data.CallStatusId = DarData.CallStatusId;
                Data.VerticalId = DarData.VerticalId;
                Data.OpportunityStatus = DarData.DarStageId;
                Data.DarStatusId = DarData.DarStatusId;
                Data.Price = DarData.Price;
                Data.DarRemark = DarData.DarRemark;
                Data.VisitDate = DarData.VisitDate;
                Data.VisitTime = DarData.VisitTime;
                Data.LeadTypeId = DarData.LeadTypeId;
                Data.NextActionDate = DarData.NextActionDate;
                Data.DarClosingDate = DarData.DarClosingDate;
                Data.LostReasonId = DarData.LostReasonId;
                Data.IsFundAvailable = DarData.IsFundAvailable;
                Data.AdvancePay = DarData.AdvancePay;
                Data.DeliveryPay = DarData.DeliveryPay;
                Data.TrainingPay = DarData.TrainingPay;
                if(percentval == "NaN")
                {
                    Data.GstPerc = 0;
                }
                else
                {
                    Data.GstPerc = (int)Decimal.Truncate(Decimal.Parse(percentval));
                }
                Data.GST = DarData.Gst;
                Data.OrderValue = DarData.TotalOrderValue;
                Data.ActualValue = DarData.ActualValue;
                Data.AppEngId = DarData.AppEnggId;
                Data.MonthOfOrder = DarData.MonthOfOrder;
                Data.ProductId = DarProduct.ProductId;
                Data.ProductName = _DBContext.SnProducts.Where(u => u.ProductId == DarProduct.ProductId)
                                                       .Select(u => u.ProductName)
                                                       .FirstOrDefault();
                Data.DarProductPrice = DarProduct.DarProductPrice;
                Data.QuotedPrice = DarProduct.QuotedPrice;
                Data.ProductValue = DarProduct.ProductValue;
                Data.PhoneNo = CustDetail.ContactPhone;
                Data.MobileNo = CustDetail.ContactMobile;
                Data.Email = CustDetail.ContactEmail;
                Data.PrincipalId = await _DBContext.SnProducts.Where(u=>u.ProductId== DarProduct.ProductId)
                                                              .Select(u=>u.PrincipalId)
                                                              .FirstOrDefaultAsync();
                Data.CustDepartment = CustDetail.CustDepartment;
                Data.CustDesgn = CustDetail.CustDesignation;
                

                return new CommonResponse() { resCode = 200, resData = Data, resMessage = "Success" };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Something went wrong!" };
            }



        }

        #endregion

    }
}
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8604 // Possible null reference argument.