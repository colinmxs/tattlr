using System;
using System.Device.Location;

namespace tattlr.core.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public GeoCoordinate Location { get; set; }
        public ReportImage Image {get;set;}
        public DateTime Timestamp { get; set; }
    }
}
