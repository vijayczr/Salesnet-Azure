using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Ocsp;
using SalesNet.Controllers;
using SalesNet.DataEntities;
using SalesNet.Helpers;
using SalesNet.Model;
using SalesNet.Models.Request;
using SalesNet.Models.Response;
#pragma warning disable CS8601 // Possible null reference assignment.
#pragma warning disable CS8602 // Possible null reference assignment.
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CA2200 // Rethrow to preserve stack details
#pragma warning disable CS8603 // Possible null reference return.

namespace SalesNet.Services
{
    public interface IHrmanualService
    {
        public Task<HrmanualresModel> hrmanual(HrManualRequestModel request);
        public Task<(byte[], string, string)> DownloadFile(string DocumentType);
        public Task<CommonResponse> ManualInfo(string Docinfo);
        public Task<empListResModel> hremployeelist(HrEmpListReqModel request);
        public Task<CommonResponse> ReportingListbyHierarchy(int HierarchyId);
        public Task<CommonResponse> ReportingListbyreporting(int EmpId);
        public Task<CommonResponse> SubverticalList(int verticalId);
        public Task<bool> AddEmployee([FromForm] AddEmpReqModel Request, string HrId);
        public Task<AddEmpReqModel1> ViewEmpDetail(string HrId, string EmpId);
        public Task<CommonResponse> DeleteEmployee(int employeeId);
        public Task<CommonResponse> EmpHistory(int EmployeeId);
        public Task<CommonResponse> EmpProductList(int EmployeeId);
        public Task<CommonResponse> AddEmpProduct(AddEmpProdModel request);
        public Task<CommonResponse> DelEmpProduct(int ProdId);
        public Task<CommonResponse> EmpDesignationList(HrEmpDesigReqModel request);
        public Task<CommonResponse> DelDesignation(int designationId);
        public Task<CommonResponse> AddDesignation(AddDesigReqModel request);
        public Task<CommonResponse> EditDesignation(AddDesigReqModel request);
        public Task<CommonResponse> ViewDesignation(int DesigntionId);
        public Task<CommonResponse> HrHolidayList(HrHolidayReqModel request);
        public Task<CommonResponse> DeleteHoliday(int HoidayId);
        public Task<CommonResponse> AddHoliday(AddHoliday request, string UserId);
        public Task<CommonResponse> ViewHoliday(int HolidayId);
        public Task<CommonResponse> DeptList(string DeptName);
        public Task<CommonResponse> DeleteDept(int Deptid);
        public Task<CommonResponse> AddDepartment(DeptEditReqModel request);
        public Task<CommonResponse> ViewDept(int DeptId);
        public Task<CommonResponse> HrEmpTargetList(TargetListReqModel request);
        public Task<CommonResponse> PrincipalList();
        public Task<CommonResponse> AddTarget(string LoginId, AddTargetReqModel request);
        public Task<CommonResponse> DelTarget(int TargetDetailId);
        public Task<CommonResponse> TargetDetail(int TargetDetailId);
    }


    public class HrManual : IHrmanualService
    {
        private AdventureContext _DBContext;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly AppSettings _appsettings;
        public HrManual(ILogger<AuthenticationController> logger, AdventureContext dbcontext, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _DBContext = dbcontext;
            _appsettings = appSettings.Value;
        }

        #region HrManualList
        public async Task<HrmanualresModel> hrmanual(HrManualRequestModel request)
        {
            var data = new HrmanualresModel();
            if(request.Type == "")
            {
                try
                {
                    data.hrmanuals = await (from p in _DBContext.Hrmanuals
                                  select new HrManualResponseModel()
                                  {
                                      Type = p.DocumentType,
                                      Document = p.Subject
                                  }).Skip((request.pageNumber-1) * request.pageSize)
                                     .Take(request.pageSize).ToListAsync();
                    data.Totalcount = await _DBContext.Hrmanuals.CountAsync();
                }
                catch(Exception ex)
                {
                    _logger.Log(LogLevel.Information , ex.Message);
                }
            }
            else
            {
                try
                {

                    data.hrmanuals = await (from p in _DBContext.Hrmanuals
                                            .Where(u=> 
                                                   u.DocumentType.Contains(request.Type))
                                            select new HrManualResponseModel()
                                            {
                                                Type = p.DocumentType,
                                                Document = p.Subject
                                            }).Skip((request.pageNumber - 1) * request.pageSize)
                                     .Take(request.pageSize).ToListAsync();

                    data.Totalcount = await _DBContext.Hrmanuals.CountAsync();
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Information, ex.Message);
                }
            }
            return data;
        }

        #endregion

        #region HrDocumentDownload

        public async Task<(byte[], string, string)> DownloadFile(string DocumentType)
        {
            try
            {
                var filepath = await _DBContext.Hrmanuals.Where(u => u.DocumentType == DocumentType).Select(u => u.HrdocumentPath).FirstOrDefaultAsync();
                filepath = filepath.TrimStart('~');
                //imagepath = imagepath.Remove(0, 2);
                //imagepath = "/" + imagepath;
                filepath = filepath.Replace(@"\", "/");
                string currentDir = System.IO.Directory.GetCurrentDirectory();
                var filepath1 = currentDir + filepath;
                var provider = new FileExtensionContentTypeProvider();
                if (!provider.TryGetContentType(filepath1, out var _ContentType))
                {
                    _ContentType = "application/octet-stream";
                }
                var _ReadAllBytesAsync = await File.ReadAllBytesAsync(filepath1);
                _logger.Log(LogLevel.Information , _ReadAllBytesAsync.ToString());
                return (_ReadAllBytesAsync, _ContentType, Path.GetFileName(filepath1));
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());

                throw ex;

            }
        }

        #endregion

        #region DocumentInfo

        public async Task<CommonResponse> ManualInfo(string Docinfo)
        {

            try
            {
                var data = await _DBContext.Hrmanuals.Where(u => u.DocumentType == Docinfo).FirstOrDefaultAsync();
                if (data != null)
                {
                    var res = new ManualInfoResponseModel()
                    {
                        Document = data.DocumentType,
                        Type = data.Subject,
                        Instruction = data.Hrdescription
                    };
                    return new CommonResponse() { resCode = 200,resData = res ,resMessage = "Success" };
                }
                else
                {
                    return new CommonResponse() { resCode = 404, resData = null  ,resMessage = "Not Found" };
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 500, resData = null, resMessage = "Something went wrong" };
            }
        }

        #endregion

        #region hremployeelist

        public async Task<empListResModel> hremployeelist(HrEmpListReqModel request)
        {
            var res = new empListResModel();

            var data = await _DBContext.SnEmployees
                                        .Where(u =>    u.EmpName != "Admin"
                                                    && (request.GroupName == null || u.GroupName == request.GroupName)
                                                    && (request.Vertical == 7 || u.VerticalId == request.Vertical)
                                                    && (request.Name == null || u.EmpName.Contains(request.Name))
                                                    && (request.IsActive == null || u.EmpStatus == request.IsActive)
                                                    && (request.Designation == 999 || u.DesignationId == request.Designation)
                                                    )
                                        .Select(u => new HrEmpListResModel()
                                        {
                                            UserId = u.EmployeeId,
                                            Name = u.EmpName,
                                            ReportingTo = _DBContext.SnEmployees
                                                                    .Where(m => m.EmployeeId == u.ReportingHeadId)
                                                                    .Select(p => p.EmpName)
                                                                    .FirstOrDefault(),
                                            Branch =   (u.BranchId != null) ? _DBContext.SnBranchMasters
                                                                    .Where(m => m.BranchId == u.BranchId)
                                                                    .Select(m => m.BranchName)
                                                                    .FirstOrDefault() : u.GroupName,
                                            Vertical = _DBContext.SnVerticalMasters
                                                                    .Where(m => m.VerticalId == u.VerticalId)
                                                                    .Select(m => m.VerticalName)
                                                                    .FirstOrDefault(),
                                            Designation = _DBContext.SnDesignationMasters
                                                                    .Where(m => m.DesignationId == u.DesignationId)
                                                                    .Select(m => m.DesignationName)
                                                                    .FirstOrDefault(),
                                            Status = (u.EmpStatus == true) ? "Actice" : "Inactive"
                                        }).ToListAsync();
            data.Reverse();
            res.data = data
                            .Where(u=> request.Branch == null || u.Branch == request.Branch)
                            .Skip((request.pageNumber - 1) * request.pageSize)
                            .Take(request.pageSize)
                            .ToList();
            res.totalCount = data.Count();

            return res;
        }

