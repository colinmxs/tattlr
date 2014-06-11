using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tattlr.services.Models.ViewModels;
using tattlr.core.Services;

namespace tattlr.services.Controllers
{
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

        // POST: api/Report
        public void Post([FromBody]ReportSubmissionViewModel entity)
        {
            var report = ReportSubmissionViewModel.MapToReport(entity);
            _reportService.SaveReport(report);
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
