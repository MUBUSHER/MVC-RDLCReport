using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Net;
using System.Web.Configuration;
using RdlcReportSolution.Services;

namespace RdlcReportSolution.Views.Shared
{
    public partial class ReportViewerControl : System.Web.Mvc.ViewUserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            // Required for report events to be handled properly.
            //reportViewer.ServerReport.ReportServerCredentials = new ReportServerCredentials();
            Context.Handler = Page;
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!Page.IsPostBack)
            {
                
                ReportServicesBase model = (ReportServicesBase)Model;
                //reportViewer.ServerReport.ReportServerCredentials = model.ServerCredentials;
                //ReportParameter[] RptParameters = model.parameters;
                ////reportViewer.ServerReport.ReportServerCredentials = model.ServerCredentials;
                //reportViewer.ServerReport.ReportPath = model.ReportPath;
                //reportViewer.ServerReport.ReportServerUrl = model.ReportServerURL;

                //if(RptParameters.Count() > 0)
                //this.reportViewer.ServerReport.SetParameters(RptParameters);
                //this.reportViewer.ServerReport.Refresh();
                reportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/TestReport.rdlc");
                reportViewer.LocalReport.Refresh();
                
            }            
        }
    }

   
   
    
}