        #endregion

        #region ReportingList

        public async Task<CommonResponse> ReportingListbyHierarchy(int HierarchyId)
        {
            if(HierarchyId == 0)
            {
                HierarchyId = 10;
            }
            var data = await _DBContext.SnEmployees
                                        .Where(u =>   u.TeamBelongsTo != "Others" 
                                                   && u.HierarchyId <= HierarchyId
                                                   && u.EmpStatus == true
                                                   && u.IsDeleted == false
                                                   && u.IsSalesNetUser == true
                                                   && u.EmpName != "Admin"
                                               )
                                        .Select(u => new teamBelongListResModel()
                                        {
                                            Name = u.EmpName,
                                            EmployeeId = u.EmployeeId
                                        }).ToListAsync();

            var res = new CommonResponse() { resCode = 200 ,resData = data , resMessage= "Success!" };
            return res;
        }

        public async Task<CommonResponse> ReportingListbyreporting(int EmpId)
        {
            var heirarchyId = _DBContext.SnEmployees.Where(u=>u.EmployeeId == EmpId).Select(u=>u.HierarchyId).FirstOrDefault();
            var data = await _DBContext.SnEmployees
                                        .Where(u => u.TeamBelongsTo != "Others"
                                                   && u.HierarchyId < heirarchyId
                                                   && u.EmpStatus == true
                                                   && u.IsDeleted == false
                                                   && u.IsSalesNetUser == true
                                                   && u.EmpName != "Admin"
                                               )
                                        .Select(u => new teamBelongListResModel()
                                        {
                                            Name = u.EmpName,
                                            EmployeeId = u.EmployeeId
                                        }).ToListAsync();

            var res = new CommonResponse() { resCode = 200, resData = data, resMessage = "Success!" };
            return res;
        }

        public async Task<CommonResponse> SubverticalList(int verticalId)
        {
            var data = await _DBContext.SnSubVerticalMasters
                            .Where(u => u.VerticalId == verticalId)
                            .Select(u => u.SubVerticalName)
                            .ToListAsync();

            var res = new CommonResponse() { resCode = 200 , resData = data ,resMessage ="Success" };
            return res;
        }

        #endregion

        #region AddEmployee

