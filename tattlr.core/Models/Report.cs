using System;
using System.Device.Location;

namespace tattlr.core.Models
{
    public class Report : ITrackableEntity<int>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ReportImage Image {get;set;}
        public DateTime Timestamp { get; set; }
    }
}
