using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tattlr.core.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public GeoCoordinate Location { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
