using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tattlr.core.Services;
using tattlr.services.Models.ViewModels;

namespace tattlr.services.Controllers
{
    //[Authorize]
    public class ReportController : ApiController
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        // GET: api/Report
        public IEnumerable<SubmittedReportViewModel> Get()
        {
            var records = _reportService.GetReports();
            var reportViewModels = new List<SubmittedReportViewModel>();
            foreach (var record in records)
            {
                reportViewModels.Add(SubmittedReportViewModel.MapFromReport(record));
            }
            return reportViewModels;
        }

        // GET: api/Report/5
        public SubmittedReportViewModel Get(int id)
        {
            var report = _reportService.GetReport(id);
            return SubmittedReportViewModel.MapFromReport(report);
        }

        //// POST: api/Report
        public HttpResponseMessage Post(ReportSubmissionViewModel entity)
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            try
            {
                var report = ReportSubmissionViewModel.MapToReport(entity);
                _reportService.SaveReport(report);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        
        // PUT: api/Report/5
        public void Put(int id, [FromBody]ReportSubmissionViewModel entity)
        {
            var report = ReportSubmissionViewModel.MapToReport(entity);
            report.Id = id;
            _reportService.SaveReport(report);
        }

        // DELETE: api/Report/5
        public void Delete(int id)
        {
            _reportService.DeleteReport(id);
        }
    }
}
