using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using tattlr.services.Models.ViewModels;

namespace tattlr.services.Controllers
{
    public class ReportController : ApiController
    {
        // GET: api/Report
        public IEnumerable<SubmittedReportViewModel> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Report/5
        public SubmittedReportViewModel Get(int id)
        {
            return "value";
        }

        // POST: api/Report
        public void Post([FromBody]ReportSubmissionViewModel value)
        {
        }

        // PUT: api/Report/5
        public void Put(int id, [FromBody]ReportSubmissionViewModel value)
        {
        }

        // DELETE: api/Report/5
        public void Delete(int id)
        {
        }
    }
}
