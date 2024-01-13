using SalesNet.Models.Response;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace SalesNet.Models.Request
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class LoginRequestModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string? Password { get; set; }
    }

    #region Hrmanual List



    public class HrManualRequestModel
    {
        const int maxPageSize = 100;
        private int _pageNumber = 1;
        public int pageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = (value < 1) ? 0 : value;
            }
        }
        private int _pageSize = 10;
        public int pageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public string? Type { get; set; }
    }

    #endregion

    #region ChangePassword

    public class PasswordChangeReqModel
    {
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ReEnterPassword { get; set; }
    }

    #endregion

    #region holidayList

    public class HolidayListreqModel
    {
        public string? branchName { get; set; } = "All";
        public string? Year { get; set; } = "Jan 1, 2023";

        const int maxPageSize = 100;
        private int _pageNumber = 1;
        public int pageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = (value < 1) ? 0 : value;
            }
        }
        private int _pageSize = 10;
        public int pageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }

    #endregion

    #region Knowledge Share

    public class KnowledgeReqModel
    {
        public string? DocumentType { get; set; }
        public string? Subject { get; set; }

        const int maxPageSize = 100;
        private int _pageNumber = 1;
        public int pageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = (value < 1) ? 0 : value;
            }
        }
        private int _pageSize = 10;
        public int pageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }

    #endregion

    #region KnowledgeFileupload

    public class KFUploadReqModel
    {
        public string DocumentType { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
    #endregion

    #region HrEmpList

    public class HrEmpListReqModel
    {
        public bool? IsActive { get; set; }
        public string? GroupName { get; set; }
        public string? Branch { get; set; }
        public string? Name { get; set; }
        public int Vertical { get; set; }
        public int Designation { get; set; } = 0;

        const int maxPageSize = 100;

        private int _pageNumber = 1;
        public int pageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = (value < 1) ? 0 : value;
            }
        }
        private int _pageSize = 10;
        public int pageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }

    #endregion

    #region AddEmployee

    public class AddEmpReqModel
    {
        public string Name { get; set; }
        public string TeamType { get; set; }
        public string HierarchyId { get; set; }
        public string ReportingId { get; set; }
        public string ReportingId2 { get; set; }
        public string ReportingId3 { get; set; }
        public string JoiningDate { get; set; }
        public string Aadhar { get; set; }
        public string Gender { get; set; }
        public string Pan { get; set; }
        public string Group { get; set; }
        public string Branch { get; set; }
        public string VerticalId { get; set; }
        public string SubVerticalid { get; set; }
        public string DesignationId { get; set; }
        public string OfficialEmail { get; set; }
        public string Referredby { get; set; }
        public string Status { get; set; }
        public string LoginId { get; set; }
        public string password { get; set; }
        public string VerificationDetails { get; set; }
        public string Grade { get; set; }
        public IFormFile Attachments { get; set; }
        public string IssalesNetuser { get; set; }
        public string Cer_DOB { get; set; }
        public string EmployeeId { get; set; }
        public string Uanno { get; set; }
        public string PresentLocation { get; set;}
        public string FixedCtc { get; set;}
        public string AnnualCtc { get; set; }
        public string incenticePercent { get; set; }
        public string incentiveAmount { get; set; }
        public string EmpStatus { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Totalexp { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set;}
        public string DOB { get; set; }
        public string PersonalContact { get; set; }
        public string MaritalStatus { get; set; }
        public string Anniversary { get; set; }
        public string Bloodgroup { get; set; }
        public string Personalemail { get; set; }
        public string EmergencyContact { get; set; }
        public string realtionwithContact { get; set; }
        public string LandlineNumber { get;set; }
        public IFormFile uploadImage { get; set; }
        public string PAddress { get; set; }
        public string PCity { get; set; }
        public string PState { get; set; }
        public string Pcountry { get; set; }
        public string Ppincode { get; set; }
        public string Pphone { get; set; }
        public string CAddress { get; set; }
        public string CCity { get; set; }
        public string CState { get; set; }
        public string Ccountry { get; set; }
        public string Cpincode { get; set; }
        public string Cphone { get; set; }
        public string Medi_PolicyName { get; set; }
        public string Medi_PolicyDetail { get; set; }
        public string Medi_AssuredAmount { get; set; }
        public string Medi_ExpDate { get; set; }
        public string Medi_NomineeName { get; set; }
        public string Lic_PolicyName { get; set; }
        public string Lic_PolicyDetail { get; set; }
        public string Lic_AssuredAmount { get; set; }
        public string Lic_ExpDate { get; set; }
        public string Lic_NomineeName { get; set; }

        public string ResignationDate { get; set; }
        public string AcceptedBy { get; set; }
        public string LastDate { get; set; }
        public string Reason { get; set; }

    }

    #endregion

    #region Edit Employee

    public class AddEmpReqModel1
    {
        public string Name { get; set; }
        public string TeamType { get; set; }
        public string HierarchyId { get; set; }
        public int? ReportingId { get; set; }
        public string ReportingId2 { get; set; }
        public string ReportingId3 { get; set; }
        public string JoiningDate { get; set; }
        public string Aadhar { get; set; }
        public string Gender { get; set; }
        public string Pan { get; set; }
        public string Group { get; set; }
        public string Branch { get; set; }
        public string VerticalId { get; set; }
        public string SubVerticalid { get; set; }
        public string DesignationId { get; set; }
        public string OfficialEmail { get; set; }
        public string Referredby { get; set; }
        public string Status { get; set; }
        public string LoginId { get; set; }
        public string password { get; set; }
        public string VerificationDetails { get; set; }
        public string Grade { get; set; }
        public IFormFile Attachments { get; set; }
        public string IssalesNetuser { get; set; }
        public string Cer_DOB { get; set; }
        public string EmployeeId { get; set; }
        public string Uanno { get; set; }
        public string PresentLocation { get; set; }
        public string FixedCtc { get; set; }
        public string AnnualCtc { get; set; }
        public string incenticePercent { get; set; }
        public string incentiveAmount { get; set; }
        public string EmpStatus { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Totalexp { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string DOB { get; set; }
        public string PersonalContact { get; set; }
        public string MaritalStatus { get; set; }
        public string Anniversary { get; set; }
        public string Bloodgroup { get; set; }
        public string Personalemail { get; set; }
        public string EmergencyContact { get; set; }
        public string realtionwithContact { get; set; }
        public string LandlineNumber { get; set; }
        public IFormFile uploadImage { get; set; }
        public string PAddress { get; set; }
        public string PCity { get; set; }
        public string PState { get; set; }
        public string Pcountry { get; set; }
        public string Ppincode { get; set; }
        public string Pphone { get; set; }
        public string CAddress { get; set; }
        public string CCity { get; set; }
        public string CState { get; set; }
        public string Ccountry { get; set; }
        public string Cpincode { get; set; }
        public string Cphone { get; set; }
        public string Medi_PolicyName { get; set; }
        public string Medi_PolicyDetail { get; set; }
        public string Medi_AssuredAmount { get; set; }
        public string Medi_ExpDate { get; set; }
        public string Medi_NomineeName { get; set; }
        public string Lic_PolicyName { get; set; }
        public string Lic_PolicyDetail { get; set; }
        public string Lic_AssuredAmount { get; set; }
        public string Lic_ExpDate { get; set; }
        public string Lic_NomineeName { get; set; }

        public string ResignationDate { get; set; }
        public string AcceptedBy { get; set; }
        public string LastDate { get; set; }
        public string Reason { get; set; }

    }

    #endregion

    #region AddEmpProduct

    public class AddEmpProdModel
    {
        public int EmpId { get; set; }
        public string vertical { get; set; }
        public string status { get; set; }
    }

    #endregion

    #region HrEmpDesigReqModel

    public class HrEmpDesigReqModel
    {

        public string search { get; set; }

        const int maxPageSize = 100;

        private int _pageNumber = 1;
        public int pageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = (value < 1) ? 0 : value;
            }
        }
        private int _pageSize = 10;
        public int pageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }

    #endregion

    #region AddDesignation

    public class AddDesigReqModel
    {
        public int DesignationId { get; set; }
        public string Designation { get; set;}
        public string TeamType { get; set; }
        public int ParentId { get; set; }
        public string Status { get; set; }
    }

    #endregion

    #region HrHolidayReq

    public class HrHolidayReqModel
    {

        public string search { get; set; }

        const int maxPageSize = 100;

        private int _pageNumber = 1;
        public int pageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = (value < 1) ? 0 : value;
            }
        }
        private int _pageSize = 10;
        public int pageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }

    public class AddHoliday
    {
        public int HolidayId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Branch { get; set; }
        public string Status { get; set; }
    }


    #endregion

    #region DepartmentEdit

    public class DeptEditReqModel
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }

    #endregion

    #region targetListReqModel

    public class TargetListReqModel
    {
        public int EmpId { get; set; }
        public string search { get; set; }
    }

    public class AddTargetReqModel
    {
        public int EmpId { get; set; }
        public string FinancialYear { get; set; }
        public int Principal { get; set; }
        public int Vertical { get; set; }
        public double? TargetJFM { get; set; }
        public double? TargetAMJ { get; set; }
        public double? TargetJAS { get; set; }
        public double? TargetOND { get; set; }
    }

    #endregion

    #region DarListReQModel

    public class DarListReQModel
    {
        public string Search { get; set; }

        const int maxPageSize = 100;

        private int _pageNumber = 1;
        public int pageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = (value < 1) ? 0 : value;
            }
        }
        private int _pageSize = 10;
        public int pageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }

    #endregion

    #region DarEntry
    public class AddDarRqModel
    {
        public int? LeadId { get; set; }
        public int CustomerId { get; set; }
        public int ContactPersonId { get; set; }
        public int CallTypeId { get; set; }
        public int CallStatusId { get; set; }
        public int VerticalId { get; set; }
        public int OpportunityStatus { get; set; }
        public int DarStatusId { get; set; }
        public int Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string DarRemark { get; set; }
        public DateTime VisitDate { get; set; }
        public string VisitTime { get; set; }
        public int LeadTypeId { get; set; }
        public string NextActionDate { get; set; }
        public string DarClosingDate { get; set; }
        public int LostReasonId { get; set; }
        public string IsFundAvailable { get; set; }
        public int fundType { get; set; }
        public Double AdvancePay { get; set; }
        public Double DeliveryPay { get; set; }
        public Double TrainingPay { get; set; }
        public Double GST { get; set; }
        public Double OrderValue { get; set; }
        public Double ActualValue { get; set; }
        public int AppEngId { get; set; }
        public string MonthOfOrder { get; set; }

        public int ProductId { get; set; }
        public Double DarProductPrice { get; set; }
        public Double QuotedPrice { get; set; }
        public Double ProductValue { get; set; }
    }

    public class DarDocReqModel
    {
        public string DarId { get; set; }
        public IFormFile DarDoc { get; set; }
    }

    #endregion


#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}


