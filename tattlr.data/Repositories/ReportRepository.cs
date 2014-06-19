using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using tattlr.core;
using tattlr.core.Models;
using tattlr.data.EF;

namespace tattlr.data.Repositories
{
    public class ReportRepository : IStore<tattlr.core.Models.Report, int>
    {
        private readonly DbContext _db;
        public ReportRepository()
        {
            _db = ContextLoader.LoadContext();
        }

        #region IStore<Report> Members

        public tattlr.core.Models.Report Save(tattlr.core.Models.Report entity)
        {
            var record = new tattlr.data.EF.Report
            {
                Description = entity.Description,
                Timestamp = entity.Timestamp,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                Image = new Image {
                    Uri = entity.Image.Uri
                }
            };
            _db.Set<tattlr.data.EF.Report>().Add(record);
            _db.SaveChanges();
            entity.Id = record.Id;
            return entity;
        }

        public tattlr.core.Models.Report Get(int id)
        {
            var record = _db.Set<tattlr.data.EF.Report>().Find(id);
            if (record != null)
            {
                var entity = new tattlr.core.Models.Report
                {
                    Id = record.Id,
                    Latitude = record.Latitude,
                    Longitude = record.Longitude,
                    Description = record.Description,
                    //TODO: hard-coded PNG, fix this
                    Image = new ReportImage(ImageType.PNG)
                    {
                        Uri = record.Image.Uri,
                        Id = record.Image.Id
                    },
                    Timestamp = record.Timestamp
                };
                return entity;
            }
            return null;
        }

        public void Delete(int id)
        {
            var record = _db.Set<tattlr.data.EF.Report>().Find(id);
            if (record != null)
            {
                _db.Entry<tattlr.data.EF.Report>(record).State = EntityState.Deleted;
                _db.SaveChanges();
            }
        }

        public IEnumerable<tattlr.core.Models.Report> GetAll()
        {
            var records = _db.Set<tattlr.data.EF.Report>().ToList();
            if (records.Any())
            {
                var reports = new List<tattlr.core.Models.Report>();
                foreach (var record in records)
                {
                    var entity = new tattlr.core.Models.Report
                    {
                        Id = record.Id,
                        Description = record.Description,
                        //TODO: fix this hard-coded png
                        Image = new ReportImage(ImageType.PNG)
                        {
                            Id = record.Image.Id,
                            Uri = record.Image.Uri,
                            
                        },
                        Latitude = record.Latitude,
                        Longitude = record.Longitude,
                        Timestamp = record.Timestamp
                    };
                    reports.Add(entity);
                }
                return reports;
            }
            return null;
        }

        #endregion
    }
}
