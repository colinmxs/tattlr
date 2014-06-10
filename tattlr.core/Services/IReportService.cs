using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tattlr.core.Models;

namespace tattlr.core.Services
{
    public interface IReportService
    {
        void SaveReport(Report report, ReportImage image);
    }
}
