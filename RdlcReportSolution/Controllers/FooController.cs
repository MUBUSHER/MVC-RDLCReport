using RdlcReportSolution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RdlcReportSolution.Controllers
{
    public class FooController : Controller
    {
        //
        // GET: /Foo/

        public ActionResult VariationReport(VariationReportViewModel obj)
        {
            //VariationReportViewModel model = new VariationReportViewModel();
            obj.ResolveDataSource();
            return View("ViewReport", obj);
        }

    }

    public class VariationReportViewModel : ReportServicesBase
    {
        public int Id { get; set; }
        public String employeeName { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }

        public override string ReportPath
        {
            get
            {
                return "~/Reports/TestReport.rdlc";
            }            
        }

        public override void ResolveDataSource()
        {
            // TODO [Mubusher]: get data from server as per above parameter
        }
    }
}
