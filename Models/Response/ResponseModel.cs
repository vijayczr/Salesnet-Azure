using SalesNet.Model;
using SalesNet.Models.Request;

namespace SalesNet.Models.Response
{
    public class LoginAuthResponseModel
    {
        public int EmployeeId { get; set; }
        public string? EmpName { get; set; }
        public string? Token { get; set; }

    }

    #region CommonResponse
    public class CommonResponse
    {
        public int resCode { get; set; }
        public object? resData { get; set; }
        public string? resMessage { get; set; }
    }

    public static class CommonResponseStatus
    {
        public const int
            SUCCESS = 200,
            BAD_REPUEST = 400,
            UNAUTHORIZED = 401,
            BLOCK = 403,
            NOT_FOUND = 404,
            DUPLICATE_FOUND = 409,
            INTERNAL_SERVER_ERROR = 500;
    }

    public static class CommonResponseMessage
    {
        public const string
            SUCCESS = "success",
            BAD_REPUEST = "failed",
            UNAUTHORIZED = "Unauthorized or session expired !!",
            BLOCK = "Service suspended. Please contact to admin !!",
            NOT_FOUND = "Data not found !!",
            DUPLICATE_FOUND = "Duplicate record found !!",
            INTERNAL_SERVER_ERROR = "Internal server error !!";
    }

    #endregion

    public class HrManualResponseModel
    {
        public string? Type { get; set; }
        public string? Document { get; set; }
    }

    public class HrmanualresModel
    {
        public List<HrManualResponseModel> hrmanuals { get; set; }
        public int Totalcount { get; set; }
    }

    public class ManualInfoResponseModel
    {
        public string Group { get; set; } = "ALL";
        public string Department { get; set; } = "ALL";
        public string? Document { get; set; }
        public string? Type { get; set; }
        public string? Instruction { get; set; }
    }

    public class ProfileDataResModel
    {
        public int LoginId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Branch { get; set; }
        public string Image { get; set; }
    }

    public class HolidayListResModel
    {
        public string? Name { get; set; }
        public string? Date { get; set; }
        public string? Description { get; set; }
        public string? Branch { get; set; }
    }

    public class HolidaysTableResModel
    {
        public List<HolidayListResModel> Data { get; set; }
        public int TotalCount { get; set; }
    }