        public async Task<bool> AddEmployee([FromForm]AddEmpReqModel Request ,  string HrId)
        {
            var res = false;
            var userExist = await _DBContext.SnEmployees.Where(u => u.EmployeeId == int.Parse(Request.LoginId)).FirstOrDefaultAsync();
            if (userExist == null)
            {
                try
                {
                    var BranchData = await _DBContext.SnBranchMasters
                                                        .Where(u => u.BranchName == Request.Branch)
                                                        .FirstOrDefaultAsync();
                    var newUser = new SnEmployee()
                    {
                        EmpName = (Request.Name == "null") ? null : Request.Name,
                        EmployeeId = int.Parse(Request.LoginId),
                        ReportingHeadId = (Request.ReportingId == "null") ? null : int.Parse(Request.ReportingId),
                        ReportingHeadId2 = (Request.ReportingId2 == "null") ? null : int.Parse(Request.ReportingId2),
                        ReportingHeadId3 = (Request.ReportingId3 == "null") ? null : int.Parse(Request.ReportingId3),
                        FatherName = Request.FatherName,
                        MotherName = Request.MotherName,
                        JoiningDate = (Request.JoiningDate == "null") ?null : DateTime.Parse(Request.JoiningDate),
                        DateOfBirth = (Request.DOB == "null") ? null : DateTime.Parse(Request.DOB),
                        Gender = Request.Gender,
                        IsMarried = (Request.MaritalStatus == "true") ? true : false,
                        AnniversaryDate = (Request.Anniversary == "null") ? null : DateTime.Parse(Request.Anniversary),
                        PanNumber = Request.Pan,
                        GroupName = Request.Group,
                        SubGroupId = BranchData.BranchId,
                        VerticalId = (Request.VerticalId == "null") ? null : int.Parse(Request.VerticalId),
                        SubVerticalId = await _DBContext.SnSubVerticalMasters
                                                            .Where(u=>u.SubVerticalName == Request.SubVerticalid)
                                                            .Select(u=>u.SubVerticalId)
                                                            .FirstOrDefaultAsync(),
                        EmpStatus = true,
                        DesignationId = (Request.DesignationId == "null") ? null : int.Parse(Request.DesignationId),
                        Ctc = (Request.FixedCtc == "null") ? null : Double.Parse(Request.FixedCtc),
                        IncentiveInPercent = (Request.incenticePercent == "null") ? null : Double.Parse(Request.incenticePercent),
                        IncentiveAmount = (Request.incentiveAmount == "null") ? null : Double.Parse(Request.incentiveAmount),
                        ReferredById = await _DBContext.SnEmployees
                                                .Where(u => u.EmpName == Request.Referredby)
                                                .Select(u => u.EmployeeId)
                                                .FirstOrDefaultAsync(),
                        VerificationDetails = (Request.VerificationDetails == "null") ? null : Request.VerificationDetails,
                        CreatedOn = DateTime.Now,
                        CreatedBy = int.Parse(HrId),
                        IsSalesNetUser = (Request.IssalesNetuser == "true")?true:false,
                        EmpCode = Request.LoginId.ToString(),
                        RegionId = BranchData.RegionId,
                        BranchId = BranchData.BranchId,
                        HierarchyId = (Request.HierarchyId == "null") ? null : int.Parse(Request.HierarchyId),
                        EmpPassword = Request.password,
                        TeamBelongsTo = Request.TeamType,
                        Email = Request.OfficialEmail,
                        GradeId = (Request.Grade == "null") ? null : int.Parse(Request.Grade),
                        BloodGroup = Request.Bloodgroup,
                        Emergencycontactnumber = Request.EmergencyContact,
                        Relationwiththatnumbergiven = Request.realtionwithContact,
                        CertificateDateOfBirth = (Request.DOB == "null") ? null : DateTime.Parse(Request.DOB),
                        EnteredEmployeeId = Request.EmployeeId.ToString(),
                        Uanno = Request.Uanno,
                        PhysicalLocation = Request.Branch,
                        TotalPackage = (Request.AnnualCtc == "null") ? null : Double.Parse(Request.AnnualCtc),
                        EmployeeStatus = (Request.EmpStatus == "null") ? null : int.Parse(Request.EmpStatus),
                        EmpStatusFromDate = (Request.FromDate == "null") ? null : DateTime.Parse(Request.FromDate),
                        EmpStatusToDate = (Request.ToDate == "null") ? null : DateTime.Parse(Request.ToDate),
                        PerEmail = Request.Personalemail,
                        AadharNumber = Request.Aadhar,
                        PersonalContactNo = Request.PersonalContact,
                        LandlineNumber = Request.LandlineNumber,
                        TotalNoEx = Request.Totalexp,
                        PersonalEmailId = Request.Personalemail,
                        TotalCtc = (Request.AnnualCtc == "null") ? null : Double.Parse(Request.AnnualCtc)
                    };

                    if (Request.uploadImage != null)
                    {
                        string currentDir = System.IO.Directory.GetCurrentDirectory();
                        var path = currentDir + @"/User/UserImages";
                        using (var stream = new FileStream(Path.Combine(path, Request.uploadImage.FileName), FileMode.Create))
                        {
                            Request.uploadImage.CopyTo(stream);
                        }
                        newUser.UserImage = "~//User//UserImages//" + Request.uploadImage.FileName; 
                    }

                    if(Request.Attachments != null)
                    {
                        string currentDir = System.IO.Directory.GetCurrentDirectory();
                        var path = currentDir + @"/Uploads/EmployeeDocument";
                        using (var stream = new FileStream(Path.Combine(path, Request.Attachments.FileName), FileMode.Create))
                        {
                            Request.Attachments.CopyTo(stream);
                        }
                        //newUser.UserImage = "~//Uploads//EmployeeDocument//" + Request.Attachments.FileName;

                        var AttachmentData = new SnEmployeeAttachment()
                        {
                            EmpId = int.Parse(Request.LoginId),
                            EmpAttachmentName = Request.Attachments.FileName,
                            EmpAttachmentPath = "~//Uploads//EmployeeDocument//" + Request.Attachments.FileName
                        };
                        await _DBContext.SnEmployeeAttachments.AddAsync(AttachmentData);
                    }

                    await _DBContext.SnEmployees.AddAsync(newUser);

                    var attchment = new SnEmployeeAttachment()
                    {
                        EmpId = int.Parse(Request.EmployeeId),
                    };
                    await _DBContext.SnEmployeeAttachments.AddAsync(attchment);

                    var addresses = new SnEmployeeAddress()
                    {
                        EmpId = (Request.EmployeeId == "null") ? null : int.Parse(Request.EmployeeId),
                        IsPermanentAddress = (Request.PAddress != "null") ? true : false,
                        EmpPaddress = Request.PAddress,
                        EmpCaddress = Request.CAddress,
                        EmpPcity = Request.PCity,
                        EmpPstate = Request.PState,
                        EmpPcountry = Request.Pcountry,
                        EmpCcountry = (Request.Ccountry == "null") ? null : Request.Ccountry,
                        EmpPpin = (Request.Ppincode == "null") ? null : Request.Ppincode,
                        EmpPphone = (Request.Pphone == "null") ? null : Request.Pphone,
                        EmpCcity = (Request.CCity == "null") ? null : Request.CCity,
                        EmpCstate = (Request.CState == "null") ? null : Request.CState,
                        EmpCpin = (Request.Cpincode == "null") ? null : Request.Cpincode,
                        EmpCphone = (Request.Cphone == "null") ? null : Request.Cphone
                    };
                    await _DBContext.SnEmployeeAddresses.AddAsync(addresses);

                    var EmpPolicies = new SnEmployeePolicy()
                    {
                        EmpId = (Request.EmployeeId == "null") ?null : int.Parse(Request.EmployeeId),
                        IsMediclaimPolicy = true,
                        MpolicyName = (Request.Medi_PolicyName == "null") ? null : Request.Medi_PolicyName,
                        MpolicyDetail = (Request.Medi_PolicyDetail == "null") ? null : Request.Medi_PolicyDetail,
                        MpolicySumAssured =(Request.Medi_AssuredAmount == "null") ?null: Double.Parse(Request.Medi_AssuredAmount),
                        MpolicyExpiryDate = (Request.Medi_ExpDate == "null") ? null : DateTime.Parse(Request.Medi_ExpDate),
                        MpolicyNominee = (Request.Medi_NomineeName == "null") ? null : Request.Medi_NomineeName,
                        LpolicyName = (Request.Lic_PolicyName == "null") ? null : Request.Lic_PolicyName,
                        LpolicyDetail = (Request.Lic_PolicyDetail == "null") ? null : Request.Lic_PolicyDetail,
                        LpolicySumAssured = (Request.Lic_AssuredAmount == "null") ?null: Double.Parse(Request.Lic_AssuredAmount),
                        LpolicyExpiryDate = (Request.Lic_ExpDate == "null") ? null : DateTime.Parse(Request.Lic_ExpDate),
                        LpolicyNominee = (Request.Lic_NomineeName == "null") ? null : Request.Lic_NomineeName
                    };
                    await _DBContext.SnEmployeePolicies.AddAsync(EmpPolicies);

                    var empResignation = new SnEmployeeResignation()
                    {
                        EmpId = (Request.EmployeeId == "null") ? null : int.Parse(Request.EmployeeId),
                        ResignationDate = (Request.ResignationDate == "null") ?null : DateTime.Parse(Request.ResignationDate),
                        AcceptedBy = await _DBContext.SnEmployees
                                                 .Where(u => u.EmpName == Request.AcceptedBy)
                                                 .Select(u => u.EmployeeId)
                                                 .FirstOrDefaultAsync(),
                        ResignationReason = (Request.Reason == "null") ? null : Request.Reason,
                        LastWorkingDate = (Request.ResignationDate == "null") ? null : DateTime.Parse(Request.ResignationDate)
                    };
                    await _DBContext.SnEmployeeResignations.AddRangeAsync(empResignation);






                    await _DBContext.SaveChangesAsync();


                    res = true;
                }
                catch(Exception ex)
                {
                    _logger.Log(LogLevel.Information, ex.ToString());
                    res = false;
                }
            }
            else
            {
                try
                {
                    var BranchData = await _DBContext.SnBranchMasters
                                        .Where(u => u.BranchName == Request.Branch)
                                        .FirstOrDefaultAsync();
                    userExist.EmpName = Request.Name;
                    userExist.EmployeeId = int.Parse(Request.LoginId);
                    userExist.ReportingHeadId = (Request.ReportingId == "null") ? null : int.Parse(Request.ReportingId);
                    userExist.ReportingHeadId2 = (Request.ReportingId2 == "null") ? null : int.Parse(Request.ReportingId2);
                    userExist.ReportingHeadId3 = (Request.ReportingId3 == "null") ? null : int.Parse(Request.ReportingId3);
                    userExist.FatherName = Request.FatherName;
                    userExist.MotherName = Request.MotherName;
                    userExist.JoiningDate = (Request.JoiningDate == "null") ? null : DateTime.Parse(Request.JoiningDate);
                    userExist.DateOfBirth = (Request.DOB == "null") ? null : DateTime.Parse(Request.DOB);
                    userExist.Gender = Request.Gender;
                    userExist.IsMarried = (Request.MaritalStatus == "true") ? true : false;
                    userExist.AnniversaryDate = (Request.Anniversary == "null") ? null : DateTime.Parse(Request.Anniversary);
                    userExist.PanNumber = Request.Pan;
                    userExist.GroupName = Request.Group;
                    userExist.SubGroupId = BranchData.BranchId;
                    userExist.VerticalId = (Request.VerticalId == "null") ? null : int.Parse(Request.VerticalId);
                    userExist.SubVerticalId = await _DBContext.SnSubVerticalMasters
                                                            .Where(u => u.SubVerticalName == Request.SubVerticalid)
                                                            .Select(u => u.SubVerticalId)
                                                            .FirstOrDefaultAsync();
                    userExist.EmpStatus = true;
                    userExist.DesignationId = (Request.DesignationId == "null") ? null : int.Parse(Request.DesignationId);
                    userExist.Ctc = (Request.FixedCtc == "null") ? null : Double.Parse(Request.FixedCtc);
                    userExist.IncentiveInPercent = (Request.incenticePercent == "null") ? null : Double.Parse(Request.incenticePercent);
                    userExist.IncentiveAmount = (Request.incentiveAmount == "null") ? null : Double.Parse(Request.incentiveAmount);
                    userExist.ReferredById = await _DBContext.SnEmployees
                                            .Where(u => u.EmpName == Request.Referredby)
                                            .Select(u => u.EmployeeId)
                                            .FirstOrDefaultAsync();
                    userExist.VerificationDetails = Request.VerificationDetails;
                    userExist.ModifiedOn = DateTime.Now;
                    userExist.ModifiedBy = int.Parse(HrId);
                    userExist.IsSalesNetUser = (Request.IssalesNetuser == "true") ? true : false;
                    userExist.EmpCode = Request.LoginId.ToString();
                    userExist.RegionId = BranchData.RegionId;
                    userExist.BranchId = BranchData.BranchId;
                    userExist.HierarchyId = (Request.HierarchyId == "null") ? null : int.Parse(Request.HierarchyId);
                    userExist.EmpPassword = Request.password;
                    userExist.TeamBelongsTo = Request.TeamType;
                    userExist.Email = Request.OfficialEmail;
                    userExist.GradeId = (Request.Grade == "null") ? null : int.Parse(Request.Grade);
                    userExist.BloodGroup = (Request.Bloodgroup == "null") ? null : Request.Bloodgroup;
                    userExist.Emergencycontactnumber = Request.EmergencyContact;
                    userExist.Relationwiththatnumbergiven = Request.realtionwithContact;
                    userExist.CertificateDateOfBirth = (Request.DOB == "null") ? null : DateTime.Parse(Request.DOB);
                    userExist.EnteredEmployeeId = Request.EmployeeId.ToString();
                    userExist.Uanno = Request.Uanno;
                    userExist.PhysicalLocation = Request.Branch;
                    userExist.TotalPackage = (Request.AnnualCtc == "null") ? null : Double.Parse(Request.AnnualCtc);
                    userExist.EmployeeStatus = (Request.Status == "true") ? 1 : 0;
                    userExist.EmpStatusFromDate = (Request.FromDate == "null") ? null : DateTime.Parse(Request.FromDate);
                    userExist.EmpStatusToDate = (Request.ToDate == "null") ? null : DateTime.Parse(Request.ToDate);
                    userExist.PerEmail = Request.Personalemail;
                    userExist.AadharNumber = Request.Aadhar;
                    userExist.PersonalContactNo = Request.PersonalContact;
                    userExist.LandlineNumber = (Request.LandlineNumber == "null") ? null : Request.LandlineNumber;
                    userExist.TotalNoEx = Request.Totalexp;
                    userExist.PersonalEmailId = Request.Personalemail;
                    userExist.TotalCtc = (Request.AnnualCtc == "null") ? null : Double.Parse(Request.AnnualCtc);

                    if (Request.uploadImage != null)
                    {
                        string currentDir = System.IO.Directory.GetCurrentDirectory();
                        var path = currentDir + @"/User/UserImages";
                        using (var stream = new FileStream(Path.Combine(path, Request.uploadImage.FileName), FileMode.Create))
                        {
                            Request.uploadImage.CopyTo(stream);
                        }
                        userExist.UserImage = "~//User//UserImages//" + Request.uploadImage.FileName;
                    }

                    var attachData = await _DBContext.SnEmployeeAttachments
                                                    .Where(u => u.EmpId == int.Parse(Request.LoginId))
                                                    .FirstOrDefaultAsync();

                    if (Request.Attachments != null)
                    {
                        string currentDir = System.IO.Directory.GetCurrentDirectory();
                        var path = currentDir + @"/Uploads/EmployeeDocument";
                        using (var stream = new FileStream(Path.Combine(path, Request.Attachments.FileName), FileMode.Create))
                        {
                            Request.Attachments.CopyTo(stream);
                        }
                        //newUser.UserImage = "~//Uploads//EmployeeDocument//" + Request.Attachments.FileName;
                        if (attachData == null)
                        {
                            var AttachmentData = new SnEmployeeAttachment()
                            {
                                EmpId = int.Parse(Request.LoginId),
                                EmpAttachmentName = Request.Attachments.FileName,
                                EmpAttachmentPath = "~//Uploads//EmployeeDocument//" + Request.Attachments.FileName
                            };
                            await _DBContext.SnEmployeeAttachments.AddAsync(AttachmentData);
                        }
                        else
                        {
                            attachData.EmpAttachmentName = Request.Attachments.FileName;
                            attachData.EmpAttachmentPath = "~//Uploads//EmployeeDocument//" + Request.Attachments.FileName;
                        }
                    }



                    var addresses = await _DBContext.SnEmployeeAddresses
                                                .Where(u => u.EmpId == int.Parse(Request.EmployeeId))
                                                .FirstOrDefaultAsync();
                    addresses.EmpId = int.Parse(Request.EmployeeId);
                    addresses.IsPermanentAddress = (Request.PAddress != "null") ? true : false;
                    addresses.EmpPaddress = Request.PAddress;
                    addresses.EmpCaddress = Request.CAddress;
                    addresses.EmpPcity = Request.PCity;
                    addresses.EmpPstate = Request.PState;
                    addresses.EmpPcountry = Request.Pcountry;
                    addresses.EmpCcountry = (Request.Ccountry == "null") ? null : Request.Ccountry;
                    addresses.EmpPpin = (Request.Ppincode == "null") ? null : Request.Ppincode;
                    addresses.EmpPphone = (Request.Pphone == "null") ? null : Request.Pphone;
                    addresses.EmpCcity = (Request.CCity == "null") ? null : Request.CCity;
                    addresses.EmpCstate = (Request.CState == "null") ? null : Request.CState;
                    addresses.EmpCpin = (Request.Cpincode == "null") ? null : Request.Cpincode;
                    addresses.EmpCphone = (Request.Cphone == "null") ? null : Request.Cphone;

                    var EmpPolicies = await _DBContext.SnEmployeePolicies
                                                        .Where(u => u.EmpId == int.Parse(Request.EmployeeId))
                                                        .FirstOrDefaultAsync();
                    EmpPolicies.IsMediclaimPolicy = true;
                    EmpPolicies.MpolicyName = (Request.Medi_PolicyName == "null") ? null : Request.Medi_PolicyName;
                    EmpPolicies.MpolicyDetail = (Request.Medi_PolicyDetail == "null") ? null : Request.Medi_PolicyDetail;
                    EmpPolicies.MpolicySumAssured = (Request.Medi_AssuredAmount == "null") ? null : Double.Parse(Request.Medi_AssuredAmount);
                    EmpPolicies.MpolicyExpiryDate = (Request.Medi_ExpDate == "null") ? null : DateTime.Parse(Request.Medi_ExpDate);
                    EmpPolicies.MpolicyNominee = (Request.Medi_NomineeName == "null") ? null : Request.Medi_NomineeName;
                    EmpPolicies.LpolicyName = (Request.Lic_PolicyName == "null") ? null : Request.Lic_PolicyName;
                    EmpPolicies.LpolicyDetail = (Request.Lic_PolicyDetail == "null") ? null : Request.Lic_PolicyDetail;
                    EmpPolicies.LpolicySumAssured = (Request.Lic_AssuredAmount == "null") ? null : Double.Parse(Request.Lic_AssuredAmount);
                    EmpPolicies.LpolicyExpiryDate = (Request.Lic_ExpDate == "null") ? null : DateTime.Parse(Request.Lic_ExpDate);
                    EmpPolicies.LpolicyNominee = (Request.Lic_NomineeName == "null") ? null : Request.Lic_NomineeName;

                    var empResignation = await _DBContext.SnEmployeeResignations
                                                     .Where(u => u.EmpId == int.Parse(Request.EmployeeId))
                                                     .FirstOrDefaultAsync();
                    empResignation.EmpId = (Request.EmployeeId == "null") ? null : int.Parse(Request.EmployeeId);
                    empResignation.ResignationDate = (Request.ResignationDate == "null") ? null : DateTime.Parse(Request.ResignationDate);
                    empResignation.AcceptedBy = await _DBContext.SnEmployees
                             .Where(u => u.EmpName == Request.AcceptedBy)
                             .Select(u => u.EmployeeId)
                             .FirstOrDefaultAsync();
                    empResignation.ResignationReason = (Request.Reason == "null") ? null : Request.Reason;
                    empResignation.LastWorkingDate = (Request.ResignationDate == "null") ? null : DateTime.Parse(Request.ResignationDate);

                    await _DBContext.SaveChangesAsync();

                    res = true;
                }
                catch(Exception ex)
                {
                    _logger.Log(LogLevel.Information, ex.ToString());
                    res = false;

                }
            }
            return res;
        }

