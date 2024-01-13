using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SalesNet.Controllers;
using SalesNet.DataEntities;
using SalesNet.Helpers;
using SalesNet.Model;
using SalesNet.Models.Request;
using SalesNet.Models.Response;
namespace SalesNet.Services
{
    public interface IKnowledgeShareService
    {
        public Task<CommonResponse> KnowledgeShareList(KnowledgeReqModel request);
        public Task<CommonResponse> KnowledgeInfo(string KnowledgeId);
        public Task<(byte[], string, string)> DownloadFile(string DocumentType);
        public Task<bool> knowledgeFileUpload(string Userid, [FromForm] KFUploadReqModel request);
    }

    public class KNowledgeShare : IKnowledgeShareService
    {
        private AdventureContext _DBContext;
        private readonly ILogger<AuthenticationController> _logger;
        private readonly AppSettings _appsettings;
        public KNowledgeShare(ILogger<AuthenticationController> logger, AdventureContext dbcontext, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _DBContext = dbcontext;
            _appsettings = appSettings.Value;
        }

        #region KnowledgeShareList

        public async Task<CommonResponse> KnowledgeShareList(KnowledgeReqModel request)
        {
            try
            {
                var data = new List<knowledgeSHResModel>();
                var count = 0;
                if(request.Subject!= "" && request.DocumentType != "")
                {
                    var knowledgeList =  await _DBContext.KnowledgeSharings
                                       .Where(u =>   u.KsdocumentStatus != 10
                                                  && u.Subject.Contains(request.Subject)
                                                  && u.DocumentType.Contains(request.DocumentType))
                                       .Select(u => new knowledgeSHResModel()
                                       {
                                           KnowledgeDocId = u.KnowledgeDocId.ToString(),
                                           DocumentType = u.DocumentType,
                                           Subject = u.Subject
                                       }).ToListAsync();
                    data = knowledgeList.Skip((request.pageNumber - 1) * request.pageSize)
                                     .Take(request.pageSize).ToList();
                    count = knowledgeList.Count();
                }
                else if(request.Subject!= "")
                {
                    var knowledgeList = await _DBContext.KnowledgeSharings
                                       .Where(u => u.KsdocumentStatus != 10
                                                  && u.Subject.Contains(request.Subject))
                                       .Select(u => new knowledgeSHResModel()
                                       {
                                           KnowledgeDocId = u.KnowledgeDocId.ToString(),
                                           DocumentType = u.DocumentType,
                                           Subject = u.Subject
                                       }).ToListAsync();
                    data = knowledgeList.Skip((request.pageNumber - 1) * request.pageSize)
                                        .Take(request.pageSize).ToList();
                    count = knowledgeList.Count();
                }
                else if(request.DocumentType != "")
                {
                    var knowledgeList = await _DBContext.KnowledgeSharings
                                       .Where(u => u.KsdocumentStatus != 10
                                                  && u.DocumentType.Contains(request.DocumentType))
                                       .Select(u => new knowledgeSHResModel()
                                       {
                                           KnowledgeDocId = u.KnowledgeDocId.ToString(),
                                           DocumentType = u.DocumentType,
                                           Subject = u.Subject
                                       }).ToListAsync();
                    data = knowledgeList.Skip((request.pageNumber - 1) * request.pageSize)
                                        .Take(request.pageSize).ToList();
                    count = knowledgeList.Count();
                }
                else
                {
                    var knowledgeList = await _DBContext.KnowledgeSharings.Where(u => u.KsdocumentStatus != 10)
                       .Select(u => new knowledgeSHResModel()
                       {
                           KnowledgeDocId = u.KnowledgeDocId.ToString(),
                           DocumentType = u.DocumentType,
                           Subject = u.Subject
                       }).ToListAsync();
                    data = knowledgeList.Skip((request.pageNumber - 1) * request.pageSize)
                                        .Take(request.pageSize).ToList();
                    count = knowledgeList.Count();
                }
                if (data == null)
                {
                    return new CommonResponse() { resCode = 400, resMessage = "Bad Request" };
                }
                return new CommonResponse
                {
                    resCode = 200,
                    resData = new knowledgeresModal()
                    {
                        Data = data,
                        Count = count
                    },
                    resMessage = "Success"
                };

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501 ,resMessage = ex.Message };
            }

        }

        #endregion

        #region Knowledge info

        public async Task<CommonResponse> KnowledgeInfo(string KnowledgeId)
        {
            var data = new KnowledgeInfoReq();
            try
            {
                data = await _DBContext.KnowledgeSharings.Where(u => u.KnowledgeDocId == int.Parse(KnowledgeId))
                                                   .Select(u => new KnowledgeInfoReq()
                                                   {
                                                       KnowledgeId = KnowledgeId,
                                                       DocumentType = u.DocumentType,
                                                       Subject = u.Subject,
                                                       Description = u.Ksdescription
                                                   }).FirstOrDefaultAsync();
                if (data == null)
                {
                    return new CommonResponse() { resCode = 400, resMessage = "Bad Request" };
                }
                return new CommonResponse() { resCode = 200, resData = data, resMessage = "Success" };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                return new CommonResponse() { resCode = 501, resMessage = "Something went wrong" };
            }
        }

        #endregion

        #region KFDownload

        public async Task<(byte[], string, string)> DownloadFile(string KnowledgeId)
        {
                var filepath = await _DBContext.KnowledgeSharings.Where(u => u.KnowledgeDocId == int.Parse(KnowledgeId)).Select(u => u.KsdocumentPath).FirstOrDefaultAsync();
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
                _logger.Log(LogLevel.Information, _ReadAllBytesAsync.ToString());
                return (_ReadAllBytesAsync, _ContentType, Path.GetFileName(filepath1));

        }

        #endregion

        #region KnowledgeFileUpload

        public async Task<bool> knowledgeFileUpload(string Userid , [FromForm] KFUploadReqModel request)
        {
            var res = false;

            try
            {
                var exist = await _DBContext.KnowledgeSharings.Where(u => u.Subject == request.Subject && u.Ksdescription == request.Description).FirstOrDefaultAsync();
                if(exist != null)
                {
                    return res;
                }
                var id = _DBContext.KnowledgeSharings.OrderBy(u => u.KnowledgeDocId).LastOrDefault();
                string currentDir = System.IO.Directory.GetCurrentDirectory();
                var path = currentDir + "//Uploads//HRDocuments";
                using (var stream = new FileStream(Path.Combine(path, request.File.FileName), FileMode.Create))
                {
                    request.File.CopyTo(stream);
                }
                var data = new KnowledgeSharing()
                {
                    DocumentType = request.DocumentType,
                    Subject = request.Subject,
                    Ksdescription = request.Description,
                    KsdocumentPath = "~//Uploads//HRDocuments//" + request.File.FileName,
                    KsdocumentStatus = 10,
                    CreatedBy = int.Parse(Userid),
                    CreatedOn = DateTime.Now,
                    IsActive = true
                };
                await _DBContext.KnowledgeSharings.AddAsync(data);
                await _DBContext.SaveChangesAsync();
                res = true;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex.ToString());
                res = false;
            }
            return res;
        }

        #endregion

    }
}