    #region Branchres
    public class Branchres
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }

    #endregion

    #region Knowledge sharing List

    public class knowledgeSHResModel
    {
        public string KnowledgeDocId { get; set; }
        public string? DocumentType { get; set; }
        public string? Subject { get; set; }
    }

    public class knowledgeresModal
    {
        public List<knowledgeSHResModel> Data { get; set; }
        public int Count { get; set; }
    }

    public class KnowledgeInfoReq
    {
        public string KnowledgeId { get; set; }
        public string? DocumentType { get; set; }
        public string? Subject { get; set; }
        public string Description { get; set; }
    }

    #endregion

    #region HrEmployeeList
    
    public class HrEmpListResModel
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? ReportingTo { get; set; }
        public string? Branch { get; set; }
        public string? Vertical { get; set; }
        public string? Designation { get; set; }
        public string Status { get; set; }
    }

    public class empListResModel
    {
        public List<HrEmpListResModel> data { get; set; }
        public int totalCount { get; set; }
    }

    #endregion

    #region teamBelongList

    public class teamBelongListResModel
    {
        public string Name { get; set; }
        public int EmployeeId { get; set; }
    }

    #endregion

    #region EmpHisory

    public class EmpHistoryResponse
    {
        public string Year { get; set; }
        //public DateTime? Year { get; set; }
        public string Grade { get; set; }
        public string verticalName { get; set; }
        public string Designation { get; set; }
        public string FixedPackage { get; set; }
    }

    #endregion

    #region EmpProduct
    public class EmpProductModel
    {
        public string ProductverticalId { get; set; }
        public string Vertical { get; set; }
        public string Status { get; set; }
    }

    #endregion

    #region HrEmpDesigResModel

    public class HrEmpDesigResModel
    {
        public int DesignationId { get; set; }
        public string Designation { get; set; }
        public string Parent { get; set; }
        public string TeamType { get; set; }
        public string Status { get; set; }
    }

    public class DesignationResModel
    {
        public List<HrEmpDesigResModel> data { get; set; }
        public int TotalData { get; set; }
    }

    #endregion

    #region HrHolidays


    public class HrHolidaylistResModel
    {
        public int HolidayId { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Branch { get; set; }
        public String Status { get; set; }
    }

    public class HrHolidayListModel
    {
        public List<HrHolidaylistResModel> data { get; set; }
        public int totalCount { get; set; }

    }

    public class AddHoliday1
    {
        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public string Branch { get; set; }
        public string Status { get; set; }
    }


    #endregion

    #region HrDepartment

    public class DeptListResModel
    {
        public List<SnDepartmentMaster> Data { get; set; }
        public int TotalCount { get; set; }
    }

    #endregion

    #region TargetListResModel

    public class TargetListResModel
    {
        public int EmpTargetDetailId { get; set; }
        public string Quarter { get; set; }
        public string Vertical { get; set; }
        public string Principal { get; set; }
        public double? TargetAmount { get; set; }
        public string ClassifyTarget { get; set; }

    }

    public class PrincipalListResModel
    {
        public int PrincipalId { get; set; }
        public string PrincipalName { get; set; }
    }

    public class targetDetailresModel
    {
        public int? vertical { get; set; }
        public int? Principal { get; set; }
        public double? Amount { get; set; }
    }


    #endregion

    #region Dar

    public class DarListResModel
    {
        public int DarId { get; set; }
        public string Employee { get; set; }
        public int? Leadid { get; set; }
        public string Customer { get; set; }
        public string ContactPerson { get; set; }
        public string VisitDate { get; set; }
        public string Products { get; set; }

    }

    public class DarListModel
    {
        public List<DarListResModel> Data { get; set; }
        public int Totalcount { get; set; }
    }

    public class CustNameResModel
    {
        public string value { get; set; }
        public string label { get; set; }
    }

    public class Quartermonth
    {
        public int? StartMonth { get; set; }
        public int? EndMonth { get; set; }
    }

    public class QuarterResModel
    {
        public string RevenueAsgQ1 { get; set; }
        public string RevenueAsgQ2 { get; set; }
        public string RevenueAsgQ3 { get; set; }
        public string RevenueAsgQ4 { get; set; }
        public string TargetAsgQ1 { get; set; }
        public string TargetAsgQ2 { get; set; }
        public string TargetAsgQ3 { get; set; }
        public string TargetAsgQ4 { get; set; }
        public string RevenueIsgQ1 { get; set; }
        public string RevenueIsgQ2 { get; set; }
        public string RevenueIsgQ3 { get; set; }
        public string RevenueIsgQ4 { get; set; }
        public string TargetIsgQ1 { get; set; }
        public string TargetIsgQ2 { get; set; }
        public string TargetIsgQ3 { get; set; }
        public string TargetIsgQ4 { get; set; }
        public string TotalAsgTarget { get; set; }
        public string TotalIsgTarget { get; set; }
        public string TotalIsgRevenueTarget { get; set; }
        public string TotalAsgRevenueTarget { get; set; }
        public List<Double?> Achivement { get; set; }
    }

    #endregion

    #region AppEnggResModel

    public class AppEnggResModel
    {
        public string EmpName { get; set; }
        public int EmpId { get; set; }
    }

    public class CustListResModel
    {
        public int Value { get; set; }
        public string Label { get; set; }
    }

    #endregion

    #region DarEntry

    public class CustDetailResModel
    {
        public int CustId { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string CustDepartment { get; set; }
        public string CustDesgn { get; set; }
        public string Email { get; set; }
    }

    public class CustContactListResModel
    {
        public int CustId { get; set; }
        public string ContactPerson { get; set; }
    }

    public class productList
    {
        public int ProductId { get; set;}
        public string ProductName { get; set; }
        public double? TechlabPrice { get; set; }
        public double? QuotedPrice { get; set; }
        public double? ProductValue { get; set;}
        public string Description { get; set; }
    }


    public class ViewDarResModel
    {
        public int? LeadId { get; set; }
        public int? CustomerId { get; set; }
        public int? ContactPersonId { get; set; }
        public int? CallTypeId { get; set; }
        public int? CallStatusId { get; set; }
        public int? VerticalId { get; set; }
        public int? OpportunityStatus { get; set; }
        public int? DarStatusId { get; set; }
        public Double? Price { get; set; }
        public string? DarRemark { get; set; }
        public DateTime? VisitDate { get; set; }
        public string? VisitTime { get; set; }
        public int? LeadTypeId { get; set; }
        public DateTime? NextActionDate { get; set; }
        public DateTime? DarClosingDate { get; set; }
        public int? LostReasonId { get; set; }
        public string? IsFundAvailable { get; set; }
        public int? fundType { get; set; }
        public Double? AdvancePay { get; set; }
        public Double? DeliveryPay { get; set; }
        public Double? TrainingPay { get; set; }
        public int GstPerc { get; set; }
        public Double? GST { get; set; }
        public Double? OrderValue { get; set; }
        public Double? ActualValue { get; set; }
        public int? AppEngId { get; set; }
        public DateTime? MonthOfOrder { get; set; }

        public int? ProductId { get; set; }
        public int? PrincipalId { get; set; }
        public string? ProductName { get; set; }
        public Double? DarProductPrice { get; set; }
        public Double? QuotedPrice { get; set; }
        public Double? ProductValue { get; set; }

        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string CustDepartment { get; set; }
        public string CustDesgn { get; set; }
        public string Email { get; set; }
    }


    #endregion



}