        #endregion

        #region ViewEmpDetail

        public async Task<AddEmpReqModel1> ViewEmpDetail(string HrId , string EmpId)
        {
            try
            {
                var EmpData = await _DBContext.SnEmployees
                                        .Where(u => u.EmployeeId == int.Parse(EmpId))
                                        .FirstOrDefaultAsync();
                var AddressData = await _DBContext.SnEmployeeAddresses
                                               .Where(u => u.EmpId == int.Parse(EmpId))
                                               .FirstOrDefaultAsync();
                var PolicyData = await _DBContext.SnEmployeePolicies
                                               .Where(u => u.EmpId == int.Parse(EmpId))
                                               .FirstOrDefaultAsync();
                var ResignData = await _DBContext.SnEmployeeResignations
                                               .Where(u => u.EmpId == int.Parse(EmpId))
                                               .FirstOrDefaultAsync();

                var Data = new AddEmpReqModel1()
                {
                    Name = EmpData.EmpName,
                    TeamType = EmpData.TeamBelongsTo,
                    HierarchyId = (EmpData.HierarchyId == null) ? null : EmpData.HierarchyId.ToString(),
                    ReportingId = EmpData.ReportingHeadId,
                    ReportingId2 = (EmpData.ReportingHeadId2 == null) ? null : EmpData.ReportingHeadId2.ToString(),
                    ReportingId3 = (EmpData.ReportingHeadId3 == null) ? null : EmpData.ReportingHeadId3.ToString(),
                    JoiningDate = EmpData.JoiningDate?.ToString("yyyy-M-dd hh:mm:ss"),
                    Aadhar = EmpData.AadharNumber,
                    Gender = EmpData.Gender,
                    Pan = EmpData.PanNumber,
                    Group = EmpData.GroupName,
                    //Branch = EmpData.BranchId,
                    Branch = await _DBContext.SnBranchMasters
                                            .Where(u=>u.BranchId == EmpData.BranchId)
                                            .Select(u=> u.BranchName)
                                            .FirstOrDefaultAsync(),
                    VerticalId = (EmpData.VerticalId == null) ? null : EmpData.VerticalId.ToString(),
                    //SubVerticalid = (EmpData.SubVerticalId == null) ? null : EmpData.SubVerticalId.ToString(),
                    SubVerticalid = (EmpData.SubVerticalId == null) ? null : await _DBContext.SnSubVerticalMasters
                                                            .Where(u => u.SubVerticalId == EmpData.SubVerticalId)
                                                            .Select(u => u.SubVerticalName)
                                                            .FirstOrDefaultAsync(),
                    DesignationId = (EmpData.DesignationId == null) ? null : EmpData.DesignationId.ToString(),
                    OfficialEmail = EmpData.Email,
                    Referredby = await _DBContext.SnEmployees
                                                .Where(u => u.EmployeeId == EmpData.ReferredById)
                                                .Select(u => u.EmpName)
                                                .FirstOrDefaultAsync(),
                    Status = (EmpData.IsSalesNetUser == false) ? "InActive" : "Active",
                    LoginId = EmpData.EmployeeId.ToString(),
                    password = EmpData.EmpPassword,
                    VerificationDetails = (EmpData.VerificationDetails == null) ? null : EmpData.VerificationDetails,
                    Grade = (EmpData.GradeId == null) ? null : EmpData.GradeId.ToString(),
                    IssalesNetuser = (EmpData.IsSalesNetUser == null) ? null : EmpData.IsSalesNetUser.ToString(),
                    Cer_DOB = (EmpData.CertificateDateOfBirth == null) ? null : EmpData.CertificateDateOfBirth?.ToString("yyyy-M-dd hh:mm:ss"),
                    EmployeeId = EmpData.EmployeeId.ToString(),
                    Uanno = EmpData.Uanno,
                    PresentLocation = EmpData.PhysicalLocation,
                    FixedCtc = (EmpData.Ctc == null) ? null : EmpData.Ctc.ToString(),
                    AnnualCtc = (EmpData.TotalPackage == null) ? null : EmpData.TotalPackage.ToString(),
                    incenticePercent = (EmpData.IncentiveInPercent == null) ? null : EmpData.IncentiveInPercent.ToString(),
                    incentiveAmount = (EmpData.IncentiveAmount == null) ? null : EmpData.IncentiveAmount.ToString(),
                    EmpStatus = (EmpData.EmployeeStatus == null) ? null : EmpData.EmployeeStatus.ToString(),
                    FromDate = (EmpData.EmpStatusFromDate == null) ? null : EmpData.EmpStatusFromDate?.ToString("yyyy-M-dd hh:mm:ss"),
                    ToDate = (EmpData.EmpStatusToDate == null) ? null : EmpData.EmpStatusToDate?.ToString("yyyy-M-dd hh:mm:ss"),
                    Totalexp = (EmpData.TotalNoEx == null) ? null : EmpData.TotalNoEx.ToString(),
                    FatherName = EmpData.FatherName,
                    MotherName = EmpData.MotherName,
                    DOB = (EmpData.DateOfBirth == null) ? null : EmpData.DateOfBirth?.ToString("yyyy-M-dd hh:mm:ss"),
                    PersonalContact = (EmpData.PersonalContactNo == null) ? null : EmpData.PersonalContactNo.ToString(),
                    MaritalStatus = (EmpData.IsMarried == null) ? null : EmpData.IsMarried.ToString(),
                    Anniversary = (EmpData.AnniversaryDate == null) ? null : EmpData.AnniversaryDate?.ToString("yyyy-M-dd hh:mm:ss"),
                    Bloodgroup = (EmpData.BloodGroup == null) ? null : EmpData.BloodGroup,
                    Personalemail = EmpData.PerEmail,
                    EmergencyContact = EmpData.Emergencycontactnumber,
                    realtionwithContact = EmpData.Relationwiththatnumbergiven,
                    LandlineNumber = (EmpData.LandlineNumber == null) ? null : EmpData.LandlineNumber,


                    PAddress = AddressData.EmpPaddress,
                    PCity = AddressData.EmpPcity,
                    PState = AddressData.EmpPcity,
                    Pcountry = AddressData.EmpPcountry,
                    Ppincode = AddressData.EmpPpin,
                    Pphone = AddressData.EmpPphone,

                    CAddress = (AddressData.EmpCaddress == null) ? null : AddressData.EmpCaddress,
                    CCity = (AddressData.EmpCcity == null) ? null : AddressData.EmpCcity,
                    CState = (AddressData.EmpCstate == null) ? null : AddressData.EmpCstate,
                    Ccountry = (AddressData.EmpCcountry == null) ? null : AddressData.EmpCcountry,
                    Cpincode = (AddressData.EmpCpin == null) ? null : AddressData.EmpCpin,
                    Cphone = (AddressData.EmpCphone == null) ? null : AddressData.EmpCphone,


                    Medi_PolicyName = (PolicyData.MpolicyName == null) ? null : PolicyData.MpolicyName,
                    Medi_PolicyDetail = (PolicyData.MpolicyDetail == null) ? null : PolicyData.MpolicyDetail,
                    Medi_AssuredAmount = (PolicyData.MpolicySumAssured == null) ? null : PolicyData.MpolicySumAssured.ToString(),
                    Medi_ExpDate = (PolicyData.MpolicyExpiryDate == null) ? null : PolicyData.MpolicyExpiryDate.ToString(),
                    Medi_NomineeName = (PolicyData.MpolicyNominee == null) ? null : PolicyData.MpolicyNominee,
                    Lic_PolicyName = (PolicyData.LpolicyName == null) ? null : PolicyData.LpolicyName,
                    Lic_PolicyDetail = (PolicyData.LpolicyDetail == null) ? null : PolicyData.LpolicyDetail,
                    Lic_AssuredAmount = (PolicyData.LpolicySumAssured == null) ? null : PolicyData.LpolicySumAssured.ToString(),
                    Lic_ExpDate = (PolicyData.LpolicyExpiryDate == null) ? null : PolicyData.LpolicyExpiryDate.ToString(),
                    Lic_NomineeName = (PolicyData.LpolicyNominee == null) ? null : PolicyData.LpolicyNominee,


                    ResignationDate = (ResignData.ResignationDate == null) ? null : ResignData.ResignationDate.ToString(),
                    AcceptedBy = await _DBContext.SnEmployees
                                                .Where(u => u.EmployeeId == ResignData.EmpId)
                                                .Select(u => u.EmpName)
                                                .FirstOrDefaultAsync(),
                    LastDate = (ResignData.LastWorkingDate == null) ? null : ResignData.LastWorkingDate.ToString(),
                    Reason = (ResignData.ResignationReason == null) ? null : ResignData.ResignationReason

                };
                return Data;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return null;

            }
            

        }

