using System;
using System.IO;

namespace tattlr.core.Models
{
    public class ReportImage : ITrackableEntity<int>
    {
        public readonly byte[] ByteArray;
        public int Id { get; set; }
        public string Name { get; set; }
        public ImageType Extension { get; set; }
        public string Uri { get; set; }
                   
        public ReportImage(ImageType type) 
        {
            Extension = type;
        }
        public ReportImage(byte[] byteArray, ImageType type)
        {
            ByteArray = byteArray;
            Name = DateTime.Now.Ticks.ToString();
            Extension = type;
        }
        public ReportImage(byte[] byteArray, string name, ImageType type)
        {
            ByteArray = byteArray;
            Name = name;
            Extension = type;
        }

    }
}
