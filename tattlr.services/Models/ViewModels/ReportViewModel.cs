using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tattlr.services.Models.ViewModels
{
    public class ReportViewModel
    {
        public string Description { get; set; }
        public GeoCoordinate Location { get; set; }
    }

    public class ReportSubmissionViewModel : ReportViewModel
    {
        public HttpPostedFileBase File { get; set; }
    }

    public class SubmittedReportViewModel : ReportViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}