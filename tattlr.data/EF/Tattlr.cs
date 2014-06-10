namespace tattlr.data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Device.Location;
    using System.Linq;

    public class Tattlr : DbContext
    {
        public DbSet<Report> Reports { get; set; }
        public Tattlr(string connectionStringName)
            : base("name=" + connectionStringName)
        {
        }
    }
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public GeoCoordinate Location { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Timestamp { get; set; }
    }
}