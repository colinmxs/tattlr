namespace tattlr.data.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Device.Location;
    using tattlr.core.Models;

    public class Tattlr : DbContext
    {
        public DbSet<Report> Reports { get; set; }
        public DbSet<Image> Images { get; set; }
        public Tattlr(string connectionStringName)
            : base("name=" + connectionStringName)
        {
        }
    }
    public class Report : ITrackableEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
        
    }
    public class Image : ITrackableEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Uri { get; set; }
    }
    
}