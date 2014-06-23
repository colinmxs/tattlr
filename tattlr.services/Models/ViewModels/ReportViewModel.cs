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
        public string File { get; set; }

        public static Report MapToReport(ReportSubmissionViewModel entity) 
        {
            var byteArray = Convert.FromBase64String(entity.File);
            var report = new Report
            {
                Description = entity.Description,
                Latitude = Convert.ToDouble(entity.Latitude),
                Longitude = Convert.ToDouble(entity.Longitude),
                //TODO: fix this. PNG is hardcoded
                Image = new ReportImage(byteArray, ImageType.PNG)                
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
                ImageUrl = entity.Image.Uri,
                Description = entity.Description,
                Latitude = entity.Latitude.ToString(),
                Longitude = entity.Longitude.ToString(),
                TimeStamp = entity.Timestamp
            };
            return reportViewModel;
        }
    }
}

    
