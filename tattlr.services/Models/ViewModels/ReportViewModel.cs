using System;
using System.Device.Location;
using System.Web;
using tattlr.core.Models;

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

        public static Report MapToReport(ReportSubmissionViewModel entity) 
        {
            var report = new Report
            {
                Description = entity.Description,
                Location = entity.Location,
                Image = new ReportImage(entity.File.InputStream)                
            };
            return report;
        }
    }

    public class SubmittedReportViewModel : ReportViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public DateTime TimeStamp { get; set; }

        public static SubmittedReportViewModel MapFromReport(Report entity)
        {
            var reportViewModel = new SubmittedReportViewModel
            {
                Id = entity.Id,
                ImageUrl = entity.Image.Url,
                Description = entity.Description,
                Location = entity.Location,
                TimeStamp = entity.Timestamp
            };
            return reportViewModel;
        }
    }
}

    
