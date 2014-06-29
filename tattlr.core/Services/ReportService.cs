using System;
using System.Collections.Generic;
using tattlr.core.Models;

namespace tattlr.core.Services
{
    public class ReportService : IReportService
    {
        private readonly IStore<Report, int> _reportStore;
        private readonly IStore<ReportImage, int> _imageStore;

        public ReportService(IStore<Report, int> reportStore, IStore<ReportImage, int> imageStore)
        {
            _reportStore = reportStore;
            _imageStore = imageStore;
        }

        #region IReportService Members

        public IEnumerable<Report> GetReports()
        {
            return _reportStore.GetAll();
        }

        public Report GetReport(int id)
        {
            return _reportStore.Get(id);
        }

        public Report SaveReport(Report report)
        {
            report.Timestamp = DateTime.Now;
            report.Image.Name = report.Image.Name + "." + report.Image.Extension.ToString().ToLower();
            var savedImage = _imageStore.Save(report.Image);
            report.Image = savedImage;
            var savedRecord = _reportStore.Save(report);
            return savedRecord;
        }

        public void DeleteReport(int id)
        {
            _reportStore.Delete(id);
        }

        #endregion
    }
}
