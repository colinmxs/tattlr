using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tattlr.core;
using tattlr.core.Models;

namespace tattlr.data.Repositories
{
    public class ReportRepository : IStore<Report>
    {
        private readonly DbContext _db;
        public ReportRepository(DbContext db)
        {
            _db = db;
        }

        #region IStore<Report> Members

        public Report Save(Report entity)
        {
            var record = new tattlr.data.EF.Report
            {
                Id = entity.Id,
                Description = entity.Description,
                ImageUrl = entity.Image.Url,
                Location = entity.Location,
                Timestamp = entity.Timestamp
            };
            _db.Set<tattlr.data.EF.Report>().Add(record);
            _db.SaveChanges();
            entity.Id = record.Id;
            return entity;
        }

        public Report Get(int id)
        {
            var record = _db.Set<tattlr.data.EF.Report>().Find(id);
            if (record != null)
            {
                var entity = new Report
                {
                    Id = record.Id,
                    Description = record.Description,
                    Image = new ReportImage{
                        Url = record.ImageUrl
                    },
                    Location = record.Location,
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

        #endregion
    }
}