        #endregion

        #region DeleteEmployee

        public async Task<CommonResponse> DeleteEmployee(int employeeId)
        {
            try
            {
                var EmpData = await  _DBContext.SnEmployees
                                            .Where(u => u.EmployeeId == employeeId)
                                            .FirstOrDefaultAsync();

                if(EmpData == null)
                {
                    return new CommonResponse() { resCode = 400, resMessage = "Bad Request" };
                }

                var AddressData = await _DBContext.SnEmployeeAddresses
                                            .Where(u => u.EmpId == employeeId)
                                            .FirstOrDefaultAsync();
                var PolicyData = await _DBContext.SnEmployeePolicies
                                               .Where(u => u.EmpId == employeeId)
                                               .FirstOrDefaultAsync();
                var ResignData = await _DBContext.SnEmployeeResignations
                                               .Where(u => u.EmpId == employeeId)
                                               .FirstOrDefaultAsync();
                _DBContext.SnEmployees.Remove(EmpData);
                if (AddressData != null)
                {
                    _DBContext.SnEmployeeAddresses.Remove(AddressData);
                }
                if (PolicyData != null)
                {
                    _DBContext.SnEmployeePolicies.Remove(PolicyData);
                }
                if (ResignData != null)
                {
                    _DBContext.SnEmployeeResignations.Remove(ResignData);
                }
                await _DBContext.SaveChangesAsync();

                return new CommonResponse() { resCode = 200, resMessage = "Success" };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Something went wrong!" };
            }
        }

