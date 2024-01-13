using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SalesNet.Controllers;
using SalesNet.DataEntities;
using SalesNet.Helpers;
using SalesNet.Models.Request;
using SalesNet.Models.Response;

namespace SalesNet.Services
{
    public interface IHolidaysService
    {
        public Task<CommonResponse> HolidayList(HolidayListreqModel request);
    }

    public class Holidays : IHolidaysService
    {
        private AdventureContext _DBContext;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly AppSettings _appsettings;
        public Holidays(ILogger<AuthenticationController> logger, AdventureContext dbcontext, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _DBContext = dbcontext;
            _appsettings = appSettings.Value;
        }

        #region HolidayList
        public async Task<CommonResponse> HolidayList(HolidayListreqModel request)
        {
            DateTime date = DateTime.Parse(request.Year);
            if (request.branchName == "")
                request.branchName = "All";
            try
            {
                var data = new List<HolidayListResModel>();
                var count = 0;
                if(request.branchName == "All")
                {
                    data = await _DBContext.SnHolidays.Where(u=> u.HoliDayDate >= date).
                                    Select(u => new HolidayListResModel()
                                    {
                                        Name = u.HolidayName,
                                        Date = u.HoliDayDate.ToString(),
                                        Description = u.HolidayDescription,
                                        Branch = _DBContext.SnBranchMasters.Where(m => m.BranchId == u.BranchId).Select(w=>w.BranchName).FirstOrDefault()
                                    }).Skip((request.pageNumber - 1) * request.pageSize)
                                     .Take(request.pageSize).ToListAsync();
                    count = _DBContext.SnHolidays.Where(u => u.HoliDayDate >= date).ToList().Count();
                }
                else
                {
                    var branch = await _DBContext.SnBranchMasters.Where(m=>m.BranchName == request.branchName).Select(u=>new Branchres() { BranchId=u.BranchId,BranchName=u.BranchName}).FirstOrDefaultAsync();
                    data = await _DBContext.SnHolidays.Where(x=>x.BranchId == branch.BranchId && x.HoliDayDate >= date).
                                    Select(u => new HolidayListResModel()
                                    {
                                        Name = u.HolidayName,
                                        Date = u.HoliDayDate.ToString(),
                                        Description = u.HolidayDescription,
                                        Branch = branch.BranchName
                                    }).Skip((request.pageNumber - 1) * request.pageSize)
                                     .Take(request.pageSize).ToListAsync();
                    count = _DBContext.SnHolidays.Where(x => x.BranchId == branch.BranchId && x.HoliDayDate >= date).ToList().Count();
                }
                var res = new HolidaysTableResModel()
                {
                    Data = data,
                    TotalCount = count
                };
                return new CommonResponse() { resCode = 200, resData = res ,resMessage="Success!" };


            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Something went wrong" };
            }
        }

        #endregion

    }

}
