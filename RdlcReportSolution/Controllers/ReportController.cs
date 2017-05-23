using Microsoft.Reporting.WebForms;
using RdlcReportSolution.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RdlcReportSolution.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/
        private string TempDirectory = System.Web.HttpContext.Current.Server.MapPath("~/UploadTemp/");
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report()
        {
            return View("ViewReport", new VariationReportViewModel() { ReportPath = "~/Reports/TestReport.rdlc" });
        }

        public ActionResult ReportPartial()
        {
            return PartialView("ReportViewerControl", new VariationReportViewModel() { ReportPath = "~/Reports/TestReport.rdlc" });
        }

        public ActionResult AnotherReport()
        {
            return View("ViewReport", new VariationReportViewModel() { ReportPath = "~/Reports/TestReport.rdlc" });
        }

        public JsonResult DownloadFile()
        {

            ReportViewer rv = new ReportViewer();
            rv.ProcessingMode = ProcessingMode.Local;
            rv.LocalReport.ReportPath = Server.MapPath("~/Reports/TestReport.rdlc");
            rv.LocalReport.Refresh();

            byte[] streamBytes = null;
            string mimeType = "";
            string encoding = "";
            string filenameExtension = "";
            string[] streamids = null;
            Warning[] warnings = null;

            streamBytes = rv.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
            string filePath = DateTime.Now.ToString("ddMMyyyyhhmmss") + ".pdf";
            FileStream stream = System.IO.File.Create(TempDirectory + filePath, streamBytes.Length);
            stream.Write(streamBytes, 0, streamBytes.Length);
            stream.Close();

            //return File(streamBytes, mimeType, "TestReport.pdf");

            string url = new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext).Content("~/UploadTemp/" + filePath);

            return Json(new { fileUrl = url, fileName = filePath  }, JsonRequestBehavior.AllowGet);
        }
    }
}
