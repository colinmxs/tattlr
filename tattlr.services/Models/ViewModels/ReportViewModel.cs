using MultipartDataMediaFormatter.Infrastructure;
using System;
using tattlr.core.Models;

namespace tattlr.services.Models.ViewModels
{
    public class ReportViewModel
    {
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }

    public class ReportSubmissionViewModel : ReportViewModel
    {
        public HttpFile File { get; set; }

        public static Report MapToReport(ReportSubmissionViewModel entity) 
        {
            var report = new Report
            {
                Description = entity.Description,
                Latitude = Convert.ToDouble(entity.Latitude),
                Longitude = Convert.ToDouble(entity.Longitude),
                Image = new ReportImage(entity.File.Buffer)                
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
                Latitude = entity.Latitude.ToString(),
                Longitude = entity.Longitude.ToString(),
                TimeStamp = entity.Timestamp
            };
            return reportViewModel;
        }
    }
}

    