        #endregion

        #region EmpHistory

        public async Task<CommonResponse> EmpHistory(int EmployeeId)
        {
            try
            {
                var data = await _DBContext.SnManageEmployeeApprHistories
                                        .Where(u => u.EmpId == EmployeeId)
                                        .Select(u => new EmpHistoryResponse()
                                        {
                                            Year = u.From.ToString().Substring(7,4),
                                            Grade = _DBContext.SnGradeMasters
                                                                .Where(m => m.GradeId == u.GradeId)
                                                                .Select(i => i.Grade)
                                                                .FirstOrDefault(),
                                            verticalName = _DBContext.SnVerticalMasters
                                                                    .Where(m => m.VerticalId == u.VerticalId)
                                                                    .Select(i => i.VerticalName)
                                                                    .FirstOrDefault(),
                                            Designation = _DBContext.SnDesignationMasters
                                                                   .Where(m => m.DesignationId == u.DesgId)
                                                                   .Select(i => i.DesignationName)
                                                                   .FirstOrDefault(),
                                            FixedPackage = u.Ctc
                                        })
                                        .ToListAsync();
                if(data== null)
                {
                    return new CommonResponse() { resCode = 400, resMessage = "Bad Request!" };
                }
                return new CommonResponse() { resCode = 200 , resData = data ,resMessage = "Success"};
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501,  resMessage = "Something Went Wrong" };
            }
        }

        #endregion

        #region EmpProductList

        public async Task<CommonResponse> EmpProductList(int EmployeeId)
        {
            try
            {
                var data = await _DBContext.SnEmployeeProductVerticals
                                        .Where(u => u.EmpId == EmployeeId)
                                        .Select(u => new EmpProductModel()
                                        {
                                            ProductverticalId = u.EmpProductVerticalId.ToString(),
                                            Vertical = _DBContext.SnVerticalMasters
                                                                .Where(o => o.VerticalId == u.VerticalId)
                                                                .Select(o => o.VerticalName)
                                                                .FirstOrDefault(),
                                            Status = (u.VerticalStatus == true) ? "Active" : "In-Active"
                                        }).ToListAsync();
                if(data== null)
                {
                    return new CommonResponse() { resCode = 400, resMessage = "Bad Request!" };
                }
                return new CommonResponse() { resCode = 200, resData = data, resMessage = "Success!" };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Something went wrong!" };
            }
        }

        #endregion

        #region AddEmpProduct

        public async Task<CommonResponse> AddEmpProduct(AddEmpProdModel request)
        {
            try
            {
                var data = await _DBContext.SnEmployeeProductVerticals
                                        .Where(u => u.EmpId == request.EmpId
                                                  && u.VerticalId == _DBContext.SnVerticalMasters
                                                                            .Where(o => o.VerticalName == request.vertical)
                                                                            .Select(o => o.VerticalId)
                                                                            .FirstOrDefault()
                                                  )
                                        .FirstOrDefaultAsync();
                if(data == null)
                {
                    var entry = new SnEmployeeProductVertical()
                    {
                        VerticalId = await _DBContext.SnVerticalMasters
                                             .Where(o => o.VerticalName == request.vertical)
                                             .Select(o => o.VerticalId)
                                             .FirstOrDefaultAsync(),
                        EmpId = request.EmpId,
                        VerticalStatus = (request.status == "Active") ? true : false
                    };
                    await _DBContext.SnEmployeeProductVerticals.AddAsync(entry);
                    await _DBContext.SaveChangesAsync();

                    return new CommonResponse() { resCode = 200, resData = "success", resMessage = "success!" };
                }

                data.VerticalStatus = (request.status == "Active") ? true : false;
                await _DBContext.SaveChangesAsync();
                return new CommonResponse() { resCode = 200, resData = "success", resMessage = "success!" };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Internal server erroe" };
            }
        }

        #endregion

        #region DelEmpProduct

        public async Task<CommonResponse> DelEmpProduct(int ProdId)
        {
            try
            {
                var data = await _DBContext.SnEmployeeProductVerticals
                                        .Where(u => u.EmpProductVerticalId == ProdId)
                                        .FirstOrDefaultAsync();
                _DBContext.SnEmployeeProductVerticals.Remove(data);
                await _DBContext.SaveChangesAsync();
                return new CommonResponse() { resCode = 200, resData = "success", resMessage = "Success" };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Something Went wrong" };
            }
        }

        #endregion

        #region EmpDesignationList

        public async Task<CommonResponse> EmpDesignationList(HrEmpDesigReqModel request)
        {

            try
            {
                var data = await _DBContext.SnDesignationMasters
                                                .Where(u => u.IsDeleted == false
                                                            && ((request.search == null || u.DesignationName.Contains(request.search))
                                                            || (request.search == null || u.TeamType.Contains(request.search)))
                                                )
                                                .Select(u => new HrEmpDesigResModel()
                                                {
                                                    DesignationId = u.DesignationId,
                                                    Designation = u.DesignationName,
                                                    Status = (u.IsActive == true) ? "Active" : "In-Active",
                                                    TeamType = u.TeamType,
                                                    Parent = _DBContext.SnDesignationMasters
                                                                    .Where(i => i.DesignationId == u.ParentId)
                                                                    .Select(i => i.DesignationName)
                                                                    .FirstOrDefault(),
                                                }).ToListAsync();
                data.Reverse();
                var res = new DesignationResModel()
                {
                    data = data.Skip((request.pageNumber - 1) * request.pageSize)
                            .Take(request.pageSize).ToList(),
                    TotalData = data.Count()
                };
                if(data != null)
                {
                    return new CommonResponse() { resCode = 200, resData = res, resMessage = "Success!" };
                }


            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Internal server error!" };
            }

            return new CommonResponse();
        }

        #endregion

        #region DeleteEmpDesignation

        public async Task<CommonResponse> DelDesignation(int designationId)
        {
            try
            {
                var data = await _DBContext.SnDesignationMasters
                        .Where(u => u.DesignationId == designationId)
                        .FirstOrDefaultAsync();
                _DBContext.SnDesignationMasters.Remove(data);
                await _DBContext.SaveChangesAsync();

                return new CommonResponse() { resCode = 200, resData = "success" , resMessage = "Success!" };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Internal server error!" };
            }
        }

        #endregion

        #region AddDesignation

        public async Task<CommonResponse> AddDesignation(AddDesigReqModel request)
        {
            var data = new SnDesignationMaster()
            {
                DesignationName = request.Designation,
                TeamType = request.TeamType,
                ParentId = request.ParentId,
                IsActive = (request.Status == "Active") ? true : false,
                IsDeleted = false
            };
            await _DBContext.SnDesignationMasters.AddAsync(data);
            await _DBContext.SaveChangesAsync();



            return new CommonResponse() { resCode=200 , resMessage="Success!"};
        }

        #endregion

        #region EditDesignation

        public async Task<CommonResponse> EditDesignation(AddDesigReqModel request)
        {
            try
            {
                var Data = await  _DBContext.SnDesignationMasters
                                        .Where(u => u.DesignationId == request.DesignationId)
                                        .FirstOrDefaultAsync();
                Data.DesignationName = request.Designation;
                Data.TeamType = request.TeamType;
                Data.ParentId = request.ParentId;
                Data.IsActive = (request.Status == "Active") ? true : false;

                await _DBContext.SaveChangesAsync();
                return new CommonResponse() { resCode = 200, resData = true, resMessage = "Success!" };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Internal server error!" };
            }
        }

        #endregion

        #region ViewDesignation

        public async Task<CommonResponse> ViewDesignation(int DesigntionId)
        {
            try
            {
                var data = await _DBContext.SnDesignationMasters
                                                .Where(u => u.DesignationId == DesigntionId)
                                                .FirstOrDefaultAsync();
                return new CommonResponse() { resCode = 200, resData = data, resMessage = "Success!" };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Internal Server Error!" };
            }
        }

        #endregion

        #region HrHolidayList

        public async Task<CommonResponse> HrHolidayList(HrHolidayReqModel request)
        {

            try
            {
                var data = await _DBContext.SnHolidays
                                        .Where(u => u.IsDeleted == false
                                                  && ((request.search == null || u.HolidayName.Contains(request.search))
                                                 || (request.search == null || u.HolidayDescription.Contains(request.search))
                                                 )
                                        )
                                        .Select(u => new HrHolidaylistResModel(){
                                            HolidayId = u.HolidayId,
                                            Name = u.HolidayName,
                                            Date = u.HoliDayDate.ToString(),
                                            Description = u.HolidayDescription,
                                            Branch = _DBContext.SnBranchMasters
                                                                .Where(m => m.BranchId == u.BranchId)
                                                                .Select(m => m.BranchName)
                                                                .FirstOrDefault(),
                                            Status = (u.IsActive == true) ? "Active" : "IN-Active"
                                        }).ToListAsync();
                data.Reverse();
                var res = new HrHolidayListModel()
                {
                    data = data.Skip((request.pageNumber - 1) * request.pageSize)
                            .Take(request.pageSize).ToList(),
                    totalCount = data.Count()
                };
                if (data != null)
                {
                    return new CommonResponse() { resCode = 200, resData = res, resMessage = "Success!" };
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "nternal Server error" };
            }

            return new CommonResponse();
        }

        #endregion

        #region DeleteHoliday

        public async Task<CommonResponse> DeleteHoliday(int HoidayId)
        {
            try
            {
                var data = await _DBContext.SnHolidays
                                               .Where(u => u.HolidayId == HoidayId)
                                               .FirstOrDefaultAsync();
                _DBContext.SnHolidays.Remove(data);
                await _DBContext.SaveChangesAsync();
                return new CommonResponse() { resCode = 200, resData = true, resMessage = "Success!" };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Internal Server error!" };
            }
        }

        #endregion

        #region AddHoliday

        public async Task<CommonResponse> AddHoliday(AddHoliday request , string UserId)
        {
            if(request.HolidayId != 0)
            {
                var Data = await _DBContext.SnHolidays
                                        .Where(u => u.HolidayId == request.HolidayId)
                                        .FirstOrDefaultAsync();
                Data.HolidayName = request.Name;
                Data.HoliDayDate = request.Date;
                Data.HolidayDescription = request.Description;
                Data.BranchId = _DBContext.SnBranchMasters
                                    .Where(u => u.BranchName == request.Branch)
                                    .Select(u => u.BranchId)
                                    .FirstOrDefault();
                Data.IsActive = (request.Status == "Active") ? true : false;
                Data.ModifiedOn = DateTime.Now;
                Data.ModifiedBy = int.Parse(UserId);

                await _DBContext.SaveChangesAsync();
                return new CommonResponse() { resCode = 200, resMessage = "Success!" };

            }
            var data = new SnHoliday();
            data.HolidayName = request.Name;
            data.HoliDayDate = request.Date.Date;
            data.HolidayDescription = request.Description;
            data.BranchId = _DBContext.SnBranchMasters
                                    .Where(u => u.BranchName == request.Branch)
                                    .Select(u => u.BranchId)
                                    .FirstOrDefault();
            data.IsActive = (request.Status == "Active") ? true : false;
            data.IsDeleted = false;
            data.CreatedBy = int.Parse(UserId);
            data.CreatedOn = DateTime.Now;
            await _DBContext.SnHolidays.AddAsync(data);
            await _DBContext.SaveChangesAsync();

            return new CommonResponse() { resCode = 200, resData = true, resMessage = "Success!" };

        }

        #endregion

        #region ViewHoliday

        public async Task<CommonResponse> ViewHoliday(int HolidayId)
        {
            var data = await _DBContext.SnHolidays
                                    .Where(u => u.HolidayId == HolidayId)
                                    .Select(u => new AddHoliday1()
                                    {
                                        Name = u.HolidayName,
                                        Date = u.HoliDayDate,
                                        Description = u.HolidayDescription,
                                        Branch = _DBContext.SnBranchMasters
                                                          .Where(m => m.BranchId == u.BranchId)
                                                          .Select(m => m.BranchName)
                                                          .FirstOrDefault(),
                                        Status = (u.IsActive == true) ? "Active" : "In-Active"
                                    }).FirstOrDefaultAsync();
            return new CommonResponse() { resCode = 200, resData = data, resMessage = "Success!" };
        }

        #endregion

        #region ManageDepartment

        #region DeptList

        public async Task<CommonResponse> DeptList(string DeptName)
        {
            try
            {
                var data = await _DBContext.SnDepartmentMasters
                                        .Where(u => u.IsDeleted == false
                                         && (DeptName == null || u.DeptName.Contains(DeptName))
                                        ).ToListAsync();
                data.Reverse();
                var res = new DeptListResModel();
                res.Data = data;
                res.TotalCount = data.Count();
                return new CommonResponse() { resCode = 200, resData = res, resMessage = "Success!" };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Internal server error!" };
            }
        }

        #endregion

        #region DeleteDept

        public async Task<CommonResponse> DeleteDept(int Deptid)
        {
            var data = await _DBContext.SnDepartmentMasters
                                    .Where(u => u.DeptId == Deptid)
                                    .FirstOrDefaultAsync();
            _DBContext.SnDepartmentMasters.Remove(data);
            await _DBContext.SaveChangesAsync();
            return new CommonResponse() { resCode = 200, resData = true, resMessage = "Success!" };
        }

        #endregion

        #region AddDepartment

        public async Task<CommonResponse> AddDepartment(DeptEditReqModel request)
        {
            if(request.DeptId != 0)
            {
                var data = await _DBContext.SnDepartmentMasters
                                        .Where(u => u.DeptId == request.DeptId)
                                        .FirstOrDefaultAsync();
                data.DeptName = request.DeptName;
                await _DBContext.SaveChangesAsync();
                return new CommonResponse() { resCode = 200, resMessage = "Success" };
            }
            var Data = new SnDepartmentMaster()
            {
                DeptName = request.DeptName,
                IsDeleted = false
            };
            await _DBContext.SnDepartmentMasters.AddAsync(Data);
            await _DBContext.SaveChangesAsync();
            return new CommonResponse() { resCode = 200, resMessage = "Success" };
        }

        #endregion

        #region ViewDeptByid

        public async Task<CommonResponse> ViewDept(int DeptId)
        {
            var data = await _DBContext.SnDepartmentMasters
                                     .Where(u => u.DeptId == DeptId)
                                     .Select(u => u.DeptName)
                                     .FirstOrDefaultAsync();
            return new CommonResponse() { resCode = 200,resData=data, resMessage = "Success!" };
        }

        #endregion

        #endregion

        #region HrEmpTarget

        #region HrEmpTargetList

        public async Task<CommonResponse> HrEmpTargetList(TargetListReqModel request)
        {
            var data = await (from A in _DBContext.SnEmployeeTargetMasters
                              join J in _DBContext.SnEmployeeTargetDetails on A.EmployeeTargetId equals J.EmployeeTargetId
                              where A.EmployeeId == request.EmpId && A.StartYear == DateTime.Now.Year
                              select new TargetListResModel()
                              {
                                  EmpTargetDetailId = J.EmployeeTargetDetailId,
                                  Quarter = _DBContext.SnQuarterMasters
                                                .Where(u => u.Qid == J.Qid)
                                                .Select(u => u.QshortName).FirstOrDefault(),
                                  Vertical = _DBContext.SnVerticalMasters
                                                .Where(u => u.VerticalId == J.VerticalId)
                                                .Select(u => u.VerticalName).FirstOrDefault(),
                                  Principal = _DBContext.SnPrincipalMasters
                                                .Where(u => u.PrincipalId == J.PrincipalId)
                                                .Select(u => u.PrincipalName).FirstOrDefault(),
                                  TargetAmount = J.TargetAmount,
                                  ClassifyTarget = "Individual Target"
                              }).ToListAsync();
            data.Reverse();
            var Data = data.Where(u => ((request.search == null || u.Quarter.ToLower().Contains(request.search.ToLower()))
                                                 || (request.search == null || u.Principal.ToLower().Contains(request.search.ToLower()))
                                                 || (request.search == null || u.Vertical.ToLower().Contains(request.search.ToLower()))
                                                 ));

            return new CommonResponse() { resCode =200 , resData = Data, resMessage = "Success!"};
        }

        #endregion

        #region AddTarget

        public async Task<CommonResponse> AddTarget(string LoginId , AddTargetReqModel request)
        {
            if(request.Principal == 0 || request.Vertical == 0 || request.FinancialYear == null)
            {
                return new CommonResponse() { resCode = 400, resMessage = "Bad Request!" };
            }

            int startYear = int.Parse(request.FinancialYear.Substring(0, 4));
            int endYear = int.Parse(request.FinancialYear.Substring(5, 4));
            var data = await _DBContext.SnEmployeeTargetMasters
                                .Where(u => u.StartYear == startYear && u.EmployeeId == request.EmpId)
                                .FirstOrDefaultAsync();
            if(data == null)
            {
                var newTargetMaster = new SnEmployeeTargetMaster()
                {
                    EmployeeId = request.EmpId,
                    StartYear =startYear,
                    EndYear = endYear,
                    CreatedBy = int.Parse(LoginId),
                    CreatedOn  = DateTime.Now,
                };
                await _DBContext.SnEmployeeTargetMasters.AddAsync(newTargetMaster);
                await _DBContext.SaveChangesAsync();
            }

            var emptargetId = await _DBContext.SnEmployeeTargetMasters
                                            .Where(u => u.StartYear == startYear && u.EmployeeId == request.EmpId)
                                            .Select(u=> u.EmployeeTargetId)
                                            .FirstOrDefaultAsync();

            #region Q1

            var q1Data = await _DBContext.SnEmployeeTargetDetails
                                        .Where(u => u.EmployeeTargetId == emptargetId
                                                 && u.PrincipalId == request.Principal
                                                 && u.VerticalId == request.Vertical
                                                 && u.Qid == 1
                                        ).FirstOrDefaultAsync();
            if(q1Data == null)
            {
                var targetEntry = new SnEmployeeTargetDetail();
                targetEntry.Qid = 1;
                targetEntry.PrincipalId = request.Principal;
                targetEntry.VerticalId = request.Vertical;
                targetEntry.EmployeeTargetId = emptargetId;
                targetEntry.TargetAmount = request.TargetAMJ;
                targetEntry.CalculatedTrgtAmt = request.TargetAMJ;
                targetEntry.CreatedBy = int.Parse(LoginId);
                targetEntry.CreatedOn = DateTime.Now;

                await _DBContext.SnEmployeeTargetDetails.AddAsync(targetEntry);
                await _DBContext.SaveChangesAsync();
            }
            else
            {
                q1Data.CalculatedTrgtAmt = request.TargetAMJ;
                q1Data.TargetAmount = request.TargetAMJ;
                q1Data.ModifiedOn = DateTime.Now;
                q1Data.ModifiedBy = int.Parse(LoginId);
            }

            #endregion

            #region Q2

            var q2Data = await _DBContext.SnEmployeeTargetDetails
                                        .Where(u => u.EmployeeTargetId == emptargetId
                                                 && u.PrincipalId == request.Principal
                                                 && u.VerticalId == request.Vertical
                                                 && u.Qid == 2
                                        ).FirstOrDefaultAsync();
            if (q2Data == null)
            {
                var targetEntry = new SnEmployeeTargetDetail();
                targetEntry.Qid = 2;
                targetEntry.PrincipalId = request.Principal;
                targetEntry.VerticalId = request.Vertical;
                targetEntry.EmployeeTargetId = emptargetId;
                targetEntry.TargetAmount = request.TargetJAS;
                targetEntry.CalculatedTrgtAmt = request.TargetJAS;
                targetEntry.CreatedBy = int.Parse(LoginId);
                targetEntry.CreatedOn = DateTime.Now;

                await _DBContext.SnEmployeeTargetDetails.AddAsync(targetEntry);
                await _DBContext.SaveChangesAsync();
            }
            else
            {
                q2Data.CalculatedTrgtAmt = request.TargetJAS;
                q2Data.TargetAmount = request.TargetJAS;
                q2Data.ModifiedOn = DateTime.Now;
                q2Data.ModifiedBy = int.Parse(LoginId);
            }

            #endregion

            #region Q3

            var q3Data = await _DBContext.SnEmployeeTargetDetails
                                        .Where(u => u.EmployeeTargetId == emptargetId
                                                 && u.PrincipalId == request.Principal
                                                 && u.VerticalId == request.Vertical
                                                 && u.Qid == 3
                                        ).FirstOrDefaultAsync();
            if (q3Data == null)
            {
                var targetEntry = new SnEmployeeTargetDetail();
                targetEntry.Qid = 3;
                targetEntry.PrincipalId = request.Principal;
                targetEntry.VerticalId = request.Vertical;
                targetEntry.EmployeeTargetId = emptargetId;
                targetEntry.TargetAmount = request.TargetOND;
                targetEntry.CalculatedTrgtAmt = request.TargetOND;
                targetEntry.CreatedBy = int.Parse(LoginId);
                targetEntry.CreatedOn = DateTime.Now;

                await _DBContext.SnEmployeeTargetDetails.AddAsync(targetEntry);
                await _DBContext.SaveChangesAsync();
            }
            else
            {
                q3Data.CalculatedTrgtAmt = request.TargetOND;
                q3Data.TargetAmount = request.TargetOND;
                q3Data.ModifiedOn = DateTime.Now;
                q3Data.ModifiedBy = int.Parse(LoginId);
            }

            #endregion

            #region Q4

            var q4Data = await _DBContext.SnEmployeeTargetDetails
                                        .Where(u => u.EmployeeTargetId == emptargetId
                                                 && u.PrincipalId == request.Principal
                                                 && u.VerticalId == request.Vertical
                                                 && u.Qid == 4
                                        ).FirstOrDefaultAsync();
            if (q4Data == null)
            {
                var targetEntry = new SnEmployeeTargetDetail();
                targetEntry.Qid = 4;
                targetEntry.PrincipalId = request.Principal;
                targetEntry.VerticalId = request.Vertical;
                targetEntry.EmployeeTargetId = emptargetId;
                targetEntry.TargetAmount = request.TargetJFM;
                targetEntry.CalculatedTrgtAmt = request.TargetJFM;
                targetEntry.CreatedBy = int.Parse(LoginId);
                targetEntry.CreatedOn = DateTime.Now;

                await _DBContext.SnEmployeeTargetDetails.AddAsync(targetEntry);
                await _DBContext.SaveChangesAsync();
            }
            else
            {
                q4Data.CalculatedTrgtAmt = request.TargetJFM;
                q4Data.TargetAmount = request.TargetJFM;
                q4Data.ModifiedOn = DateTime.Now;
                q4Data.ModifiedBy = int.Parse(LoginId);
            }

            #endregion

            return new CommonResponse() { resCode =200 , resMessage="Success!"};
        }

        #endregion

        #region PrincipalList

        public async Task<CommonResponse> PrincipalList()
        {
            var data = await  _DBContext.SnPrincipalMasters
                                .Where(u => u.IsDeleted == false)
                                .Select(u => new PrincipalListResModel()
                                {
                                    PrincipalId = u.PrincipalId,
                                    PrincipalName = u.PrincipalName
                                }).ToListAsync();

            return new CommonResponse() { resCode = 200, resData = data, resMessage = "Success!" };
        }

        #endregion

        #region DelTarget

        public async Task<CommonResponse> DelTarget(int TargetDetailId)
        {
            try
            {
                var data = await _DBContext.SnEmployeeTargetDetails
                                          .Where(u => u.EmployeeTargetDetailId == TargetDetailId)
                                          .FirstOrDefaultAsync();
                _DBContext.SnEmployeeTargetDetails.Remove(data);
                await _DBContext.SaveChangesAsync();
                return new CommonResponse() { resCode = 200, resMessage = "Success!" };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Internal Server error" };
            }
        }

        #endregion

        #region viewtargetdetail

        public async Task<CommonResponse> TargetDetail(int TargetDetailId)
        {
            try
            {
                var data = await _DBContext.SnEmployeeTargetDetails
                                        .Where(u=>u.EmployeeTargetDetailId == TargetDetailId)
                                        .Select(u=> new targetDetailresModel()
                                        {
                                            vertical = u.VerticalId,
                                            Principal = u.PrincipalId,
                                            Amount = u.TargetAmount
                                        }).ToListAsync();
                return new CommonResponse() { resCode = 200, resData = data, resMessage = "Success!" };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Internal server error" };
            }
        }

        #endregion

        #endregion



    }
}
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8602 // Possible null reference assignment.
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CA2200 // Rethrow to preserve stack details
#pragma warning restore CS8603 // Possible null reference return.